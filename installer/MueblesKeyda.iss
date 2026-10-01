; Instalador de Muebles Keyda (Inno Setup 6)
;
; Antes de compilar hay que generar la aplicación en Release:
;   MSBuild Vista\Vista.csproj /p:Configuration=Release
; Luego compilar este script con ISCC.exe (o con el script installer\build.ps1).
; El instalador queda en installer\Output\MueblesKeydaSetup.exe

#define AppName "Muebles Keyda"
#define AppVersion "1.0.2"
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

  // Microsoft Edge WebView2 Runtime (lo usa la vista previa de cotizaciones). Instalador oficial "Evergreen".
  UrlWebView2 = 'https://go.microsoft.com/fwlink/p/?LinkId=2124703';
  ArchivoWebView2 = 'MicrosoftEdgeWebview2Setup.exe';
  ClaveWebView2 = 'SOFTWARE\Microsoft\EdgeUpdate\Clients\{F3017226-FE2A-4295-8BDF-00C3A9A7E4C5}';

function LocalDBInstalado: Boolean;
var
  Versiones: TArrayOfString;
begin
#ifdef PRUEBA_DESCARGAS
  Result := False;
#else
  Result := RegGetSubkeyNames(HKLM, 'SOFTWARE\Microsoft\Microsoft SQL Server Local DB\Installed Versions', Versiones)
    and (GetArrayLength(Versiones) > 0);
#endif
end;

function WebView2Instalado: Boolean;
var
  Version: String;
begin
#ifdef PRUEBA_DESCARGAS
  Result := False;
#else
  Result := (RegQueryStringValue(HKLM32, ClaveWebView2, 'pv', Version) or RegQueryStringValue(HKCU, ClaveWebView2, 'pv', Version))
    and (Version <> '') and (Version <> '0.0.0.0');
#endif
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
    SuppressibleMsgBox('Muebles Keyda necesita .NET Framework 4.7.2 o superior, que no está instalado en este equipo.' + #13#10#13#10 +
      'Instálalo desde https://dotnet.microsoft.com/download/dotnet-framework y vuelve a ejecutar este instalador.',
      mbCriticalError, MB_OK, IDOK);
    Result := False;
  end;
end;

procedure MostrarEstado(const Texto: String);
begin
  Log(Texto);
  if not WizardSilent then
    WizardForm.StatusLabel.Caption := Texto;
end;

function ProgresoDescarga(const Url, NombreArchivo: String; const Progreso, ProgresoMax: Int64): Boolean;
begin
  if (not WizardSilent) and (ProgresoMax > 0) then
  begin
    WizardForm.ProgressGauge.Style := npbstNormal;
    WizardForm.ProgressGauge.Max := 100;
    WizardForm.ProgressGauge.Position := Integer((Progreso * 100) div ProgresoMax);
  end;
  Result := True;
end;

function Descargar(const Url, Archivo: String): Boolean;
begin
  Result := False;
  try
    DownloadTemporaryFile(Url, Archivo, '', @ProgresoDescarga);
    Result := True;
  except
    Log('No se pudo descargar ' + Url + ': ' + GetExceptionMessage);
  end;
end;

// Ejecuta un instalador externo esperando a que termine. Devuelve el código de salida (-1 si no se pudo ejecutar).
function EjecutarEspera(const Archivo, Parametros: String): Integer;
var
  Codigo: Integer;
begin
  if not Exec(Archivo, Parametros, '', SW_HIDE, ewWaitUntilTerminated, Codigo) then
    Codigo := -1;
  Result := Codigo;
end;

procedure InstalarLocalDB;
var
  Codigo: Integer;
  Descargado: Boolean;
begin
  MostrarEstado('Descargando SQL Server LocalDB...');

  Descargado := Descargar(UrlLocalDB2022, ArchivoLocalDB);
  if not Descargado then
    Descargado := Descargar(UrlLocalDB2019, ArchivoLocalDB);

  if not Descargado then
  begin
    SuppressibleMsgBox('No se pudo descargar SQL Server LocalDB, necesario para la base de datos.' + #13#10#13#10 +
      'La aplicación se instalará, pero deberás instalar SQL Server Express LocalDB manualmente ' +
      '(https://aka.ms/sqlexpress) antes de abrirla. Comprueba tu conexión a Internet.', mbError, MB_OK, IDOK);
    Exit;
  end;

#ifdef PRUEBA_DESCARGAS
  Log('PRUEBA: descarga de LocalDB correcta (' + ExpandConstant('{tmp}\' + ArchivoLocalDB) + '); se omite msiexec.');
  Exit;
#endif

  MostrarEstado('Instalando SQL Server LocalDB (puede tardar unos minutos)...');
  if not WizardSilent then
    WizardForm.ProgressGauge.Style := npbstMarquee;
  try
    // 0 = correcto, 3010 = correcto (requiere reiniciar), 1638 = ya hay otra versión instalada
    Codigo := EjecutarEspera(ExpandConstant('{sys}\msiexec.exe'),
      '/i "' + ExpandConstant('{tmp}\' + ArchivoLocalDB) + '" /qn /norestart IACCEPTSQLLOCALDBLICENSETERMS=YES');
    Log('msiexec LocalDB: código ' + IntToStr(Codigo));

    if (Codigo <> 0) and (Codigo <> 3010) and (Codigo <> 1638) then
      SuppressibleMsgBox('No se pudo instalar SQL Server LocalDB (código ' + IntToStr(Codigo) + ').' + #13#10#13#10 +
        'La aplicación se instalará, pero deberás instalar SQL Server Express LocalDB manualmente ' +
        '(https://aka.ms/sqlexpress) antes de abrirla.', mbError, MB_OK, IDOK);
  finally
    if not WizardSilent then
      WizardForm.ProgressGauge.Style := npbstNormal;
  end;
end;

procedure InstalarWebView2;
var
  Codigo: Integer;
begin
  MostrarEstado('Descargando Microsoft Edge WebView2...');

  if not Descargar(UrlWebView2, ArchivoWebView2) then
  begin
    SuppressibleMsgBox('No se pudo descargar Microsoft Edge WebView2, necesario para la vista previa de cotizaciones.' + #13#10#13#10 +
      'La aplicación se instalará; la vista previa funcionará cuando instales WebView2 Runtime ' +
      '(https://go.microsoft.com/fwlink/p/?LinkId=2124703).', mbInformation, MB_OK, IDOK);
    Exit;
  end;

  MostrarEstado('Instalando Microsoft Edge WebView2...');
  if not WizardSilent then
    WizardForm.ProgressGauge.Style := npbstMarquee;
  try
    Codigo := EjecutarEspera(ExpandConstant('{tmp}\' + ArchivoWebView2), '/silent /install');
    Log('WebView2 Runtime: código ' + IntToStr(Codigo));

    if Codigo <> 0 then
      SuppressibleMsgBox('No se pudo instalar Microsoft Edge WebView2 (código ' + IntToStr(Codigo) + ').' + #13#10#13#10 +
        'La vista previa de cotizaciones no funcionará hasta instalar WebView2 Runtime ' +
        '(https://go.microsoft.com/fwlink/p/?LinkId=2124703).', mbInformation, MB_OK, IDOK);
  finally
    if not WizardSilent then
      WizardForm.ProgressGauge.Style := npbstNormal;
  end;
end;

procedure CurStepChanged(CurStep: TSetupStep);
begin
  // Antes de copiar los archivos se instalan los componentes que falten (necesitan Internet solo si faltan)
  if CurStep = ssInstall then
  begin
    if not LocalDBInstalado then
      InstalarLocalDB;

    if not WebView2Instalado then
      InstalarWebView2;
  end;
end;
