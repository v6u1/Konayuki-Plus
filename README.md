# KONAYUKI PLUS — download, fix and source (Konayuki.moe anime encoder, revived)

**KONAYUKI PLUS is working again.** If you are searching for *Konayuki Plus download*, *konayuki.moe not working*, *"Connecting... Can't connect to server?"*, *Konayuki Plus RTX 50 / NVENC error* or *Konayuki Plus alternative*: this is the maintained build with a working installer and automatic updates. **[Download the latest installer](https://github.com/v6u1/KonayukiPlus/releases/latest/download/KONAYUKI_PLUS_V6U1_SETUP.exe)**.

KONAYUKI PLUS is a Windows anime encoder for fansubbers by [Konayuki.moe](https://konayuki.moe): a queue-based
front end for AviSynth+, FFmpeg and hardware encoders (NVENC/AMF) with hardsubbing, filters, a preview player
and an automatic updater. Development stopped after version **2.0.7213.1875** (API `2021.01.28.19.02.01`,
January 2021). Its update and configuration servers were left unmaintained, and on current hardware the
bundled 2021 FFmpeg could no longer encode at all, which left existing users stuck.

This repository brings it back: the C# source recovered from the last public release, the fixes needed to run
it today, a replacement backend, and an installer.

## Download and install

**[Download KONAYUKI_PLUS_V6U1_SETUP.exe](https://github.com/v6u1/KonayukiPlus/releases/latest/download/KONAYUKI_PLUS_V6U1_SETUP.exe)**
for Windows 10 or 11, 64-bit ([all releases](https://github.com/v6u1/KonayukiPlus/releases)).

1. Run the installer. It installs KONAYUKI PLUS, the .NET Framework and Visual C++ runtimes it needs, and Start
   menu and desktop shortcuts. Installing over an existing KONAYUKI PLUS keeps its settings.
2. Start KONAYUKI PLUS. The first start downloads the encoding tools (FFmpeg, AviSynth+ and its filters, mpv,
   codecs; about 300 MB), so keep it open until the main window appears. Fonts that your subtitles use are
   downloaded automatically the first time they are needed.

Everything after that is automatic: on every start the app checks for new versions of itself and of its tools
and installs them, and when the app itself was updated, "What's New" opens. You never need to download it again.

Windows SmartScreen may warn about the installer because it is not code-signed. Choose **More info → Run anyway**.

**Troubleshooting**

- *"Connecting... Can't connect to server?"* on the start screen: check the internet connection and any
  firewall. The original Konayuki.moe release and earlier v6u1 builds can no longer connect; install the latest
  release over them.
- *"File Corruption"*: a download was interrupted or changed on the way (antivirus software sometimes does this).
  Start the app again and it downloads the file again. If an antivirus keeps quarantining files in the
  installation folder, restore them and allow that folder.
- The update log is `%ProgramData%\Konayuki Container\tmp\synclog.log`, and unexpected errors are
  written to `crash.log` in the same folder. Attach them when you
  [report a problem](https://github.com/v6u1/KonayukiPlus/issues/new/choose).

> **Disclaimer.** This project is not affiliated with Konayuki.moe. KONAYUKI PLUS, its code and its assets
> belong to their original authors. The source here was recovered by decompiling the last public binary so the
> program stays usable for the people who depend on it; no license is granted for the original code or assets.
> If you are a rights holder and want something changed or removed, please open an issue.

## Contents

- [Download and install](#download-and-install)
- [What was done](#what-was-done)
- [How the client talks to the server](#how-the-client-talks-to-the-server)
- [Building](#building)
- [Releasing](#releasing)
- [Re-running the recovery pipeline](#re-running-the-recovery-pipeline)
- [Repository layout](#repository-layout)
- [Third-party components](#third-party-components)

## What was done

### 1. Buildable source from the shipped binary

The only artifact of the app was an obfuscated, packed `KonayukiPlus.exe` (.NET Framework 4.7.1, x64 WinForms),
protected with:

- **Obfuscar** — every string literal moved into one XOR-encrypted blob behind per-string getter methods
  (*HideStrings*), and every identifier renamed to Hangul characters (*UseKoreanNames*);
- **Costura.Fody** — all dependencies embedded as deflate-compressed resources and loaded at runtime;
- **`[SuppressIldasm]`**.

Recovery steps:

1. **`tools/Deobfuscator`** ([dnlib](https://github.com/0xd4d/dnlib)) decrypts and inlines all **1,446**
   strings, renames all **1,915** obfuscated identifiers (WinForms control and event-handler names are recovered
   from the designer code in `InitializeComponent`, P/Invoke names from their import table, compiler-generated
   names so the decompiler folds closures and auto-properties back), strips `SuppressIldasm`, unpacks the
   Costura dependencies and extracts the compiled `.resources` streams.
2. **ILSpy** (`ilspycmd`) decompiles the cleaned assembly against the unpacked dependencies (`build/refs`).
   Without those references the output contains thousands of spurious casts and broken comments.
3. **`tools/SourceFixer`** ([Roslyn](https://github.com/dotnet/roslyn)) repairs the remaining decompiler
   artifacts by compiler error location (setter `value` parameters renamed after their type, leftover base
   constructor calls), repeated until the project compiles cleanly.
4. **Project file.** `net471` is built through the `Microsoft.NETFramework.ReferenceAssemblies` NuGet package, so
   no targeting pack or Visual Studio is needed. The original compiled `.resources` are embedded verbatim (the
   decompiled `.resx` files hold BinaryFormatter-serialized images that the modern SDK refuses to re-serialize),
   and the original Costura payload is embedded unchanged.
5. **Costura bootstrap.** Costura installs its assembly resolver from the module initializer, which C# source
   cannot express, so it was lost in the decompile and the rebuilt app crashed at startup with
   `FileNotFoundException`. `CosturaBootstrap.cs` restores it with a `[ModuleInitializer]`.
6. **Fidelity check.** `Deobfuscator compare` matches every method between the cleaned original and the rebuilt
   assembly and compares a compiler-independent fingerprint (calls, literals, field writes, casts, switches,
   throws). Every difference it reports is either an intended change listed below or harmless code-generation
   noise; the rebuild alters no logic.

### 2. Cleanup

- **Hidden telemetry removed.** After every encode that used a subtitle file, the app silently zipped that
  subtitle together with its own logs, tagged the archive with the computer's motherboard serial number and the
  Windows user name, and uploaded it to `log.konayuki.moe`. A background thread at startup uploaded anything left
  over. All three entry points are gutted; the endpoint no longer exists in the binary.
- **Anti-analysis gate removed.** The upload was skipped whenever a network or process inspection tool (Fiddler,
  Wireshark, Process Hacker and similar) was running. That check is gone as well.

### 3. Fixes

- **Encoding crash.** Once encoding actually ran, the progress parser crashed on FFmpeg lines reporting
  `size=N/A`, and on Windows installations with a comma decimal separator (for example Turkish) on
  `.`-decimal values. Parsing is now invariant-culture and tolerant of malformed lines.
- **Current GPUs.** The bundled FFmpeg 4.3.1 (2021) fails on recent NVIDIA cards
  (`Cannot get the preset configuration: unsupported param`). The update server now ships a current FFmpeg
  build through the normal update mechanism; no app change was needed.

### 4. A new backend

Every network endpoint the original hard-coded across the code base (`*.konayuki.moe`) is centralised in
[`Server.cs`](src/KonayukiPlus/KonayukiPlus/Server.cs), so moving to another server is one change. The
replacement backend is a set of static files behind nginx and Cloudflare:

- the encrypted configuration blob (`plugins.cfg`), with the AviSynth function library, the mpv player
  configuration and a catalogue of **10,877 fonts**, all mirrored to the new server;
- the update manifest (`list.txt`) and every file it lists (FFmpeg, mpv, AviSynth+ and its filters, codecs,
  runtimes — about 300 MB);
- the "What's New" changelog page and the per-filter help pages;
- the installer.

**Access.** Apart from the public changelog page, the server only serves these files under an unguessable path
prefix that the client is built with. The prefix is kept out of this repository (see
[Building](#building)); every other path, and any backup, log or script on the server, returns 404.

**Administration.** The maintainer manages the backend from a password-protected dashboard on their own website
(not part of this repository). It can edit every field of the configuration blob or the raw JSON (validated
and backed up before each write), edit the update manifest, upload or delete update files, verify every file
against its SHA-1, add, upload or remove fonts, check the health of every public URL (including that locked paths
really return 404), restore backups, and review an audit log of all changes. It also edits the changelog: the
page it generates is a pixel-identical reproduction of the original konayuki.moe timeline, and the full original
history (32 entries, 2018–2021) has been imported. The dashboard can also announce an update (see below), and
it publishes new GitHub releases to users automatically (see [Releasing](#releasing)).

### 5. Installer

[`tools/installer`](tools/installer) builds `KONAYUKI_PLUS_V6U1_SETUP.exe` with NSIS. It mirrors the original
installer's layout — install root under `Program Files (x86)\Konayuki-moe\KONAYUKI PLUS`, the
`%ProgramData%\Konayuki Container` junction the app uses as its data folder, the .NET and Visual C++
prerequisites, shortcuts and an uninstaller — but ships the rebuilt executable. Everything else is downloaded by
the app's own updater on first start.

## How the client talks to the server

All traffic is plain HTTPS GET, relative to `Server.Host`:

| Path | Purpose |
| --- | --- |
| `sync/plugins.cfg` | Configuration blob, read by the splash screen on every start. |
| `sync/list.txt` | Update manifest; the files it lists are fetched from `sync/<path>`. |
| `plus_changelog.html` | "What's New" window. |
| `KonayukiPlus/<NAME>.html` | Help page of each filter. |
| font URLs inside `plugins.cfg` | Fonts, downloaded on demand when a subtitle needs them. |

**`plugins.cfg`** is `base64( XOR( UTF-8 JSON, key ) )`, where the key is a 100-byte constant in the client.
The JSON holds `Version` (shown on the splash screen, the tray menu and the About box — display only, never
compared), `Function` (the AviSynth function library), `Proc` (encoder process names), `Proxy` (the former
anti-analysis list), `Player` (mpv settings) and `Fonts` (`base64(font name)` → URL). The client decodes the
base64 bytes to a string and back before XOR-ing them, so the XOR-ed bytes must themselves be valid UTF-8; when
generating the file, verify that and round-trip it before publishing.

**`list.txt`** has one line per file: `\relative\path|sha1|run|args`. On every start the client compares each
local file's SHA-1 (lowercase hex) with the manifest and downloads what differs or is missing. `.zip` files are
extracted in place; entries with `run` = `True` are executed with `args` (installers, runtimes). When the entry for
`KonayukiPlus.exe` changes, the client swaps itself and restarts with `/log`. Note that the URL is built by plain
concatenation, so the client actually requests `sync//relative/path`.

**"What's New".** The changelog window only accepts the page if its `<title>` contains `konayuki.moe`. The client
opens it automatically at startup **only when that start's update downloaded at least one file** (or when it was
restarted with `/log` after updating itself); publishing a changelog entry or changing `Version` does not open it.
To announce an update without shipping a new binary, the server changes a tiny `\whatsnew.stamp` entry in
`list.txt`: every client downloads it once and shows "What's New".

## Building

Requirements: Windows and the .NET SDK 8 or later. Visual Studio and the .NET Framework targeting pack are not
needed.

1. Copy `src/KonayukiPlus/KonayukiPlus/ServerConfig.example.cs` to `ServerConfig.local.cs` in the same folder and
   set `Host` to your server's base URL. This file is git-ignored; never commit it.
2. Build:

   ```
   dotnet build src/KonayukiPlus/KonayukiPlus.csproj -c Release
   ```

   The result is a single `src/KonayukiPlus/bin/Release/KonayukiPlus.exe` (x64, dependencies embedded).

Without `ServerConfig.local.cs` the project still builds, with a warning, against the placeholder host from
`ServerConfig.example.cs`; that executable cannot reach any server.

To run your own server, publish the files described in
[How the client talks to the server](#how-the-client-talks-to-the-server) under your base URL.

**Installer.** Install [NSIS 3](https://nsis.sourceforge.io), keep an existing KONAYUKI PLUS installation on the
machine (the script takes `KonayukiPlusLib.dll` and the prerequisite runtimes from it), then run:

```
powershell -ExecutionPolicy Bypass -File tools\installer\build-setup.ps1
```

The script rebuilds the executable, refuses to package it without `ServerConfig.local.cs`, checks every payload
file against [`tools/installer/payload.sha256`](tools/installer/payload.sha256), and writes
`build\setup\KONAYUKI_PLUS_V6U1_SETUP.exe`. With `-PayloadDir <folder>` it takes the payload from that folder
instead of an installation (`fetch-payload.ps1` downloads it from the server; the release workflow does both).

## Releasing

Releases are built and published automatically:

1. Push a version tag (`git tag v2026.10.14`, then `git push origin v2026.10.14`), or open
   **Actions → Release → Run workflow**. There the version defaults to today's date, and *pre-release* makes a
   test build that is not handed to users.
2. The [Release workflow](.github/workflows/release.yml) builds the app with the server URL from the
   `KONAYUKI_HOST` repository secret, downloads the installer payload from the server and checks it against
   `payload.sha256`, builds the installer with NSIS, and publishes a GitHub release whose only file is the
   installer.
3. The server checks GitHub every five minutes. When a new release (not a pre-release) appears, it downloads the
   installer, checks it against the SHA-256 that GitHub records for every release file, takes `KonayukiPlus.exe`
   out of it with 7-Zip, makes sure that executable was built for this server, and puts it in the update
   manifest. Installed copies update themselves on their next start.

The maintainer dashboard can do the same by hand: publish the newest release at once, publish an older one to
roll back, or turn automatic publishing off.

To set this up for another server, create the `KONAYUKI_HOST` secret (Settings → Secrets and variables →
Actions) with the same base URL as `ServerConfig.local.cs`, and serve the files listed in `payload.sha256` under
`<base URL>/installer/`.

## Re-running the recovery pipeline

This is only needed to reproduce the decompile; it requires the original 2.0.7213.1875 `KonayukiPlus.exe`, which
is not included. `ilspycmd` 11.1 needs the .NET 10 runtime.

```
dotnet tool install ilspycmd --version 11.1.0.9782 --tool-path tools

dotnet run --project tools/Deobfuscator -- analyze   original/KonayukiPlus.exe build/analysis
dotnet run --project tools/Deobfuscator -- clean     original/KonayukiPlus.exe build/clean/KonayukiPlus.exe
dotnet run --project tools/Deobfuscator -- resources build/clean/KonayukiPlus.exe src/KonayukiPlus/res

tools\ilspycmd -p -o src\KonayukiPlus -lv CSharp11_0 -r build\refs build\clean\KonayukiPlus.exe

dotnet build src/KonayukiPlus/KonayukiPlus.csproj -c Release > build/build.log
dotnet run --project tools/SourceFixer -- build/build.log     # repeat build + fix until it compiles

dotnet run --project tools/Deobfuscator -- compare build/clean/KonayukiPlus.exe src/KonayukiPlus/bin/Release/KonayukiPlus.exe
```

`analyze` also writes the unpacked Costura dependencies; those are the assemblies in `build/refs`.

## Repository layout

```
src/KonayukiPlus/               recovered C# project (net471, x64, WinForms)
  KonayukiPlus/                 decompiled sources plus the revival changes
  res/                          original compiled .resources, embedded verbatim
  costura.*.compressed          original Costura payload (the embedded dependencies)
build/refs/                     dependency assemblies the project compiles against
tools/Deobfuscator/             dnlib deobfuscator, resource extractor and fidelity comparer
tools/SourceFixer/              Roslyn fixer for decompiler artifacts
tools/installer/                NSIS installer script, its build script and the payload checksums
.github/workflows/              build check on every push; release builds
.github/ISSUE_TEMPLATE/         bug report form
```

Files that differ from the plain decompile: `Server.cs` and `ServerConfig.example.cs` (endpoints),
`CosturaBootstrap.cs` (dependency loading), `Program.cs` and `frmMain.cs` (encoding crash), and `Class10.cs` and
`frmSplash.cs` (telemetry). Each change is commented in place.

## Third-party components

Embedded in the application (taken unchanged from the original release):
[MetroFramework](https://github.com/dennismagno/metroframework-modern-ui) (MIT),
[NAudio](https://github.com/naudio/NAudio) (MIT),
[Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json) (MIT),
[ByteSize](https://github.com/omar/ByteSize) (MIT),
DotNetZip (Ms-PL),
Windows API Code Pack (Microsoft), and the [Costura.Fody](https://github.com/Fody/Costura) runtime loader (MIT).

Used by the tooling: [dnlib](https://github.com/0xd4d/dnlib) (MIT), [Roslyn](https://github.com/dotnet/roslyn)
(MIT), [ILSpy](https://github.com/icsharpcode/ILSpy) (MIT), [NSIS](https://nsis.sourceforge.io) (zlib).

At runtime the app downloads and drives FFmpeg, AviSynth+ and its plugins, mpv and the K-Lite codecs, which keep
their own licenses.
