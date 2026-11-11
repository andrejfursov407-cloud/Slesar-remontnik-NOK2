\
@echo off
chcp 65001 >nul
cd /d "%~dp0"
echo ================================================
echo   Сборка приложения "Слесарь-ремонтник НОК"
echo ================================================
where dotnet >nul 2>nul
if errorlevel 1 (
  echo.
  echo .NET 8 SDK не найден.
  echo Установите .NET 8 SDK: https://dotnet.microsoft.com/download/dotnet/8.0
  echo Затем снова запустите этот BAT-файл.
  pause
  exit /b 1
)
dotnet publish SlesarRemontnik.csproj -c Release -r win-x64 --self-contained true ^
  -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true ^
  -p:EnableCompressionInSingleFile=true -o "Готовая_программа"
if errorlevel 1 (
  echo.
  echo Сборка завершилась с ошибкой. Проверьте сообщения выше.
  pause
  exit /b 1
)
echo.
echo ГОТОВО! Программа находится в папке:
echo "%~dp0Готовая_программа"
echo Запускайте файл "Слесарь-ремонтник НОК.exe"
echo HTML-файл должен лежать рядом с EXE.
pause
