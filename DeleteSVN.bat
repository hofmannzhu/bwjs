@echo off
:start
::启动过程，切换目录
set pwd=%cd%
cd %1
echo 工作目录是：& chdir

@echo on
@if exist ".settings" rd /s /q ".settings"
@if exist ".project" del /f /s /q ".project"
@if exist ".buildpath" del /f /s /q ".buildpath"
@for /r . %%a in (.) do @if exist "%%a\.svn" rd /s /q "%%a\.svn"
@echo off

pause 
 
