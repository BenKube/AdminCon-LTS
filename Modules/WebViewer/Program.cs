/**
 * Easy WebView
 * Author: Itaru Otaku, koizuminankaze@gmail.com
 * Feature Created at Nov.17th, 2021, TargetVersion = v8.0beta, Architecture = dotnetfx4.8
 * 
 * Ontario Tech Univ.
 **/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
/* AdminCon 6.0 Command Line Interface Edition - Source Code - Program.cs
 * Intro: The class that launches program.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.WebViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
