﻿using Microsoft.VisualBasic.Devices;

using System;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
/* AdminCon 8.0 Command Line Interface Edition - Source Code - Daemon.cs
 * Intro: Daemon threads that monitors memory, cpu and disk.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.ACDesktop.Components
{
    [Serializable]
    [PerformanceCounterPermission(System.Security.Permissions.SecurityAction.Assert)]
    internal class Daemon : IDisposable //Should be handled by Garbage Collect periodly.
    {
        private ComputerInfo computerInfo = new ComputerInfo();
        //Fields
        public Double Memory_Usage; // KB
        public Double Rest_Memory_Usage; // KB
        public Double CPU_Usage; // 1
        public Double Disk_IO_Speed;// Byte per sec

        //Performance Counters
        private PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private PerformanceCounter diskCounter = new PerformanceCounter("PhysicalDisk", "Disk Read Bytes/sec", "_Total");
        //Singleton Object
        private static Daemon instance = new Daemon();

        /// <summary>
        /// .ctor()
        /// </summary>
        private Daemon()
        {
            //Create sync threads.
            ThreadStart memorySnapshot = new ThreadStart(MemoryUsageSnapshot);
            ThreadStart restMemorySnapshot = new ThreadStart(Rest_MemUsageSnapshot);
            ThreadStart cpuSnapshot = new ThreadStart(CPU_UsageSnapshot);
            ThreadStart diskSnapshot = new ThreadStart(DiskUsageSnapshot);

            Thread memoryMonitorThread = new Thread(memorySnapshot);
            Thread restMemMonitorThread = new Thread(restMemorySnapshot);
            Thread CPUMonitorThread = new Thread(cpuSnapshot);
            Thread diskMonitorThread = new Thread(diskSnapshot);

            memoryMonitorThread.Start();
            restMemMonitorThread.Start();
            CPUMonitorThread.Start();
            diskMonitorThread.Start();
        } //Not Constructable from outside.

        public static String[] GetAdapter()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            String[] name = new String[adapters.Length];
            Int32 index = 0;
            foreach (NetworkInterface networkInterface in adapters)
            {
                name[index] = networkInterface.Description;
                index++;
            }
            return name;
        }

        /// <summary>
        /// .dtor()
        /// </summary>
        ~Daemon()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Get a singleton instance.
        /// </summary>
        /// <returns></returns>
        public static Daemon GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Take a snapshot for memory usage randomly.
        /// </summary>
        /// 

        //When Too Many AC.EXE Processes are Created:
        /* Exception Stacktrace
         * Unhandled Exception: System.ComponentModel.Win32Exception: Could not obtain memory information due to internal error.
            at Microsoft.VisualBasic.Devices.ComputerInfo.InternalMemoryStatus.Refresh()
            at Microsoft.VisualBasic.Devices.ComputerInfo.InternalMemoryStatus.get_TotalPhysicalMemory()
            at AdminCon_CLI_dotnetEdition.Components.@Global.Daemon.MemoryUsageSnapshot() in Daemon.cs:line 76
            at System.Threading.ExecutionContext.RunInternal(ExecutionContext executionContext, ContextCallback callback, Object st
        ate, Boolean preserveSyncCtx)
            at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state, Boo
        lean preserveSyncCtx)
            at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)
            at System.Threading.ThreadHelper.ThreadStart()*/
        //Stacktrace Reference.
        private void MemoryUsageSnapshot()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(500);
                    Memory_Usage = (computerInfo.TotalPhysicalMemory -
                        computerInfo.AvailablePhysicalMemory) / 1024;
                    if (Memory_Usage > computerInfo.TotalPhysicalMemory) Memory_Usage = 0;
                }
                catch (Exception) { }
            }
        }

        private void Rest_MemUsageSnapshot()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(500);
                    Rest_Memory_Usage = computerInfo.AvailablePhysicalMemory / 1024; //KB
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// Take a snapshot for cpu usage randomly.
        /// </summary>
        private void CPU_UsageSnapshot()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(200);
                    CPU_Usage = cpuCounter.NextValue();
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// Take a snapshot for disk usage randomly.
        /// </summary>
        private void DiskUsageSnapshot()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(500);
                    Disk_IO_Speed = diskCounter.NextValue();
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// ToString() method
        /// </summary>
        /// <returns>String</returns>
        public override String ToString()
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append("Memory Usage: " + Math.Round(Memory_Usage / 1024, 2) + " MB");
            strBuilder.Append("\nCPU Usage: " + (Int32)CPU_Usage + "%");
            strBuilder.Append("\nDisk Usage: " + Math.Round(Disk_IO_Speed / 1024 / 1024, 2) + " MB/s");
            return strBuilder.ToString();
        }

        /// <summary>
        /// Implemented Dispose() Method.
        /// </summary>
        public void Dispose()
        {
            cpuCounter.Close();
            cpuCounter.Dispose();
            diskCounter.Close();
            diskCounter.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
//Program Entry @ Launcher.cs