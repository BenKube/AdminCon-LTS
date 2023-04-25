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
using System.Text;
/* AdminCon CLI - PizzaCake Package Manager - Source Code - PkgMapper.cs
 * Intro: Package Mapping File (.pml) Analyzer.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.PizzaCake
{
    /// <summary>
    /// Reads all pkg names and urls
    /// </summary>
    class PkgMapper
    {
        //Mapper
        private HashMap<String, String> pkgMapper = new HashMap<String, String>();
        //Generate Mapper
        private HashMap<String, String> GenerateMapper(String[] lines)
        {
            HashMap<String, String> map = new HashMap<String, String>();
            foreach (String line in lines)
            {
                if (line.StartsWith("{") && line.EndsWith("}"))
                {
                    map.Add(line.Split(',')[0].Replace("{",""), line.Split(',')[1].Replace("}", ""));
                }
            }
            return map;
        }

        //Labels
        private const String GLOBAL_CONFIG_LABEL = "[Global Config]";
        private const String ALL_PKG_LIST_LABEL = "[Package Search]";
        private const String INSTALL_PKG_MAPPER_LABEL = "[Package Install]";
        private const String END_OF_DOCUMENT_LABEL = "[End of Document]";

        //Global Properties
        private String SaveLocation = "";
        private Boolean AutoInstall = true;
        
        /// <summary>
        /// Read global config from pkgmappimg.pml and apply.
        /// </summary>
        /// <param name="lines"></param>
        //Get Values for Properties
        private void GetValuesForGlobalProperties(String[] lines)
        {
            foreach(String line in lines)
            {
                if(line.StartsWith("SaveLocation"))
                {
                    this.SaveLocation = line.Split('=')[1];
                }
                if (line.StartsWith("AutoInstall"))
                {
                    if (line.Split('=')[1].ToUpper() == "TRUE")
                    {
                        this.AutoInstall = true;
                    }
                    else this.AutoInstall = false;
                }
            }
        }

        //Search List
        List<String> allRegisteredPackages = new List<String>();
        
        /// <summary>
        /// Generate a list for "pkg search" statement.
        /// </summary>
        /// <param name="pkgMapper">Reflection of pkg-name and url.</param>
        //Generate Search List
        private void GenerateSearchListFromMapper(HashMap<String,String> pkgMapper)
        {
            List<String> result = new List<String>();
            foreach(KeyValuePair<String,String> kv in pkgMapper)
            {
                result.Add(kv.Key);
            }
            this.allRegisteredPackages = result;
        }

        /// <summary>
        /// .ctor()
        /// </summary>
        public PkgMapper()
        {
            FileStream fileStream;
            try
            {
                fileStream = new FileStream(Components.ProgramLocator.GeneratePath()+"\\pkgmapping.pml", FileMode.Open, FileAccess.Read); //check if mapping file exists.
            }catch(Exception) // if pkgmapping.pml not found / not loaded
            {
                ConsoleHL.WriteErrorLine("Mapping file (pkgmapping.pml) not found. Contact developer for solutions.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                Process.Start("mailto:koizuminankaze@gmail.com");
            }
            finally
            {
                fileStream = new FileStream(Components.ProgramLocator.GeneratePath() + "\\pkgmapping.pml", FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(fileStream);
                List<String> lines = new List<String>();
                String line = "";
                while ((line = streamReader.ReadLine()) != END_OF_DOCUMENT_LABEL)
                {
                    lines.Add(line);
                }
                this.GetValuesForGlobalProperties(lines.ToArray());
                this.pkgMapper = this.GenerateMapper(lines.ToArray());
                this.GenerateSearchListFromMapper(pkgMapper);
            }
        }

        //Getters
        public String GetSaveLocation()
        {
            return this.SaveLocation;
        }
        public Boolean GetAutoInstallOrNot()
        {
            return this.AutoInstall;
        }
        public String[] GetRegisteredPkgList()
        {
            return this.allRegisteredPackages.ToArray();
        }
        public HashMap<String,String> GetPkgMapper()
        {
            return this.pkgMapper;
        }
    }
}
//Program Entry @ Program.cs