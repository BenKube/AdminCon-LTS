/* AdminCon 8.0 Command Line Interface Edition - Source Code - pKiller.cs
 * Intro: Kill a process.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
using System;
using System.Diagnostics;
/**
 * Apr.29th, 2020
 * Modified By Ben (Itaru Otaku): Added lost comment.
 */
namespace AdminCon_CLI_dotnetEdition.Components.Processes
{
    class pKiller
    {
        private static Process p;
        private static Process[] pArray;
        #region Contructors
        public pKiller()
        {
            throw new Exception("No Arguments.");
        }
        public pKiller(Process p)
        {
            p.Kill();
        }
        public pKiller(String name)
        {
            Process[] pArray = Process.GetProcessesByName(name);
            foreach (Process p in pArray)
            {
                p.Kill();
            }
        }
        public pKiller(Int32 id)
        {
            Process p = Process.GetProcessById(id);
            p.Kill();
        }
        public pKiller(Process[] pArray)
        {
            for (Int32 movR = 0; movR < pArray.Length - 1; movR++)
            {
                for (Int32 movL = pArray.Length; movL > pArray.Length - 1 - movR; movL--)
                {
                    if (pArray[movL].WorkingSet64 < pArray[movL + 1].WorkingSet64)
                    {
                        Process temp = pArray[movL + 1];
                        pArray[movL + 1] = pArray[movL];
                        pArray[movL] = temp;
                    }
                }
            }
            foreach (Process p in pArray)
            {
                p.Kill();
            }
        }
        public pKiller(Int32[] pidArray)
        {
            foreach (Int32 i in pidArray)
            {
                p = Process.GetProcessById(i);
                p.Kill();
            }
        }
        public pKiller(String[] pnameArray)
        {
            foreach (String s in pnameArray)
            {
                pArray = Process.GetProcessesByName(s);
                foreach (Process p in pArray)
                {
                    p.Kill();
                }
            }
        }
        #endregion

        #region Deconstructors

        // @Peterson: destructor in C# is less reliable than GC.SuppressFinalize(), so please try to avoid it.
        ~pKiller()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
//Program Entry @ Program.cs