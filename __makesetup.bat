REM �������� �ணࠬ�� ��� ����
REM ������ ��뢠���� ��᫥ __save

cd BIN\Debug

REM ����ࠥ� ��娢 ��� ���饣� ���⠫����
7za.exe a _setup.7z PillDivider.exe ExtTools.dll ExtForms.dll

REM ������� ���⠫����
COPY /B ..\..\7zsd_All.sfx + ..\..\sfxcfg.txt + _setup.7z ..\..\PillDividerSetup.exe

REM ����塞 ���㦭� 䠩��
DEL _setup.7z
cd ..\..
