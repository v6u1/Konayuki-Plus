# Builds KONAYUKI_PLUS_V6U1_SETUP.exe into build\setup\:
# rebuilds KonayukiPlus.exe, stages the installer payload, then runs makensis on v6u1.nsi.
#
#   -InstallDir  where KonayukiPlusLib.dll and the redists\ runtimes are taken from
#                (default: the original installation on this machine)
#   -PayloadDir  take them from this folder instead (same layout: KonayukiPlusLib.dll, redists\*.exe);
#                the release workflow downloads the payload there
#   -SkipBuild   package the KonayukiPlus.exe that is already in bin\Release
#
# Every payload file must match tools\installer\payload.sha256, whichever folder it came from.
param(
    [string]$InstallDir = "C:\Program Files (x86)\Konayuki-moe\KONAYUKI PLUS",
    [string]$PayloadDir = "",
    [string]$MakeNsis = "C:\Program Files (x86)\NSIS\makensis.exe",
    [switch]$SkipBuild
)
$ErrorActionPreference = 'Stop'
$repo = (Resolve-Path "$PSScriptRoot\..\..").Path
$stage = Join-Path $repo "build\setup"
$payload = Join-Path $stage "payload"
$source = if ($PayloadDir) { $PayloadDir } else { $InstallDir }

# Without the git-ignored server config the app is built against a placeholder host and could not
# reach any server; never package such a build.
if (-not (Test-Path "$repo\src\KonayukiPlus\KonayukiPlus\ServerConfig.local.cs")) {
    throw "src\KonayukiPlus\KonayukiPlus\ServerConfig.local.cs is missing: copy ServerConfig.example.cs to it and set the real server URL"
}

if (-not $SkipBuild) {
    & dotnet build "$repo\src\KonayukiPlus\KonayukiPlus.csproj" -c Release -v q -nologo
    if ($LASTEXITCODE -ne 0) { throw "dotnet build failed" }
}

$exe = "$repo\src\KonayukiPlus\bin\Release\KonayukiPlus.exe"
# The app's self-updater can overwrite the exe it runs from with the server copy;
# refuse to package anything that is not the v6u1 build.
if (-not ([Text.Encoding]::Unicode.GetString([IO.File]::ReadAllBytes($exe)) -match 'cdn\.v6u1\.lol')) {
    throw "$exe is not the v6u1 build (was it replaced by the self-updater? rebuild it)"
}

Remove-Item -Recurse -Force $payload -ErrorAction SilentlyContinue
New-Item -ItemType Directory -Force "$payload\redists" | Out-Null
Copy-Item $exe "$payload\KonayukiPlus.exe"
Copy-Item "$source\KonayukiPlusLib.dll" "$payload\"
foreach ($r in 'Net_Framework.exe', 'vcredist_x64_2012.exe', 'vcredist_x64_2013.exe', 'vcredist_x64_2015-19.exe') {
    Copy-Item "$source\redists\$r" "$payload\redists\"
}

$expected = @{}
foreach ($line in Get-Content "$PSScriptRoot\payload.sha256") {
    if ($line -match '^\s*([0-9a-fA-F]{64})\s+\*?(.+?)\s*$') { $expected[$matches[2].Replace('/', '\')] = $matches[1].ToLower() }
}
if ($expected.Count -eq 0) { throw "payload.sha256 lists no files" }
foreach ($rel in $expected.Keys) {
    $file = Join-Path $payload $rel
    if (-not (Test-Path $file)) { throw "payload file missing: $rel" }
    if ((Get-FileHash $file -Algorithm SHA256).Hash.ToLower() -ne $expected[$rel]) { throw "payload file does not match payload.sha256: $rel" }
}

& $MakeNsis "/DSTAGE=$stage" "/DAPPICON=$repo\src\KonayukiPlus\app.ico" "$PSScriptRoot\v6u1.nsi"
if ($LASTEXITCODE -ne 0) { throw "makensis failed" }

$setup = Get-Item "$stage\KONAYUKI_PLUS_V6U1_SETUP.exe"
"{0}  {1:N0} bytes  sha1={2}" -f $setup.FullName, $setup.Length, (Get-FileHash $setup.FullName -Algorithm SHA1).Hash.ToLower()
