; Instalador de AplBigStore (se compila con Inno Setup 6).
; Antes de compilar: publicar el programa en la carpeta "publicado"
;   dotnet publish ..\GU_Tercero\GU_Tercero\Vista.csproj -c Release -r win-x64 --self-contained true -o publicado
; Resultado: Instalar_AplBigStore.exe en esta misma carpeta.

#define NombreApp "AplBigStore"
#define VersionApp "1.0"
#define ExeApp "Vista.exe"

[Setup]
AppId={{7D3E1B2A-5C4F-4E8B-9A61-2F0C8D4B7E35}
AppName={#NombreApp}
AppVersion={#VersionApp}
AppVerName={#NombreApp} {#VersionApp}
AppPublisher={#NombreApp}
DefaultDirName={autopf}\{#NombreApp}
DefaultGroupName={#NombreApp}
DisableProgramGroupPage=yes
OutputDir=.
OutputBaseFilename=Instalar_AplBigStore
SetupIconFile=AplBigStore.ico
UninstallDisplayIcon={app}\AplBigStore.ico
UninstallDisplayName={#NombreApp}
Compression=lzma2
SolidCompression=yes
WizardStyle=modern
ArchitecturesAllowed=x64compatible
ArchitecturesInstallIn64BitMode=x64compatible
PrivilegesRequired=admin
PrivilegesRequiredOverridesAllowed=commandline

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "escritorio"; Description: "Crear un acceso directo en el Escritorio"; GroupDescription: "Accesos directos:"

[Files]
; Programa publicado (incluye .NET 8, no hace falta instalarlo aparte)
Source: "publicado\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "..\GU_Tercero\GU_Tercero\loguito trtansparente.png"; DestDir: "{app}"; Flags: ignoreversion
Source: "AplBigStore.ico"; DestDir: "{app}"; Flags: ignoreversion
; Scripts de la base de datos
Source: "..\ScriptsBD\*.sql"; DestDir: "{app}\ScriptsBD"; Flags: ignoreversion
Source: "..\ScriptsBD\ejecutar_todo.bat"; DestDir: "{app}\ScriptsBD"; Flags: ignoreversion

[Icons]
Name: "{group}\{#NombreApp}"; Filename: "{app}\{#ExeApp}"; WorkingDir: "{app}"; IconFilename: "{app}\AplBigStore.ico"
Name: "{group}\Crear o actualizar la base de datos"; Filename: "{app}\ScriptsBD\ejecutar_todo.bat"; WorkingDir: "{app}\ScriptsBD"
Name: "{group}\Desinstalar {#NombreApp}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#NombreApp}"; Filename: "{app}\{#ExeApp}"; WorkingDir: "{app}"; IconFilename: "{app}\AplBigStore.ico"; Tasks: escritorio

[Run]
Filename: "{app}\ScriptsBD\ejecutar_todo.bat"; WorkingDir: "{app}\ScriptsBD"; Description: "Crear o actualizar la base de datos ahora"; Flags: postinstall shellexec skipifsilent waituntilterminated
Filename: "{app}\{#ExeApp}"; WorkingDir: "{app}"; Description: "Abrir {#NombreApp}"; Flags: postinstall nowait skipifsilent unchecked

[Code]
// El programa se conecta a la instancia .\SQLEXPRESS. Si no está instalada, se avisa antes de seguir.
function SqlExpressInstalado(): Boolean;
var
  Valor: String;
begin
  Result := RegQueryStringValue(HKLM64, 'SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL', 'SQLEXPRESS', Valor)
         or RegQueryStringValue(HKLM32, 'SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL', 'SQLEXPRESS', Valor);
end;

function InitializeSetup(): Boolean;
begin
  Result := True;
  if not SqlExpressInstalado() then
    Result := MsgBox('No se encontró SQL Server Express (instancia SQLEXPRESS) en esta computadora.' + #13#10 + #13#10 +
                     'AplBigStore se puede instalar igual, pero para usarlo primero hay que instalar SQL Server Express ' +
                     'y después crear la base de datos (ver el Manual de Instalación).' + #13#10 + #13#10 +
                     '¿Desea continuar con la instalación?', mbConfirmation, MB_YESNO) = IDYES;
end;
