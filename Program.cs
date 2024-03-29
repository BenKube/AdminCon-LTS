﻿/**AdminCon - A Command-Line Shell for Windows.
 * Base Platform: .NET Framework 4.0, .NET Core 3.0 LTS
 * Target System: Windows Server 2008 (With .NET 4 Installed) ~ 2022
 * Target NT Kernel Version: Higher than NT 6.1
 * (c) 2017-2022 Project Amadeus. All right reserved.*/
using System;

using AdminCon_CLI_dotnetEdition;
using AdminCon_CLI_dotnetEdition.Components;
using AdminCon_CLI_dotnetEdition.Components.Command;
using AdminCon_CLI_dotnetEdition.Components.Configuration;
using AdminCon_CLI_dotnetEdition.Components.ConsoleDisplay;
using AdminCon_CLI_dotnetEdition.Components.Entities;
using AdminCon_CLI_dotnetEdition.Components.FileManagement;
using AdminCon_CLI_dotnetEdition.Components.@Global;
using AdminCon_CLI_dotnetEdition.Components.Modes;
using AdminCon_CLI_dotnetEdition.Components.Processes;
using AdminCon_CLI_dotnetEdition.Components.Sound;
using AdminCon_CLI_dotnetEdition.Components.SystemUtils;
using AdminCon_CLI_dotnetEdition.Components.UI;
using AdminCon_CLI_dotnetEdition.Components.Widgets;
using AdminCon_CLI_dotnetEdition.Components.Win32;
/* AdminCon 8.0 Command Line Interface Edition - Source Code - Program.cs
* Intro: The entry point.
* Architecture: .NET Core 3.x & .NET Framework 4.x
* (c) 2017-2021 Project Amadeus. All rights reserved.*/


                          /***********************************************************                       "Live on grass,
                           * Author: Ziyi Wang - @Reddit  u/wHyUhAcKmyPC             *                       never get bugs!"
                           *                   - @zhihu   Itaru Otaku                *        \        /     /
                           *                   - @Gitee   ItaruOtaku                 *      |  -    -    |  /
                           *                   - @Github  ItaruOtaku                 *      |  0    0    |  
                           *                   - @Google  koizuminankaze@gmail.com   *      |            |
                           *                                                         *      |____W_______|
                           * Contact Us:                                             *          |      |
                           * Project Amadeus Mailbox: dev.projectamadeus@outlook.com *          |      |
                           *                          dev_projectamadeus@163.com     *          |      |________________
                           *                                                         *          |                      |
                           *                                                         *          |______________________|
                           *               Thank you for using our code!             *             |_|           |_|
                           ***********************************************************/

namespace AdminCon_CLI_dotnetEdition
{
    /// <summary>
    /// Program entry
    /// </summary>
    class Program
    {
        public Daemon daemon = Daemon.GetInstance(); //Daemon
        [STAThread]
        static void Main(String[] args) //Program Entry @ Program.cs
        {
            Console.OutputEncoding = System.Text.Encoding.Default;
            Load                  loader        = new Load();
            SafemodeStartup       AdminCon_safe = new SafemodeStartup();
            Startup               AdminCon      = new Startup();
            ScriptMode            interpreter   = new ScriptMode();
            //Add the current workspace.
            String dllDirectory = @"./";
            Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + dllDirectory);
            try
            {
                if (args.Length == 0)
                {
                    //Normal startup(No args):
                    Console.Title = "Loading...";
                    try
                    {
                        Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Security.ObjectDiag.SetNull(AdminCon);
                        Console.ForegroundColor = ConsoleColor.White; 
                        AdminCon.Run(true);
                    }
                    catch (Exception) { }
                }
                else if (args[0].ToUpper() == "-S") //Safe mode
                {
                    Console.Title = "Loading...";
                    try
                    {
                        Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Security.ObjectDiag.SetNull(AdminCon_safe);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        AdminCon_safe.saferun(true);
                    }
                    catch (Exception) { }
                }
                else if (args[0].ToUpper() == "-UI")//UI Mode
                {
                    UserInterface UI = new UserInterface();
                    UI.UIWindow_StartInNewThread();
                }
                else if (args[0].ToUpper() == "-INFO") //View info
                {
                    About infoWindow = new About();
                    infoWindow.ShowDialog();
                }
                else if (args[0].ToUpper() == "-W32")//Win32 mode
                {
                    try
                    {
                        System.Diagnostics.Process.Start(".\\tools\\acwin32.exe");
                    }
                    catch (Exception ex) { ConsoleHL.WriteErrorLine(ex.Message); }
                    return;
                }
                else if (args[0].ToUpper() == "/?" || args[0].ToUpper() == "-H") //View help: "ac /?"
                {
                    loader.help();
                    About infoWindow = new About();
                }
                else if (args[0].ToUpper() == "-INFO") //About: "ac  -info"
                {
                    loader.help();
                    About infoWindow = new About();
                }
                else if (args[args.Length-1].ToUpper().Contains(".ACS"))
                {
                    interpreter.ShellExecute(args[args.Length - 1]);
                }
                else
                {
                    loader.ErrorInfo(args);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}