﻿using System;
using System.Diagnostics;
using System.Management;
using AdminCon_CLI_dotnetEdition.Components.Entities;
/* AdminCon 8.0 Command Line Interface Edition - Source Code - ProcessAlgorithms.cs
 * Intro: Processes Operations Module
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.Processes
{
    /// <summary>
    /// Processes Operations Module
    /// </summary>
    class ProcessAlgorithms
    {
        ProcessMonitor PMonitor = new ProcessMonitor();
        #region Process Operations
        public void KillProcess(String PNAME)
        {
            new pKiller(PNAME);
        }
        public void KillProcessByPID(Int32 PID)
        {
            new pKiller(PID);
        }
        private ProcessArray GetPIDList(String PNAME)
        {
            Process[] pArray = Process.GetProcessesByName(PNAME);
            ProcessArray pidArray = new ProcessArray();
            foreach(Process p in pArray)
            {
                pidArray.Add(p);
            }
            pidArray.Sort(new Amadeus.Microsoft.Windows.CsharpDev.ToolBox.Security.PIDComparer());
            return pidArray;
        }
        public String PrintPID(String PNAME)
        {
            if(GetPIDList(PNAME).GetLength() == 0)
            {
                throw new Exception("Process Not Found.");
            }
            else
            {
                return "PID of " + PNAME + ": \n\n" + GetPIDList(PNAME).ToString() + "\n\n" + GetPIDList(PNAME).GetLength() + " sub-processes are running.";
            }
        }
        public Single GetProcessMemoryUsage(String pname)
        {
            Single totalVirMem = 0;
            Process[] pArray = Process.GetProcessesByName(pname);
            if(pArray.Length == 0)
            {
                return 0;
            }
            {
                for (Int32 index = 0; index < pArray.Length; index++)
                {
                    totalVirMem += PMonitor.GetPrivateMemoryUsage_KB(pArray[index]);
                }
                return totalVirMem;
            }
        }
        public Single GetProcessMemoryUsage(Int32 pid)
        {
            Process p = Process.GetProcessById(pid);
            return PMonitor.GetPrivateMemoryUsage_KB(p);
        }
        public Single GetProcessMemoryUsage(Process p)
        {
            return PMonitor.GetPrivateMemoryUsage_KB(p);
        }
        public String GetProcessCPUUsage(String pName)
        {
            using (var perfCounter = new PerformanceCounter("Process", "% Processor Time", pName))

            {
                return (Math.Round((perfCounter.NextValue() / Environment.ProcessorCount),2).ToString()+'%');
            }
        }
        public String GetProcessHostUserName(Int32 pid)
        {
            String userName = String.Empty;
            try
            {
                foreach (ManagementObject item in new ManagementObjectSearcher("Select * from Win32_Process WHERE processID=" + pid).Get())
                {
                    ManagementBaseObject inPar = null;
                    ManagementBaseObject outPar = null;
                    inPar = item.GetMethodParameters("GetOwner");
                    outPar = item.InvokeMethod("GetOwner", inPar, null);
                    userName = Convert.ToString(outPar["User"]);
                    break;
                }
            }
            catch
            {
                userName = "SYSTEM";
            }

            return userName;
        }
        public String GetProcessLocation(Process p)
        {
            try
            {
                return p.MainModule.FileName;
            }catch(Exception)
            {
                return "(Virtual Process)";
            }
        }
        #endregion
    }
}
//Program Entry @ Program.cs
