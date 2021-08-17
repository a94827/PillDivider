REM Создание программы для крыс
REM Должно вызываться после __save

cd BIN\Debug

REM Собираем архив для будущего инсталлятора
7za.exe a _setup.7z PillDivider.exe ExtTools.dll ExtForms.dll

REM Создаем инсталлятор
COPY /B ..\..\7zsd_All.sfx + ..\..\sfxcfg.txt + _setup.7z ..\..\PillDividerSetup.exe

REM Удаляем ненужные файлы
DEL _setup.7z
cd ..\..
