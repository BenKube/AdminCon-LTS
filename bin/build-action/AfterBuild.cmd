@echo off
del /f /s /q ..\..\resources\acinstall\*.exe
del /f /s /q ..\..\resources\acinstall\*.dll
xcopy ..\ac.exe ..\..\resources\acinstall\ /y
xcopy ..\*.dll ..\..\resources\acinstall\ /y
xcopy ..\tools\*.exe ..\..\resources\acinstall\tools\ /y
xcopy ..\config\*.acfg ..\..\resources\acinstall\config\ /y
xcopy ..\tools\*.pml ..\..\resources\acinstall\tools\ /y
exit
