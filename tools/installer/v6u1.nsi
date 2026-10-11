; KONAYUKI PLUS - v6u1 revival installer
; Bundles the rebuilt (de-telemetried, v6u1-pointing) KonayukiPlus.exe plus the original
; KonayukiPlusLib.dll and the prerequisite runtimes, mirroring the original installer's layout:
;   %ProgramFiles(x86)%\Konayuki-moe\KONAYUKI PLUS\   (install root)
;   %ProgramData%\Konayuki Container  ->  (junction to the install root; the app's data dir)
; The app syncs everything else (codecs, ffmpeg, mpv, fonts...) from cdn.v6u1.lol on first run.
;
; Build with build-setup.ps1, which stages ${STAGE}\payload\ and passes /DSTAGE and /DAPPICON.

Unicode true
!include "MUI2.nsh"
!include "x64.nsh"

!ifndef STAGE
  !error "Pass /DSTAGE=<dir containing payload\> (use build-setup.ps1)"
!endif
!ifndef APPICON
  !error "Pass /DAPPICON=<path to app.ico> (use build-setup.ps1)"
!endif
!define UNINSTKEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\KONAYUKI PLUS"

Name "KONAYUKI PLUS"
OutFile "${STAGE}\KONAYUKI_PLUS_V6U1_SETUP.exe"
InstallDir "$PROGRAMFILES32\Konayuki-moe\KONAYUKI PLUS"
RequestExecutionLevel admin
ShowInstDetails show
ShowUnInstDetails show
BrandingText "KONAYUKI PLUS - v6u1 revival"
SetCompressor /SOLID lzma

VIProductVersion "2.0.0.0"
VIAddVersionKey "ProductName" "KONAYUKI PLUS"
VIAddVersionKey "CompanyName" "Konayuki.moe (v6u1 revival)"
VIAddVersionKey "LegalCopyright" "Konayuki.moe"
VIAddVersionKey "FileDescription" "KONAYUKI PLUS Setup (v6u1)"
VIAddVersionKey "FileVersion" "2.0.0.0"

!define MUI_ICON "${APPICON}"
!define MUI_UNICON "${APPICON}"
!define MUI_ABORTWARNING
!define MUI_FINISHPAGE_RUN "$INSTDIR\KonayukiPlus.exe"
!define MUI_FINISHPAGE_RUN_TEXT "Launch KONAYUKI PLUS"

!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
!insertmacro MUI_PAGE_FINISH
!insertmacro MUI_UNPAGE_CONFIRM
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_LANGUAGE "English"

Function .onInit
  ${IfNot} ${RunningX64}
    MessageBox MB_ICONSTOP "KONAYUKI PLUS requires 64-bit Windows."
    Abort
  ${EndIf}
FunctionEnd

Section "KONAYUKI PLUS" SecMain
  SectionIn RO
  ; close a running instance so files are not locked
  nsExec::ExecToLog 'cmd /c taskkill /IM KonayukiPlus.exe /F'

  SetOutPath "$INSTDIR"
  File "${STAGE}\payload\KonayukiPlus.exe"
  File "${STAGE}\payload\KonayukiPlusLib.dll"
  SetOutPath "$INSTDIR\redists"
  File "${STAGE}\payload\redists\Net_Framework.exe"
  File "${STAGE}\payload\redists\vcredist_x64_2012.exe"
  File "${STAGE}\payload\redists\vcredist_x64_2013.exe"
  File "${STAGE}\payload\redists\vcredist_x64_2015-19.exe"

  ; prerequisites (best-effort; already-present runtimes just repair/skip)
  DetailPrint "Installing prerequisites (.NET Framework, VC++ runtimes)..."
  ExecWait '"$INSTDIR\redists\Net_Framework.exe" /q /norestart'
  ExecWait '"$INSTDIR\redists\vcredist_x64_2012.exe" /install /passive /norestart'
  ExecWait '"$INSTDIR\redists\vcredist_x64_2013.exe" /install /passive /norestart'
  ExecWait '"$INSTDIR\redists\vcredist_x64_2015-19.exe" /install /passive /norestart'

  ; data directory: %ProgramData%\Konayuki Container -> $INSTDIR (junction)
  SetShellVarContext all
  DetailPrint "Linking data directory..."
  nsExec::ExecToLog 'cmd /c if exist "$APPDATA\Konayuki Container" rmdir "$APPDATA\Konayuki Container"'
  nsExec::ExecToLog 'cmd /c mklink /J "$APPDATA\Konayuki Container" "$INSTDIR"'

  ; shortcuts (all users)
  CreateDirectory "$SMPROGRAMS\KONAYUKI PLUS"
  CreateShortcut "$SMPROGRAMS\KONAYUKI PLUS\KONAYUKI PLUS.lnk" "$INSTDIR\KonayukiPlus.exe" "" "$INSTDIR\KonayukiPlus.exe" 0
  CreateShortcut "$SMPROGRAMS\KONAYUKI PLUS\Uninstall KONAYUKI PLUS.lnk" "$INSTDIR\uninstall.exe"
  CreateShortcut "$DESKTOP\KONAYUKI PLUS.lnk" "$INSTDIR\KonayukiPlus.exe" "" "$INSTDIR\KonayukiPlus.exe" 0

  ; Add/Remove Programs
  WriteRegStr HKLM "${UNINSTKEY}" "DisplayName" "KONAYUKI PLUS"
  WriteRegStr HKLM "${UNINSTKEY}" "DisplayVersion" "2.0"
  WriteRegStr HKLM "${UNINSTKEY}" "Publisher" "Konayuki.moe (v6u1 revival)"
  WriteRegStr HKLM "${UNINSTKEY}" "DisplayIcon" "$INSTDIR\KonayukiPlus.exe"
  WriteRegStr HKLM "${UNINSTKEY}" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegStr HKLM "${UNINSTKEY}" "InstallLocation" "$INSTDIR"
  WriteRegDWORD HKLM "${UNINSTKEY}" "NoModify" 1
  WriteRegDWORD HKLM "${UNINSTKEY}" "NoRepair" 1
  WriteUninstaller "$INSTDIR\uninstall.exe"
SectionEnd

Section "Uninstall"
  SetShellVarContext all
  nsExec::ExecToLog 'cmd /c taskkill /IM KonayukiPlus.exe /F'
  ; remove the junction link only (no /s, never touches the target contents)
  nsExec::ExecToLog 'cmd /c if exist "$APPDATA\Konayuki Container" rmdir "$APPDATA\Konayuki Container"'
  Delete "$SMPROGRAMS\KONAYUKI PLUS\*.lnk"
  RMDir "$SMPROGRAMS\KONAYUKI PLUS"
  Delete "$DESKTOP\KONAYUKI PLUS.lnk"
  RMDir /r "$INSTDIR"
  DeleteRegKey HKLM "${UNINSTKEY}"
SectionEnd
