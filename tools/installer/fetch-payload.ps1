# Downloads the installer payload listed in payload.sha256 from <BaseUrl>/installer/ into -OutDir,
# for build-setup.ps1 -PayloadDir. Used by the release workflow. BaseUrl is the server base URL from
# ServerConfig.local.cs, which is secret, so it is never printed (not even in error messages).
param(
    [Parameter(Mandatory = $true)][string]$BaseUrl,
    [Parameter(Mandatory = $true)][string]$OutDir
)
$ErrorActionPreference = 'Stop'
$ProgressPreference = 'SilentlyContinue'  # the progress bar makes Invoke-WebRequest very slow
$base = $BaseUrl.TrimEnd('/')
foreach ($line in Get-Content "$PSScriptRoot\payload.sha256") {
    if ($line -notmatch '^\s*([0-9a-fA-F]{64})\s+\*?(.+?)\s*$') { continue }
    $rel = $matches[2]
    $dest = Join-Path $OutDir $rel.Replace('/', '\')
    New-Item -ItemType Directory -Force (Split-Path $dest) | Out-Null
    try {
        Invoke-WebRequest -Uri "$base/installer/$rel" -OutFile $dest -UseBasicParsing
    } catch {
        $status = if ($_.Exception.Response) { [int]$_.Exception.Response.StatusCode } else { 'no response' }
        throw "could not download payload file $rel (HTTP $status)"
    }
    "  {0}  {1:N0} bytes" -f $rel, (Get-Item $dest).Length
}
