Windows Installer XML (WiX) toolset
http://wix.sourceforge.net/

What to do when the application change version
-----------------------------------------------
- Copy the assembly version of the main application, such as "0.1.3272".
- Replace it inside "MillionBeautySetup.wxs" file.
- Using power shell (vps) to execute "BuildSetup.bat" file.
- Rename "MillionBeautySetup.msi" to "MillionBeautySetup-0.1.3272.msi" file.

0.1.3272
- allow change company name, company register number, company address and contacts.
