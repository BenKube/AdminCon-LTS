using System;
using System.Diagnostics;

using AdminCon_CLI_dotnetEdition.Components.Command;
using AdminCon_CLI_dotnetEdition.Components.Configuration;
using AdminCon_CLI_dotnetEdition.Components.ConsoleDisplay;
using AdminCon_CLI_dotnetEdition.Components.Entities;
using AdminCon_CLI_dotnetEdition.Components.FileManagement;
using AdminCon_CLI_dotnetEdition.Components.@Global;
using AdminCon_CLI_dotnetEdition.Components.Processes;
using AdminCon_CLI_dotnetEdition.Components.Sound;
using AdminCon_CLI_dotnetEdition.Components.SystemUtils;
using AdminCon_CLI_dotnetEdition.Components.UI;
using AdminCon_CLI_dotnetEdition.Components.Widgets;
using AdminCon_CLI_dotnetEdition.Components.Win32;
/* AdminCon 8.0 Command Line Interface Edition - Source Code - Safemode.cs
* Intro: CLI in safemode
* Architecture: .NET Core 3.x & .NET Framework 4.x
* (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Modes
{
    /// <summary>
    /// Safemode
    /// </summary>
    class SafemodeCLI : ConsoleIO
    {
        #region Create readonly instances
        readonly GrammarAnalyzer    grammarAnalyzer     =    new     GrammarAnalyzer();
        readonly ProcessAlgorithms  processAlgorithms   =    new   ProcessAlgorithms();
        readonly PrintOSInfo        systemInfo          =    new         PrintOSInfo();
        readonly ProcessQuery       processQuery        =    new        ProcessQuery();
        readonly DiskOps            disk                =    new             DiskOps();
        readonly NotificationSounds notificationSounds  =    new  NotificationSounds();
        readonly SafemodeStartup    program             =    new     SafemodeStartup();
        readonly UserInterface      userInterface       =    new       UserInterface();
        #endregion
        private void PromptMsg_BadCommand()
        {
            String BAD_COMMAND_MSG = "Error - Bad Command.";
            Console.WriteLine(BAD_COMMAND_MSG);
            notificationSounds.BeepBadCommand();
        }
        private void PromptMsg_NotAllowedInSafemode()
        {
            String BAD_COMMAND_MSG = "The current operation is not allowed in safemode.\n";
            Console.WriteLine(BAD_COMMAND_MSG);
            notificationSounds.BeepBadCommand();
        }
        #region System Signals Sender
        private void Shutdown(Int32 secs)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("shutdown.exe", "-s -t " + secs);
            p.Start();
        }
        private void Reboot(Int32 secs)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("shutdown.exe", "-r -t " + secs);
            p.Start();
        }
        private void Hibernate()
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("shutdown.exe", "-h");
            p.Start();
        }
        private void LogOut()
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("shutdown.exe", "-l");
            p.Start();
        }
        #endregion
        public void ShellExecute()
        {
            System.GC.Collect(); //Try to collect garbage once per statement execution.
            Console.Write("\n\nac:safemode/cli>");
            String commands = Console.ReadLine();
            String cmdUpper = commands.ToUpper();
            #region Internal Commands
            switch (cmdUpper)
            {
                //Null input:
                case "":
                    break;
                //Help Utilities.
                case "BEEP":
                    Console.Beep(800, 200);
                    break;
                case "HELP BEEP":
                    ConsoleHL.WriteHelpLine("\n\nBEEP - The console will beep for once.\n\nArguments: none");
                    break;
                case "/?":
                case "HELP":
                    Console.WriteLine("\nCommands: ");
                    Console.WriteLine("\nKILL    RUN    TIME    GETPID    CLS    WINFO     LISP    BEEP\n\nREST    ECHO    EXIT");
                    Console.WriteLine("\nSystem Signals: ");
                    Console.WriteLine("\nSHUTDOWN    REBOOT    HIBERNATE    LOGOUT");
                    Console.WriteLine("\n\n\nParameters: "); Console.WriteLine("\n[PID]    [PNAME] and more.");
                    Console.WriteLine("\n\n\nArguments: "); Console.WriteLine("\n/S: Parameter type of String" +
                     "    /I: Parameter type of Int32");
                    Console.WriteLine("\n\n\nHELP + Command Name to view help info of this commands.\nAll commands are not case-sensitive.");
                    break;
                case "HELP INFO":
                case "INFO /?":
                    Console.WriteLine("\nINFO - View information of this program.\n\nArguments: none.");
                    break;
                case "INFO":
                    userInterface.AboutWindow_StartInNewThread();
                    break;
                case "HELP KILL":
                case "KILL /?":
                    Console.WriteLine("\nKILL - Kill a running process.\n\nArguments: \nKILL /S [PNAME] - Kill a process " +
                        "by its name.\nKILL /I [PID] - Kill a process by its PID.");
                    break;
                case "KILL":
                    Console.WriteLine("\nKILL - Kill a running process.\n\nArguments: \nKILL /S [PNAME] - Kill a process " +
                        "by its name.\nKILL /I [PID] - Kill a process by its PID.");
                    break;
                case "HELP RUN":
                case "RUN /?":
                    Console.WriteLine("\nRUN - Start a process, or open a file.\n\nArguments: \nRUN /S [PNAME] - Start a process by its name." +
                        "\nRUN /S [PATH] - Open a file in specific path.");
                    break;
                case "RUN":
                    Console.WriteLine("\nRUN - Start a process, or open a file.\n\nArguments: \nRUN /S [PNAME] - Start a process by its name." +
                        "\nRUN /S [PATH] - Open a file in specific path.");
                    break;
                case "HELP TIME":
                case "TIME /?":
                    Console.WriteLine("\nTIME - Print current time.\n\nArguments: none.");
                    break;
                case "TIME":
                    Console.WriteLine(DateTime.Now.ToString() + "\n");
                    break;
                case "HELP GETPID":
                case "GETPID /?":
                    Console.WriteLine("\nGETPID - Get Process ID by its name.\n\nArguments:\nGETPID /S [PNAME]\n");
                    break;
                case "GETPID":
                    Console.WriteLine("\nGETPID - Get Process ID by its name.\n\nArguments:\nGETPID /S [PNAME]\n");
                    break;
                case ("HELP CLS"):
                case ("CLS /?"):
                    Console.WriteLine("\nCLS - Clear the console.\n\nArguments: none.");
                    break;
                case "CLS":
                    Console.Clear();
                    break;
                case ("HELP LISP"):
                case "LISP /?":
                    ConsoleHL.WriteHelpLine("\nLISP - List all processes.\n\nUsages: \nLISP -I or LISP" +
                        " - Sort processes by id." +
                        "\nLISP -M - Sort processes by memory usage." +
                        "\n LISP -N - Sort processes by their names.");
                    break;
                case ("LISP"):
                case "LISP -I":
                    processQuery.ListProcesses(0);
                    break;
                case "LISP -M":
                    processQuery.ListProcesses(0);
                    break;
                case ("LISP -S"):
                    processQuery.ListProcesses(-1);
                    break;
                case ("HELP WINFO"):
                case "WINFO /?":
                    Console.WriteLine("\nWINFO - Print infomation of your Windows machine.\n\nArguments: none.");
                    break;
                case ("WINFO"):
                    Console.Title = "Gathering Information...";
                    systemInfo.PrintSystemInfo();
                    break;
                case "REST":
                    Console.Clear();
                    notificationSounds.BeepQuit();
                    program.saferun(false);
                    break;
                case "REST /?":
                case "HELP REST":
                    ConsoleHL.WriteHelpLine("\nREST: Restart this program.\n\nArguments: none.");
                    break;
                case "ECHO /?":
                case "HELP ECHO":
                    ConsoleHL.WriteHelpLine("\n\nECHO - Displays messages.\nArguments: ECHO [TEXT] - Display some text.");
                    break;
                case "SHUTDOWN":
                case "SHUTDOWN /?":
                case "HELP SHUTDOWN":
                    ConsoleHL.WriteHelpLine("\nSHUTDOWN - Send a shutdown signal to system.\n\nUsages: \nSHUTDOWN /I [TIME] - Shutdown the system after [TIME] seconds.");
                    break;
                case "REBOOT":
                case "REBOOT /?":
                case "HELP REBOOT":
                    ConsoleHL.WriteHelpLine("\nREBOOT - Send a reboot signal to system.\n\nUsages: \nREBOOT /I [TIME] - Reboot the system after [TIME] seconds.");
                    break;
                case "HIBERNATE":
                    this.Hibernate();
                    break;
                case "HIBERNATE /?":
                case "HELP HIBERNATE":
                    ConsoleHL.WriteHelpLine("\nHIBERNATE - Send a hibernate signal to system.\n\nUsages: none.");
                    break;
                case "LOGOUT /?":
                case "HELP LOGOUT":
                    ConsoleHL.WriteHelpLine("\nLOGOUT - Log out the current user.\n\nUsages: none.");
                    break;
                case "LOGOUT":
                    this.LogOut();
                    break;
                case "EXIT":
                    notificationSounds.BeepQuit();
                    program.exit();
                    break;
                case "EXIT /?":
                case "HELP EXIT":
                    ConsoleHL.WriteHelpLine("\nEXIT: Exit this program.\n\nArguments: none.");
                    break;
                #endregion
                #region Commands With Arguments and Fields
                default:
                    String command = grammarAnalyzer.GetCommand(cmdUpper);
                    String argument = grammarAnalyzer.GetArgument(cmdUpper);
                    String parameter = grammarAnalyzer.GetParameter(cmdUpper);
                    try
                    {
                        if (commands.StartsWith("echo"))
                        {
                            String[] kv = commands.Split(' ');
                            ConsoleHL.WriteOutput(kv[1] + "\n");
                        }
                        else if ((0 < command.Length && 3 >= command.Length) && (command.Contains(":") || command.Contains(":\\")))
                        {
                            try
                            {
                                disk.OpenDrive(command);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                                notificationSounds.BeepException();
                            }
                        }
                        else if (command == "SHUTDOWN")
                        {
                            if (argument == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (argument == "/I")
                            {
                                this.Shutdown(Convert.ToInt32(parameter));
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else if (command == "REBOOT")
                        {
                            if (argument == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (argument == "/I")
                            {
                                this.Reboot(Convert.ToInt32(parameter));
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else if (command == "KILL")
                        {
                            if (argument == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (argument == "/S")
                            {
                                if (parameter == "SVCHOST" || parameter == "SVCHOST.EXE"
                                    || parameter == "NTOSKRNL" || parameter == "NTOSKRNL.EXE"
                                    || parameter == "SYSTEM" || parameter == "IDLE"|| parameter 
                                    == "EXPLORER" || parameter == "EXPLORER.EXE")
                                {
                                    PromptMsg_NotAllowedInSafemode();
                                }
                                else
                                {
                                    try
                                    {
                                        processAlgorithms.KillProcess(parameter);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        notificationSounds.BeepException();
                                    }
                                }

                            }
                            else if (argument == "/I")
                            {
                                try
                                {
                                    processAlgorithms.KillProcessByPID(Convert.ToInt32(parameter));
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Process Not Found.");
                                    notificationSounds.BeepException();
                                }
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else if (command == "RUN")
                        {
                            if (argument == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (argument == "/S")
                            {
                                try
                                {
                                    System.Diagnostics.Process.Start(parameter);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    notificationSounds.BeepException();
                                }
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else if (command == "GETPID")
                        {
                            if (argument == null)
                            {
                                PromptMsg_BadCommand();
                            }
                            else if (argument == "/S")
                            {
                                try
                                {
                                    Console.WriteLine(processAlgorithms.PrintPID(parameter) + "\n");
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Process Not Found.");
                                    notificationSounds.BeepException();
                                }
                            }
                            else { PromptMsg_BadCommand(); }
                        }
                        else
                        {
                            PromptMsg_BadCommand();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message + "\n");
                        notificationSounds.BeepException();
                    }
                    break;
                    #endregion
            }
        }
    }
    class SafemodeStartup
    {
        private void ProgressBarController()
        {
            // You are not allowed to view this.
            // No, you are not allowed. Trust me.
            // Only God and me should know what does this function do.
            Random rd = new Random();
            for (Int32 i = 0; i < 24; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(rd.Next(1, 60));
            }
            Console.Write("\n");
        }
        #region Startup Function
        public void saferun(Boolean flag)
        {
            if (DateTime.Now.ToString("MM-dd").ToString().Equals("11-08")|| DateTime.Now.ToString("MM-dd").ToString().Equals("01-11"))
            {
                RememberAaronSwartz Aaron = new RememberAaronSwartz();
                Aaron.Says();
            }
            Console.WriteLine("Build " + ACInfo.buildVersion + ACInfo.buildDate + "@Windows_NT_" + Convert.ToString(Environment.OSVersion.Version) + "|AdminCon\n\n");
            NotificationSounds soundplay = new NotificationSounds();
            Load STARTUP = new Load();
            STARTUP.Info(false);
            Console.WriteLine("\nInitializing Components:");
            ProgressBarController();
            Console.Write("\n");
            Console.Clear();
            soundplay.BeepLaunch();
            Console.Title = "AdminCon " + ACInfo.versionNumber +" - Safemode";
            Console.Write("AdminCon - Version " + ACInfo.versionNumber +" " + ACInfo.devCode);
            Console.WriteLine("\n(c) 2017-2021 Project Amadeus. All rights reserved.\n");
            Console.Write("UAC Credential: ");
            Console.Write("Administrator@" + Environment.MachineName);
            Console.WriteLine("\n\nType \"HELP\" to see available commands." + "\nType \"INFO\" to view information of this program."+
                "\n____________________________________________\n");
            SafemodeCLI COMMAND_PROMPT_INTERFACE = new SafemodeCLI();
            while (flag)
            {
                Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Security.ObjectDiag.SetNull(COMMAND_PROMPT_INTERFACE);
                COMMAND_PROMPT_INTERFACE.ShellExecute();
            }
        }
        internal void exit()
        {
            Environment.Exit(0);
        }
        #endregion
    }
}
//Program Entry @ Program.cs