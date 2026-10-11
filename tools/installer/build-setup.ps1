# Builds KONAYUKI_PLUS_V6U1_SETUP.exe into build\setup\:
# rebuilds KonayukiPlus.exe, stages the installer payload, then runs makensis on v6u1.nsi.
#
#   -InstallDir  where KonayukiPlusLib.dll and the redists\ runtimes are taken from
#                (default: the original installation on this machine)
param(
    [string]$InstallDir = "C:\Program Files (x86)\Konayuki-moe\KONAYUKI PLUS",
    [string]$MakeNsis = "C:\Program Files (x86)\NSIS\makensis.exe"
)
$ErrorActionPreference = 'Stop'
$repo = (Resolve-Path "$PSScriptRoot\..\..").Path
$stage = Join-Path $repo "build\setup"
$payload = Join-Path $stage "payload"

& dotnet build "$repo\src\KonayukiPlus\KonayukiPlus.csproj" -c Release -v q -nologo
if ($LASTEXITCODE -ne 0) { throw "dotnet build failed" }

$exe = "$repo\src\KonayukiPlus\bin\Release\KonayukiPlus.exe"
# The app's self-updater can overwrite the exe it runs from with the server copy;
# refuse to package anything that is not the v6u1 build.
if (-not ([Text.Encoding]::Unicode.GetString([IO.File]::ReadAllBytes($exe)) -match 'cdn\.v6u1\.lol')) {
    throw "$exe is not the v6u1 build (was it replaced by the self-updater? rebuild it)"
}

Remove-Item -Recurse -Force $payload -ErrorAction SilentlyContinue
New-Item -ItemType Directory -Force "$payload\redists" | Out-Null
Copy-Item $exe "$payload\KonayukiPlus.exe"
Copy-Item "$InstallDir\KonayukiPlusLib.dll" "$payload\"
foreach ($r in 'Net_Framework.exe', 'vcredist_x64_2012.exe', 'vcredist_x64_2013.exe', 'vcredist_x64_2015-19.exe') {
    Copy-Item "$InstallDir\redists\$r" "$payload\redists\"
}

& $MakeNsis "/DSTAGE=$stage" "/DAPPICON=$repo\src\KonayukiPlus\app.ico" "$PSScriptRoot\v6u1.nsi"
if ($LASTEXITCODE -ne 0) { throw "makensis failed" }

$setup = Get-Item "$stage\KONAYUKI_PLUS_V6U1_SETUP.exe"
"{0}  {1:N0} bytes  sha1={2}" -f $setup.FullName, $setup.Length, (Get-FileHash $setup.FullName -Algorithm SHA1).Hash.ToLower()
