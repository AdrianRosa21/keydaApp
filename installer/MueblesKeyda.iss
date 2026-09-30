; Instalador de Muebles Keyda (Inno Setup 6)
;
; Antes de compilar hay que generar la aplicación en Release:
;   MSBuild Vista\Vista.csproj /p:Configuration=Release
; Luego compilar este script con ISCC.exe (o con el script installer\build.ps1).
; El instalador queda en installer\Output\MueblesKeydaSetup.exe

#define AppName "Muebles Keyda"
#define AppVersion "1.0.0"
#define AppPublisher "Muebles Keyda"
#define AppExeName "Vista.exe"
#define BuildDir "..\Vista\bin\Release"

[Setup]
AppId={{7E2B4C1A-5D3F-4E8A-9B61-2C0F8A4D7E13}
AppName={#AppName}
AppVersion={#AppVersion}
AppVerName={#AppName} {#AppVersion}
AppPublisher={#AppPublisher}
DefaultDirName={autopf}\{#AppName}
DefaultGroupName={#AppName}
DisableProgramGroupPage=yes
OutputDir=Output
OutputBaseFilename=MueblesKeydaSetup
SetupIconFile=..\Vista\icono-app.ico
UninstallDisplayIcon={app}\{#AppExeName}
UninstallDisplayName={#AppName}
Compression=lzma2/max
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64compatible
MinVersion=10.0
; Instalar SQL Server LocalDB y escribir en Program Files requiere administrador
PrivilegesRequired=admin
PrivilegesRequiredOverridesAllowed=commandline
ShowLanguageDialog=no
LanguageDetectionMethod=none
CloseApplications=yes

[Languages]
Name: "spanish"; MessagesFile: "compiler:Languages\Spanish.isl"

[Tasks]
Name: "desktopicon"; Description: "Crear un acceso directo en el &escritorio"; GroupDescription: "Accesos directos:"

[Files]
Source: "{#BuildDir}\*"; DestDir: "{app}"; \
  Excludes: "*.pdb,*.xml,Harness.exe,SaveTest.exe,de\*,fr\*,it\*,ja\*,ko\*,pt\*,ru\*,zh-CHS\*,zh-CHT\*,runtimes\win-arm64\*"; \
  Flags: ignoreversion recursesubdirs createallsubdirs

[Dirs]
; La aplicación guarda aquí los PDF de cotizaciones y reportes, por eso los usuarios necesitan permiso de escritura
Name: "{app}\Cotizaciones"; Permissions: users-modify
Name: "{app}\Reportes"; Permissions: users-modify

[Icons]
Name: "{group}\{#AppName}"; Filename: "{app}\{#AppExeName}"; WorkingDir: "{app}"
Name: "{group}\Desinstalar {#AppName}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#AppName}"; Filename: "{app}\{#AppExeName}"; WorkingDir: "{app}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#AppExeName}"; Description: "Abrir {#AppName}"; Flags: nowait postinstall skipifsilent

[Code]
const
  // SQL Server LocalDB (Microsoft). Se prueba primero la versión 2022 y, si falla, la 2019.
  UrlLocalDB2022 = 'https://download.microsoft.com/download/3/8/d/38de7036-2433-4207-8eae-06e247e17b25/SqlLocalDB.msi';
  UrlLocalDB2019 = 'https://download.microsoft.com/download/7/c/1/7c14e92e-bdcb-4f89-b7cf-93543e7112d1/SqlLocalDB.msi';
  ArchivoLocalDB = 'SqlLocalDB.msi';

var
  PaginaDescarga: TDownloadWizardPage;
  InstalarLocalDB: Boolean;

function LocalDBInstalado: Boolean;
var
  Versiones: TArrayOfString;
begin
  Result := RegGetSubkeyNames(HKLM, 'SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions', Versiones)
    and (GetArrayLength(Versiones) > 0);
end;

function NetFramework472Instalado: Boolean;
var
  Release: Cardinal;
begin
  // 461808 = .NET Framework 4.7.2
  Result := RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', Release)
    and (Release >= 461808);
end;

function InitializeSetup: Boolean;
begin
  Result := True;

  if not NetFramework472Instalado then
  begin
    MsgBox('Muebles Keyda necesita .NET Framework 4.7.2 o superior, que no está instalado en este equipo.' + #13#10#13#10 +
      'Instálalo desde https://dotnet.microsoft.com/download/dotnet-framework y vuelve a ejecutar este instalador.',
      mbCriticalError, MB_OK);
    Result := False;
  end;
end;

procedure InitializeWizard;
begin
  PaginaDescarga := CreateDownloadPage(SetupMessage(msgWizardPreparing), 'Descargando SQL Server LocalDB...', nil);
end;

function DescargarLocalDB(const Url: String): Boolean;
begin
  Result := False;
  PaginaDescarga.Clear;
  PaginaDescarga.Add(Url, ArchivoLocalDB, '');
  PaginaDescarga.Show;
  try
    try
      PaginaDescarga.Download;
      Result := True;
    except
      Log('No se pudo descargar ' + Url + ': ' + GetExceptionMessage);
    end;
  finally
    PaginaDescarga.Hide;
  end;
end;

function NextButtonClick(CurPageID: Integer): Boolean;
begin
  Result := True;

  // Al pulsar "Instalar": si falta LocalDB se descarga antes de copiar los archivos
  if (CurPageID = wpReady) and not LocalDBInstalado then
  begin
    if DescargarLocalDB(UrlLocalDB2022) or DescargarLocalDB(UrlLocalDB2019) then
      InstalarLocalDB := True
    else
    begin
      InstalarLocalDB := False;
      Result := MsgBox('No se pudo descargar SQL Server LocalDB, necesario para la base de datos.' + #13#10#13#10 +
        'Comprueba tu conexión a Internet. Si continúas, se instalará solo la aplicación y tendrás que instalar ' +
        'SQL Server Express LocalDB manualmente antes de abrirla.' + #13#10#13#10 +
        '¿Deseas continuar de todos modos?', mbConfirmation, MB_YESNO) = IDYES;
    end;
  end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
var
  CodigoResultado: Integer;
  Argumentos: String;
begin
  if (CurStep = ssPostInstall) and InstalarLocalDB then
  begin
    WizardForm.StatusLabel.Caption := 'Instalando SQL Server LocalDB (puede tardar unos minutos)...';
    WizardForm.ProgressGauge.Style := npbstMarquee;
    try
      Argumentos := '/i "' + ExpandConstant('{tmp}\' + ArchivoLocalDB) + '" /qn /norestart IACCEPTSQLLOCALDBLICENSETERMS=YES';

      // 0 = correcto, 3010 = correcto (requiere reiniciar), 1638 = ya hay otra versión instalada
      if not Exec(ExpandConstant('{sys}\msiexec.exe'), Argumentos, '', SW_HIDE, ewWaitUntilTerminated, CodigoResultado)
        or ((CodigoResultado <> 0) and (CodigoResultado <> 3010) and (CodigoResultado <> 1638)) then
        MsgBox('La aplicación se instaló, pero no se pudo instalar SQL Server LocalDB (código ' + IntToStr(CodigoResultado) + ').' + #13#10#13#10 +
          'Instálalo manualmente desde https://aka.ms/sqlexpress (SQL Server Express LocalDB) antes de abrir Muebles Keyda.',
          mbError, MB_OK);
    finally
      WizardForm.ProgressGauge.Style := npbstNormal;
    end;
  end;
end;
