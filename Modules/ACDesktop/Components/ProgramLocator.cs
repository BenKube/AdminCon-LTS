using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdminCon_CLI_dotnetEdition.Modules.ACDesktop.Components
{
    static class ProgramLocator
    {
        public static String GeneratePath()
        {
            String program_workingdir = Environment.CommandLine.ToUpper().Replace("\"", null);//delete " " from start and end of String.
            String program_path = program_workingdir.Replace("ACDESKTOP.EXE", null);
            Char[] program_pathInChars = program_path.ToCharArray();
            List<Char> program_pathIncharList = new List<Char>(program_pathInChars);
            program_pathIncharList.Remove(' '); //remove the blankspace at the end of array to concat.
            program_path = new String(program_pathIncharList.ToArray());
            return program_path;
        }
    }
}