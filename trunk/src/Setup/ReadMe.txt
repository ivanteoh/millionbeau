Windows Installer XML (WiX) toolset
http://wix.sourceforge.net/

New Release
***********
- Copy the assembly version of the main application, such as "1.0".
- Replace it inside "MillionBeautySetup.wxs" file.

Generate Setup File
*******************
- Using power shell (vps) to execute "BuildSetup.bat" file.

Test Uninstall
**************
- Using power shell (vps) to execute "Uninstall.bat" file.

Publish to Web Site
*******************
- Rename "MillionBeautySetup.msi" to "MillionBeautySetup-1.0.msi" file before publish to the web site.
