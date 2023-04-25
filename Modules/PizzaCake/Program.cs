/**
 * PizzaCake Package Manager
 * Author: Itaru Otaku, koizuminankaze@gmail.com
 * Feature Created at Nov.17th, 2021, TargetVersion = v8.0beta, Architecture = dotnetfx4.5
 * 
 * Ontario Tech Univ.
 **/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/* AdminCon CLI - PizzaCake Package Manager - Source Code - Program.cs
 * Intro: Program Entry.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.PizzaCake
{
    class Program
    {
        static void Main(String[] args) // program entry
        {
            PizzaCakeShell shell = new PizzaCakeShell();
            shell.ShellExecute(true);
        }
    }
}
