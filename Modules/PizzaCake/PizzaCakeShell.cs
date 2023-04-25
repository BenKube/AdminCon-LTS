/**
 * PizzaCake Package Manager
 * Author: Itaru Otaku, koizuminankaze@gmail.com
 * Feature Created at Nov.17th, 2021, TargetVersion = v8.0beta, Architecture = dotnetfx4.5
 * 
 * Ontario Tech Univ.
 **/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* AdminCon CLI - PizzaCake Package Manager - Source Code - PizzaCakeShell.cs
 * Intro: Console Interaction & Command Grammar Analyzer.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.PizzaCake
{
    /// <summary>
    /// Shell of PizzaCake
    /// </summary>
    class PizzaCakeShell
    {
        private String SaveLocation;
        private Boolean AutoInstall;
        private String[] allRegisteredPackages;
        private HashMap<String, String> mapper = new HashMap<String, String>();
        private String fileFullName;

        // Web Client
        WebClient webClient = new WebClient();

        /// <summary>
        /// .ctor()
        /// </summary>
        public PizzaCakeShell()
        {
            PkgMapper pkgMapper = new PkgMapper();
            this.SaveLocation = pkgMapper.GetSaveLocation();
            this.AutoInstall = pkgMapper.GetAutoInstallOrNot();
            this.allRegisteredPackages = pkgMapper.GetRegisteredPkgList();
            this.mapper = pkgMapper.GetPkgMapper();

            // Web Client Init
            this.webClient.Encoding = Encoding.ASCII;
            this.webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.GetDownloadStatus);
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072; //For SSL/TLS Channel

            Console.Title = "PizzaCake 1.0";
            Console.Write("PizzaCake Package Manager v1.0\n");
            Console.Write("(c) 2017-2022 Project Amadeus. All rights reserved.\n\n");
            Console.Write("Type \"HELP\" or \"/?\" to view available commands.");
        }

        /// <summary>
        /// Will be called when this.webClient.DownloadProgressChanged was triggered.
        /// Displays received bytes and total bytes when downloading pkgs.
        /// </summary>
        /// <param name="sender">Object sender</param>
        /// <param name="e">DownloadProgressChangedEventArgs</param>
        //DownloadProgressChangedEventHandler of WebClient
        private void GetDownloadStatus(Object sender, DownloadProgressChangedEventArgs e)
        {
            String output = String.Format("{0} MB / {1} MB", (e.BytesReceived / 1024d / 1024d).ToString("0.00"), (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));
            Double percent = (e.BytesReceived / 1024d / 1024d) / (e.TotalBytesToReceive / 1024d / 1024d);
            Console.Write("\r" + output+$",\u0020{(Int32)(percent*100)+"%"}");
        }

        // PizzaCake Statement Definition:
        // 1. pizza search [pkg-fuzzyname]
        // 2. pizza install [pkg-name]
        // 3. pizza search * (list all pkgs)
        // 4. pizza clear pkgs

        /// <summary>
        /// PizzaCake Statement Definition:
        /// 1. pizza search [pkg-fuzzyname]
        /// 2. pizza install [pkg-name]
        /// 3. pizza search * (list all pkgs)
        /// 4. pizza clear pkgs
        /// </summary>
        public void ShellExecute(Boolean switcher)
        {
            // Bug Fixed: Create directory for first use. ~Mar.2022
            Directory.CreateDirectory(this.SaveLocation);
            while(switcher == true) //loop
            {
                try
                {
                    Console.WriteLine();
                    Console.Write("\nPizzaCake:" + Environment.UserName + "@" + Environment.MachineName + "/CLI>");
                    String userInput = Console.ReadLine();
                    userInput = userInput.Trim();
                    if (userInput.ToUpper() == "HELP" || userInput.ToUpper() == "/?")
                    {
                        ConsoleHL.WriteInfoLine("pkg search [pkg-fuzzyname]: Search for registered packages.");
                        ConsoleHL.WriteInfoLine("pkg install [pkgname]:      Install a package.");
                        ConsoleHL.WriteInfoLine("pkg search *:               List all registered packages.");
                        ConsoleHL.WriteInfoLine("pkg clear all:              Clear all downloaded packages.");
                    }
                    else if (userInput.Trim() == "") continue;
                    else
                    {
                        String sectionOne = userInput.Split(' ')[0].ToUpper();
                        String sectionTwo = userInput.Split(' ')[1].ToUpper();
                        String sectionThree = userInput.Split(' ')[2].ToUpper();
                        if (sectionOne == "PKG")
                        {
                            if (sectionTwo == "SEARCH")
                            {
                                if (sectionThree == "*")
                                {
                                    foreach (String pkgName in this.allRegisteredPackages)
                                    {
                                        ConsoleHL.WriteOutputLine(pkgName);
                                    }
                                }
                                else
                                {
                                    List<String> result = new List<String>();
                                    foreach (String pkgName in this.allRegisteredPackages)
                                    {
                                        if (pkgName.ToUpper().Contains(sectionThree) || pkgName.ToUpper() == sectionThree)
                                        {
                                            result.Add(pkgName);
                                        }
                                    }
                                    Console.WriteLine("Matched Package Name:");
                                    foreach (String matchedPkgName in result)
                                    {
                                        ConsoleHL.WriteOutputLine(matchedPkgName);
                                    }
                                    Console.WriteLine();
                                }
                            }
                            else if (sectionTwo == "INSTALL")
                            {
                                //TODO: Use sectionThree as package name to download and install;
                                foreach (KeyValuePair<String, String> kv in this.mapper)
                                {
                                    if (kv.Key.ToUpper() == sectionThree)
                                    {
                                        if (kv.Value.ToUpper().EndsWith(".EXE"))
                                        {
                                            if (this.AutoInstall == true)
                                            {
                                                this.fileFullName = this.SaveLocation + "\\" + kv.Key + ".exe";

                                                // Local Task Method
                                                Task Download() => this.webClient.DownloadFileTaskAsync(new Uri(kv.Value), this.fileFullName);

                                                ConsoleHL.WritePrompt("Downloading Package From Server: " + kv.Value.Split('/')[0] + "//" + kv.Value.Split('/')[1] + kv.Value.Split('/')[2] + "\n");
                                                
                                                //Wait for async method completes.
                                                Task.Run(async () => { await Download(); }).Wait();

                                                Process.Start(this.fileFullName); // When this.AutoInstall == true, run the downloaded pkg directly.
                                                ConsoleHL.WriteTitle("\nFinished.");
                                                break;
                                            }
                                            else
                                            {
                                                this.fileFullName = this.SaveLocation + "\\" + kv.Key + ".exe";

                                                // Local Task Method
                                                Task Download() => this.webClient.DownloadFileTaskAsync(new Uri(kv.Value), this.fileFullName);

                                                ConsoleHL.WritePrompt("Downloading Package From Server: " + kv.Value.Split('/')[0] + "//" + kv.Value.Split('/')[1] + kv.Value.Split('/')[2] + "\n");

                                                //Wait for async method completes.
                                                Task.Run(async () => { await Download(); }).Wait();

                                                Process.Start("explorer.exe", "/select,\"" + this.fileFullName + "\"");// When this.AutoInstall == false, show downloaded pkg in explorer.
                                                ConsoleHL.WriteTitle("\nFinished.");
                                                break;
                                            }
                                        }
                                        else if (kv.Value.ToUpper().EndsWith(".MSI"))
                                        {
                                            if (this.AutoInstall == true)
                                            {
                                                this.fileFullName = this.SaveLocation + "\\" + kv.Key + ".msi";

                                                // Local Task Method
                                                Task Download() => this.webClient.DownloadFileTaskAsync(new Uri(kv.Value), this.fileFullName);

                                                ConsoleHL.WritePrompt("Downloading Package From Server: " + kv.Value.Split('/')[0] + "//" + kv.Value.Split('/')[1] + kv.Value.Split('/')[2] + "\n");

                                                //Wait for async method completes.
                                                Task.Run(async () => { await Download(); }).Wait();

                                                Process.Start(this.fileFullName); // When this.AutoInstall == true, run the downloaded pkg directly.
                                                ConsoleHL.WriteTitle("\nFinished.");
                                                break;
                                            }
                                            else
                                            {
                                                this.fileFullName = this.SaveLocation + "\\" + kv.Key + ".msi";

                                                // Local Task Method
                                                Task Download() => this.webClient.DownloadFileTaskAsync(new Uri(kv.Value), this.fileFullName);

                                                ConsoleHL.WritePrompt("Downloading Package From Server: " + kv.Value.Split('/')[0] + "//" + kv.Value.Split('/')[1] + kv.Value.Split('/')[2] + "\n");

                                                //Wait for async method completes.
                                                Task.Run(async () => { await Download(); }).Wait();

                                                Process.Start("explorer.exe", "/select,\"" + this.fileFullName + "\"");// When this.AutoInstall == false, show downloaded pkg in explorer.
                                                ConsoleHL.WriteTitle("\nFinished.");
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            else if(sectionTwo == "CLEAR")
                            {
                                if(sectionThree == "ALL")
                                {
                                    ConsoleHL.WriteError("You are going to delete all downloaded installers. \nConfirm? (Y/N) ");
                                    String option = Console.ReadLine();
                                    if(option.ToUpper() == "Y")
                                    {
                                        DirectoryInfo dirInfo = new DirectoryInfo(this.SaveLocation);
                                        FileInfo[] finfos = dirInfo.GetFiles();
                                        foreach (FileInfo f in finfos)// Delete all files in this.SaveLocation
                                        {
                                            f.Delete();
                                        }
                                        ConsoleHL.WriteTitle("Finished.");
                                    }
                                    else if(option.ToUpper() == "N")
                                    {
                                        ConsoleHL.WriteTitleLine("Aborted.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Option. Aborting...");
                                    }
                                }
                                else
                                {
                                    ConsoleHL.WriteErrorLine("Error - Bad Command.");
                                }
                            }
                        }
                        else
                        {
                            ConsoleHL.WriteErrorLine("Error - Bad Command.");
                        }
                    }
                }catch(Exception ex)
                {
                    ConsoleHL.WriteErrorLine(ex.Message);
                }
            }
        }
    }
}
//Program Entry @ Program.cs