# AdminCon CLI - PizzaCake Package Manager - Package Locator File

[Global Config]

###########################################################################
# ATTENTION!                                                              #
# 1. Always use single-back-slash. It's easier for the program to analyze.#
# 2. No double quotes ("), spaces or semicolons (;) are allowed here.     #
# 3. Absolute path only.                                                  #
###########################################################################

SaveLocation=C:\packages
AutoInstall=true

[Mirror Servers]
# Basic information of the most popular world-wide mirror servers.

#China
@{
  "清华大学开源软件镜像站|People's Republic of China",
  "https://mirrors.tuna.tsinghua.edu.cn/",
  type="Academy"
}
@{
  "阿里巴巴开源镜像站|People's Republic of China",
  "https://developer.aliyun.com/mirror/",
  type="Commerce"
}
@{"中国科学技术大学开源软件镜像站|People's Republic of China",
"http://mirrors.ustc.edu.cn/",
type="Academy"

}

#United States
@{
  "Oregon State University Open-Source Lab|United States of America",
  "http://ftp.osuosl.org/pub/",
  type="Academy"
}
@{
  "SIPB Mirrors of MIT|UnitedStates of America",
  "http://mirrors.mit.edu/",
  type="Academy"
}
@{
  "The Columbia University Software Archives|United States of America",
  "http://mirror.cc.columbia.edu/",
  type="Academy"
}
@{
  "Carnegie Mellon University Computer Club|United States of America",
  "http://www.club.cc.cmu.edu/pub/",
  type="Academy"
}

#Canada
@{
  "Computer Science Club of the University of Waterloo|Canada",
  "http://mirror.cs.uwaterloo.ca/",
  type="Academy"
}

#Japan
@{
  "北陸先端科学技術大学院大学|Japan",
  "http://ftp.jaist.ac.jp/pub/",
  type="Academy"
}

#Deutschland
@{
  "Georg-August-Universität Göttingen|Federal Republic of Germany",
  "http://ftp.gwdg.de/pub/",
  type="Academy"
}

[Package Install]

# Microsoft .NET
{dotnetfx3,https://download.microsoft.com/download/2/0/E/20E90413-712F-438C-988E-FDAA79A8AC3D/dotnetfx35.exe}
{dotnetfx3.5,https://download.microsoft.com/download/2/0/E/20E90413-712F-438C-988E-FDAA79A8AC3D/dotnetfx35.exe}
{dotnetfx4,https://download.microsoft.com/download/1/B/E/1BE39E79-7E39-46A3-96FF-047F95396215/dotNetFx40_Full_setup.exe}
{dotnetfx4.5,https://download.microsoft.com/download/B/A/4/BA4A7E71-2906-4B2D-A0E1-80CF16844F5F/dotNetFx45_Full_setup.exe}
{dotnetcore2.1,https://download.visualstudio.microsoft.com/download/pr/b009808d-e1cc-4d88-b48d-7f465c361d22/8546c452b57896f6ebbdfac1d047f8b6/dotnet-runtime-2.1.30-win-x64.exe}
{dotnetcore2.1sdk,https://download.visualstudio.microsoft.com/download/pr/fdc2c572-1f7f-4d46-b767-dd0951d10865/ad32c09fbef96146ec6b763d0192fba7/dotnet-sdk-2.1.818-win-x64.exe}
{dotnetcore3.1,https://download.visualstudio.microsoft.com/download/pr/3f56df9d-6dc0-4897-a49b-ea891f9ad0f4/076e353a29908c70e24ba8b8d0daefb8/windowsdesktop-runtime-3.1.21-win-x64.exe}
{dotnetcore3.1sdk,https://download.visualstudio.microsoft.com/download/pr/a7555bf3-426c-499c-8431-ef3448c64da6/8d8f9cb4451564dcb86119c79ea3ee64/dotnet-sdk-3.1.415-win-x64.exe}
{dotnet5RT,https://download.visualstudio.microsoft.com/download/pr/1daf85dc-291b-4bb8-812e-a0df5cdb6701/85455a4a851347de26e2901e043b81e1/windowsdesktop-runtime-5.0.12-win-x64.exe}
{dotnet6RT,https://download.visualstudio.microsoft.com/download/pr/a865ccae-2219-4184-bcd6-0178dc580589/ba452d37e8396b7a49a9adc0e1a07e87/windowsdesktop-runtime-6.0.0-win-x64.exe}
{dotnet5sdk,https://download.visualstudio.microsoft.com/download/pr/5303da13-69f7-407a-955a-788ec4ee269c/dc803f35ea6e4d831c849586a842b912/dotnet-sdk-5.0.403-win-x64.exe}
{dotnet6sdk,https://download.visualstudio.microsoft.com/download/pr/0f71eaf1-ce85-480b-8e11-c3e2725b763a/9044bfd1c453e2215b6f9a0c224d20fe/dotnet-sdk-6.0.100-win-x64.exe}

# Visual C++
{vc++2005,https://download.microsoft.com/download/8/B/4/8B42259F-5D70-43F4-AC2E-4B208FD8D66A/vcredist_x86.EXE}
{vc++2005x64,https://download.microsoft.com/download/8/B/4/8B42259F-5D70-43F4-AC2E-4B208FD8D66A/vcredist_x64.EXE};
{vc++2008,https://download.microsoft.com/download/5/D/8/5D8C65CB-C849-4025-8E95-C3966CAFD8AE/vcredist_x86.exe}
{vc++2008x64,https://download.microsoft.com/download/5/D/8/5D8C65CB-C849-4025-8E95-C3966CAFD8AE/vcredist_x64.exe}
{vc++2010,https://download.microsoft.com/download/1/6/5/165255E7-1014-4D0A-B094-B6A430A6BFFC/vcredist_x86.exe}
{vc++2010x64,https://download.microsoft.com/download/1/6/5/165255E7-1014-4D0A-B094-B6A430A6BFFC/vcredist_x64.exe}
{vc++2012,https://download.microsoft.com/download/1/6/B/16B06F60-3B20-4FF2-B699-5E9B7962F9AE/VSU_4/vcredist_x86.exe}
{vc++2012x64,https://download.microsoft.com/download/1/6/B/16B06F60-3B20-4FF2-B699-5E9B7962F9AE/VSU_4/vcredist_x64.exe}
{vc++2013,https://download.microsoft.com/download/2/E/6/2E61CFA4-993B-4DD4-91DA-3737CD5CD6E3/vcredist_x86.exe}
{vc++2013x64,https://download.microsoft.com/download/2/E/6/2E61CFA4-993B-4DD4-91DA-3737CD5CD6E3/vcredist_x64.exe}
{vc++2015,https://download.microsoft.com/download/9/3/F/93FCF1E7-E6A4-478B-96E7-D4B285925B00/vc_redist.x86.exe}
{vc++2015x64,https://download.microsoft.com/download/9/3/F/93FCF1E7-E6A4-478B-96E7-D4B285925B00/vc_redist.x64.exe}

# Python
{python2.7,https://www.python.org/ftp/python/2.7.18/python-2.7.18.amd64.msi}
{python3.8,https://www.python.org/ftp/python/3.8.3/python-3.8.3-amd64.exe}

# Java
{openjre8x64,https://mirrors.tuna.tsinghua.edu.cn/AdoptOpenJDK/8/jre/x64/windows/OpenJDK8U-jre_x64_windows_openj9_windowsXL_8u282b08_openj9-0.24.0.msi}
{openjre8x86,https://mirrors.tuna.tsinghua.edu.cn/AdoptOpenJDK/8/jre/x32/windows/OpenJDK8U-jre_x86-32_windows_hotspot_8u312b07.msi}
{openjdk-8,https://builds.openlogic.com/downloadJDK/openlogic-openjdk/8u262-b10/openlogic-openjdk-8u262-b10-windows-x64.msi}
{openjdk-11,https://builds.openlogic.com/downloadJDK/openlogic-openjdk/11.0.8%2B10/openlogic-openjdk-11.0.8%2B10-windows-x64.msi}

# Golang
{golang,https://golang.google.cn/dl/go1.17.3.windows-amd64.msi}

# Microsoft SQL Server
{mssql-2008sp2x64,https://download.microsoft.com/download/0/4/B/04BE03CD-EAF3-4797-9D8D-2E08E316C998/SQLEXPRADV_x64_ENU.exe}
{mssql-2008sp2x64,https://download.microsoft.com/download/0/4/B/04BE03CD-EAF3-4797-9D8D-2E08E316C998/SQLEXPRADV_x86_ENU.exe}
{mssql-2012sp2x64,https://download.microsoft.com/download/0/1/E/01E0D693-2B4F-4442-9713-27A796B327BD/SQLEXPRADV_x64_ENU.exe}
{mssql-2012sp2x86,https://download.microsoft.com/download/0/1/E/01E0D693-2B4F-4442-9713-27A796B327BD/SQLEXPRADV_x86_ENU.exe}
{ssms-2008x64,https://download.microsoft.com/download/0/4/B/04BE03CD-EAF3-4797-9D8D-2E08E316C998/SQLManagementStudio_x64_ENU.exe}
{ssms-2008x86,https://download.microsoft.com/download/0/4/B/04BE03CD-EAF3-4797-9D8D-2E08E316C998/SQLManagementStudio_x86_ENU.exe}
{ssms-2012x64,https://download.microsoft.com/download/0/1/E/01E0D693-2B4F-4442-9713-27A796B327BD/SQLManagementStudio_x64_ENU.exe}
{ssms-2012x86,https://download.microsoft.com/download/0/1/E/01E0D693-2B4F-4442-9713-27A796B327BD/SQLManagementStudio_x86_ENU.exe}

# VSCode
{vscodium,https://github.com/VSCodium/vscodium/releases/download/1.62.2/VSCodium-ia32-1.62.2.msi}

# JetBrains
{intellij-idea,https://download.jetbrains.com/idea/ideaIC-2021.2.3.exe}
{pycharm,https://download.jetbrains.com/python/pycharm-community-2021.2.3.exe}
{webstorm,https://download.jetbrains.com/webstorm/WebStorm-2021.2.3.exe}

#Git
{git64,https://github.com/git-for-windows/git/releases/download/v2.34.0.windows.1/Git-2.34.0-64-bit.exe}
{git32,https://github.com/git-for-windows/git/releases/download/v2.34.0.windows.1/Git-2.34.0-32-bit.exe}

# Virtual Machines
{vmware,https://www.vmware.com/go/getworkstation-win?.exe}
{virtualbox,https://download.virtualbox.org/virtualbox/6.1.30/VirtualBox-6.1.30-148432-Win.exe}

# Editors
{typora,https://typora.io/windows/typora-setup-x64.exe}
{gvim,https://ftp.nluug.nl/pub/vim/pc/gvim82.exe}
{emacs,http://ftp.gnu.org/gnu/emacs/windows/emacs-27/emacs-27.1-i686-installer.exe}

[End of Document]