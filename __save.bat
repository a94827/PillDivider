DEL /S /Q RESULT > nul

if exist src.7z del src.7z
7za.exe a -r src.7z *.sln *.cs *.resx *.csproj *.user *.ico *.bat sfxcfg.txt app.config LICENSE README.md .gitignore
7za.exe a src.7z *.sfx *.txt

if exist exe.7z del exe.7z
cd BIN\Debug
7za.exe a ..\..\exe.7z PillDivider.exe *.dll
cd ..\..



