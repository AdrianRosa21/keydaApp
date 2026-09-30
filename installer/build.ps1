# Genera la aplicación en Release y compila el instalador (installer\Output\MueblesKeydaSetup.exe).
# Requisitos: Visual Studio / Build Tools (MSBuild) e Inno Setup 6.
#   winget install --id JRSoftware.InnoSetup -e

$ErrorActionPreference = 'Stop'
$raiz = Split-Path -Parent $PSScriptRoot

$msbuild = & "${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" -latest -products * `
    -requires Microsoft.Component.MSBuild -find 'MSBuild\**\Bin\MSBuild.exe' | Select-Object -First 1
if (-not $msbuild) { throw 'No se encontró MSBuild. Instala Visual Studio o Build Tools.' }

$iscc = @(
    "$env:LOCALAPPDATA\Programs\Inno Setup 6\ISCC.exe",
    "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe",
    "$env:ProgramFiles\Inno Setup 6\ISCC.exe"
) | Where-Object { Test-Path $_ } | Select-Object -First 1
if (-not $iscc) { throw 'No se encontró Inno Setup 6 (ISCC.exe).' }

& $msbuild "$raiz\Vista\Vista.csproj" /restore /p:Configuration=Release /p:Platform=AnyCPU /v:minimal /nologo
if ($LASTEXITCODE -ne 0) { throw 'Falló la compilación de la aplicación.' }

& $iscc "$PSScriptRoot\MueblesKeyda.iss"
if ($LASTEXITCODE -ne 0) { throw 'Falló la compilación del instalador.' }

Write-Host "`nListo: $PSScriptRoot\Output\MueblesKeydaSetup.exe"
