@echo off
:start
::�������̣��л�Ŀ¼
set pwd=%cd%
cd %1
echo ����Ŀ¼�ǣ�& chdir

@echo on
@if exist ".settings" rd /s /q ".settings"
@if exist ".project" del /f /s /q ".project"
@if exist ".buildpath" del /f /s /q ".buildpath"
@for /r . %%a in (.) do @if exist "%%a\.svn" rd /s /q "%%a\.svn"
@echo off

pause 
 
