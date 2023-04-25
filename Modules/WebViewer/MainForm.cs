/**
 * Easy WebView
 * Author: Itaru Otaku, koizuminankaze@gmail.com
 * Feature Created at Nov.17th, 2021, TargetVersion = v8.0beta, Architecture = dotnetfx4.8
 * 
 * Ontario Tech Univ.
 **/
using Microsoft.Win32;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/* AdminCon 6.0 Command Line Interface Edition - Source Code - MainForm.cs
 * Intro: Main Windows Form for WebViewer.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.WebViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SetWebBrowserFeatures(11);
            this.webBrowser.ScriptErrorsSuppressed = true;
            this.webBrowser.Navigate("https://bing.com");
        }

        static void SetWebBrowserFeatures(Int32 ieVersion)
        {
            // don't change the registry if running in-proc inside Visual Studio  
            if (LicenseManager.UsageMode != LicenseUsageMode.Runtime)
                return;
            //Get program and its name
            var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            //Get browser 
            UInt32 ieMode = GetEmulationMode(ieVersion);
            var featureControlRegKey = @"HKEY_CURRENT_USER\Software\
Internet Explorer\Main\FeatureControl\"; 
            Registry.SetValue(featureControlRegKey + "FEATURE_BROWSER_EMULATION",
                appName, ieMode, RegistryValueKind.DWord);
            // enable the features which are "On" for the full Internet Explorer browser  
            Registry.SetValue(featureControlRegKey + "FEATURE_ENABLE_CLIPCHILDREN_OPTIMIZATION",
                appName, 1, RegistryValueKind.DWord);
        }
        /// <summary>  
        /// Get Browser Version 
        /// </summary>  
        /// <returns></returns>  
        static Int32 GetBrowserVersion()
        {
            Int32 browserVersion = 0;
            using (var ieKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer",
                RegistryKeyPermissionCheck.ReadSubTree,
                System.Security.AccessControl.RegistryRights.QueryValues))
            {
                var version = ieKey.GetValue("svcVersion");
                if (null == version)
                {
                    version = ieKey.GetValue("Version");
                    if (null == version)
                        throw new ApplicationException("Microsoft Internet Explorer is required!");
                }
                Int32.TryParse(version.ToString().Split('.')[0], out browserVersion);
            }
            if (browserVersion < 7)
            {
                throw new ApplicationException("UnSupported Browser Version.");
            }
            return browserVersion;
        }
        /// <summary>  
        /// BrowserVersion -> Mode
        /// </summary>  
        /// <param name="browserVersion"></param>  
        /// <returns></returns>  
        static UInt32 GetEmulationMode(Int32 browserVersion)
        {
            UInt32 mode = 11000; // Internet Explorer 11. Webpages containing standards-based !DOCTYPE directives are displayed in IE11 Standards mode.   
            switch (browserVersion)
            {
                case 7:
                    mode = 7000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE7 Standards mode.   
                    break;
                case 8:
                    mode = 8000; // Webpages containing standards-based !DOCTYPE directives are displayed in IE8 mode.   
                    break;
                case 9:
                    mode = 9000; // Internet Explorer 9. Webpages containing standards-based !DOCTYPE directives are displayed in IE9 mode.                      
                    break;
                case 10:
                    mode = 10000; // Internet Explorer 10.  
                    break;
                case 11:
                    mode = 11000; // Internet Explorer 11  
                    break;
            }
            return mode;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            this.webBrowser.Navigate(this.browseLinkTextBox.Text);
        }

        private void browseLinkTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                browseButton_Click(sender, e);
            }
        }
    }
}