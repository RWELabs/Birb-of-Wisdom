; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Birb of Wisdom"
#define MyAppVersion "1.03"
#define MyAppPublisher "R. Walpole"
#define MyAppURL "https://www.ryananthony.xyz/"
#define MyAppExeName "Birb of Wisdom.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{771F584F-BD18-4ABE-9968-2F8CFC317037}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName=C:\Program Files (x86)\Birb of Wisdom\{#MyAppName}
DisableProgramGroupPage=yes
LicenseFile=C:\Users\rwalpole\Documents\GitHub\Birb-of-Wisdom\Source Code\bin\Release\license.rtf
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputDir=C:\Users\rwalpole\Documents\GitHub\Birb-of-Wisdom\Installers
OutputBaseFilename=latest
SetupIconFile=C:\Users\rwalpole\Documents\GitHub\Birb-of-Wisdom\Source Code\icons8-sparrowhawk-96.ico
Compression=lzma
SolidCompression=yes
WizardStyle=modern
UninstallDisplayIcon={app}\{#MyAppExeName}
UninstallDisplayName=Birb of Wisdom

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\rwalpole\Documents\GitHub\Birb-of-Wisdom\Source Code\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\rwalpole\Documents\GitHub\Birb-of-Wisdom\Source Code\bin\Release\birbicon.ico"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{autoprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

