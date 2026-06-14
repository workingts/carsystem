[Setup]
AppName=CAR SYSTEM
AppVersion=1.0
AppPublisher=chan dev
DefaultDirName={autopf}\CAR SYSTEM
DefaultGroupName=CAR SYSTEM
OutputDir=..\dist
OutputBaseFilename=CAR_SYSTEM_v1.0_setup
Compression=lzma
SolidCompression=yes

[Files]
Source: "bin\Release\net9.0-windows7.0\*"; DestDir: "{app}"; Flags: recursesubdirs
Source: "NOTICE.md"; DestDir: "{app}"
Source: "README.md"; DestDir: "{app}"
Source: "LICENSE"; DestDir: "{app}"

[Dirs]
Name: "{userappdata}\CAR SYSTEM"; Permissions: users-full

[Icons]
Name: "{group}\CAR SYSTEM"; Filename: "{app}\CAR_SYSTEM.exe"
Name: "{commondesktop}\CAR SYSTEM"; Filename: "{app}\CAR_SYSTEM.exe"

[Run]
Filename: "{app}\CAR_SYSTEM.exe"; Description: "실행"; Flags: postinstall
