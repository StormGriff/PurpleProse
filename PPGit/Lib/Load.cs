using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Win32;
using System.IO.Compression;

namespace PPGit.Lib
{
    public class Loader
    {
        public const char ID_SEPARATOR = ',';

        /// <summary>
        /// Executes a load operation for a full project
        /// User should select a .proj file
        /// </summary>
        public bool Load()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Project File .proj|*.proj|PPprj Files (*.ppprj)|*.ppprj";
            string directory;
            bool success = false;

            ofd.InitialDirectory = "C:\\";

            if (ofd.ShowDialog() == true)
            {
                directory = Path.GetDirectoryName(ofd.FileName);
                mainLists.projectDir = directory;

                mainLists.projectName = new System.IO.DirectoryInfo(mainLists.projectDir).Name;
                //string lastFolderName = Path.GetFileName(Path.GetDirectoryName(mainLists.projectDir));
                //mainLists.projectName = lastFolderName;

                mainLists.basePath = mainLists.projectDir;
                var parentDir = Directory.GetParent(mainLists.basePath);
                mainLists.basePath = parentDir.ToString();

               
                if (ofd.FileName.Contains(".ppprj"))
                {
                    //  (rename to .zip -> extract)
                    
                    ofd.FileName = ExtractCustomProjectFile(ofd.FileName);
                    // go to project dir and get .proj path 
                    // and set path to parent path + project name .proj
                    //mainLists.basePath
                    // then do all of the above
                }

                // if(ofd.FileName.Contains(".proj"))
                LoadProjectFile(ofd.FileName);
                LoadCharacterList(directory + "\\items\\characters\\char.list");
                LoadLocationList(directory + "\\items\\locations\\loc.list");

                success = true;
            }
            else
            {
                success = false;
            }

            return success;
        }

        private string ExtractCustomProjectFile(string sourceArchiveFileName)
        {
            // Set project's base path to the folder where th ppprj is located
            var parentDir = Directory.GetParent(sourceArchiveFileName);
            mainLists.basePath = parentDir.ToString();
            mainLists.projectName = new System.IO.DirectoryInfo(sourceArchiveFileName).Name;
            string projectFolderName = mainLists.projectName.Replace(".ppprj", "");

            string zipFileName = mainLists.basePath + "\\" + projectFolderName + ".zip";
            // IF ZIP FILE ALREADY EXISTS IN THE DIR, REPLACE IT
            FileInfo destZipFile = new FileInfo(zipFileName);

            if (destZipFile.Exists)
            {
                File.Copy(sourceArchiveFileName, Path.ChangeExtension(sourceArchiveFileName, ".zip"), true);

            }
            //File.Move(sourceArchiveFileName, Path.ChangeExtension(sourceArchiveFileName, ".zip"));
            
            ZipFile.ExtractToDirectory(zipFileName, mainLists.basePath ); //  "\\" + projectFolderName
                                                                           //MessageBox.Show("ZIP file extracted successfully!");

            // return the <project folder name>.proj
            return mainLists.basePath + "\\" + projectFolderName + "\\" + projectFolderName + ".proj";
        }

        private void LoadProjectFile(string filepath)
        {
            FileStream fs = File.Open(filepath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
            }
        }

        private void LoadCharacterList(string filepath)
        {
            FileStream fs = File.Open(filepath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line;
            string folderName;
            List<string> lines = new List<string>();

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();

                lines = line.Split(new char[] { ID_SEPARATOR }).ToList();

                folderName = TextOps.ToDirectorySafe(lines.ElementAt(0)) + lines.ElementAt(1);

                LoadCharacterInfo(Path.GetDirectoryName(filepath) + "\\" + folderName, TextOps.ToDirectorySafe(lines.ElementAt(0)));
            }

        }

        //TODO: look for TODO in this function
        private void LoadCharacterInfo(string filepath, string name)
        {
            FileStream fs = File.Open(filepath + "\\" + name + ".info", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line;
            List<string> lines = new List<string>();
            Character c;

            //reads the first line, which is the name
            //allows the instantiation for c, since the character class requires a name parameter
            line = sr.ReadLine();
            lines = line.Split(new char[] { ':' }).ToList();

            //name
            c = new Character(lines.ElementAt(1));
            c.Directory = filepath;

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();

                lines = line.Split(new char[] { ':' }).ToList();

                if (lines.ElementAt(0) == "Age")
                {
                    c.charAge = Convert.ToInt32(lines.ElementAt(1));
                }

                if (lines.ElementAt(0) == "Race")
                {
                    c.charKind = lines.ElementAt(1);
                }

                if (lines.ElementAt(0) == "Gender")
                {
                    c.charGender = lines.ElementAt(1);
                }

                if (lines.ElementAt(0) == "Role")
                {
                    c.charRole = lines.ElementAt(1);
                }

                if (lines.ElementAt(0) == "Language")
                {
                    c.charLanguage = lines.ElementAt(1);
                }

                if (lines.ElementAt(0) == "Hometown")
                {
                    c.charHometown = lines.ElementAt(1);
                }

                if (lines.ElementAt(0) == "Description")
                {
                    c.DescFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                }

                if (lines.ElementAt(0) == "Text")
                {
                    //TODO
                }

                if (lines.ElementAt(0) == "Image")
                {
                    c.Images.Add(filepath + "\\images\\" + lines.ElementAt(1).ToString());
                }
            }
            c.Number = mainLists.objNum++;

            //c.window = new PPGit.GUI.DetailWindows.CharacterWindow(c);
            PPGit.mainLists.characterList.Add(c);
        }

        private void LoadLocationList(string filepath)
        {
            FileStream fs = File.Open(filepath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line;
            string folderName;
            List<string> lines = new List<string>();

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();

                lines = line.Split(new char[] { ',' }).ToList();

                folderName = lines.ElementAt(0).Replace(" ", string.Empty).ToLower() + lines.ElementAt(1);

                LoadLocationInfo(Path.GetDirectoryName(filepath) + "\\" + folderName, lines.ElementAt(0).Replace(" ", string.Empty).ToLower());
            }
        }

        private void LoadLocationInfo(string filepath, string name)
        {
            FileStream fs = File.Open(filepath + "\\" + name + ".info", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line;
            string type;
            List<string> lines = new List<string>();
            //PPGit.Lib.Location c;

            //read first line, which is the class type
            type = sr.ReadLine();

            //reads the first line, which is the name
            //allows the instantiation for c, since the character class requires a name parameter
            line = sr.ReadLine();
            lines = line.Split(new char[] { ':' }).ToList();

            if(type == "Location")
            {
                Lib.Location c = new Location(lines.ElementAt(1));

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();

                    lines = line.Split(new char[] { ':' }).ToList();

                    if (lines.ElementAt(0) == "Description")
                    {
                        c.DescFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "History")
                    {
                        c.HistFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "Map")
                    {
                        c.map_file = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "Size")
                    {
                        //c.theSize.num = Convert.ToInt32(lines.ElementAt(1));
                    }
                }
                c.Number = mainLists.objNum++;

                PPGit.mainLists.locationList.Add(c);
            }
            else if (type == "Building")
            {
                Lib.Building c = new Building(new Location(lines.ElementAt(1)));

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();

                    lines = line.Split(new char[] { ':' }).ToList();

                    if (lines.ElementAt(0) == "Description")
                    {
                        c.DescFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "History")
                    {
                        c.HistFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "Map")
                    {
                        c.map_file = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "Size")
                    {
                        //c.theSize.num = Convert.ToInt32(lines.ElementAt(1));
                    }
                    if (lines.ElementAt(0) == "Stories")
                    {
                        c.setNumStories(lines.ElementAt(1));
                    }
                    if (lines.ElementAt(0) == "Rooms")
                    {
                        c.numRooms = Convert.ToInt32(lines.ElementAt(1));
                    }
                    if (lines.ElementAt(0) == "Dimensions")
                    {
                        List<string> Vals = lines.ElementAt(1).Split(new char[] { ',' }).ToList();

                        c.myDimensions.x = Convert.ToInt32(Vals.ElementAt(0));
                        c.myDimensions.y = Convert.ToInt32(Vals.ElementAt(1));
                        c.myDimensions.z = Convert.ToInt32(Vals.ElementAt(2));
                        
                        if(Vals.ElementAt(3) == "Inches")
                        {
                            c.myDimensions.myMeasurement = mainLists.measurement.Inches;
                        }
                        else if (Vals.ElementAt(3) == "Centimeters")
                        {
                            c.myDimensions.myMeasurement = mainLists.measurement.Centimeters;
                        }
                        else if (Vals.ElementAt(3) == "Feet")
                        {
                            c.myDimensions.myMeasurement = mainLists.measurement.Feet;
                        }
                        else if (Vals.ElementAt(3) == "Meters")
                        {
                            c.myDimensions.myMeasurement = mainLists.measurement.Meters;
                        }
                        else if (Vals.ElementAt(3) == "Yard")
                        {
                            c.myDimensions.myMeasurement = mainLists.measurement.Yard;
                        }
                        else if (Vals.ElementAt(3) == "Lightyear")
                        {
                            c.myDimensions.myMeasurement = mainLists.measurement.Lightyear;
                        }
                    }
                }
                c.Number = mainLists.objNum++;

                PPGit.mainLists.locationList.Add(c);
            }
            else if (type == "City")
            {
                Lib.City c = new City(new Location(lines.ElementAt(1)));

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();

                    lines = line.Split(new char[] { ':' }).ToList();

                    if (lines.ElementAt(0) == "Description")
                    {
                        c.DescFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "History")
                    {
                        c.HistFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "Map")
                    {
                        c.map_file = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "Size")
                    {
                        if(lines.ElementAt(1) == "XSmall")
                        {
                            c.MySize = City.size.XSmall;
                        }
                        else if (lines.ElementAt(1) == "Small")
                        {
                            c.MySize = City.size.Small;
                        }
                        else if (lines.ElementAt(1) == "Medium")
                        {
                            c.MySize = City.size.Medium;
                        }
                        else if (lines.ElementAt(1) == "Large")
                        {
                            c.MySize = City.size.Large;
                        }
                        else if (lines.ElementAt(1) == "XLarge")
                        {
                            c.MySize = City.size.XLarge;
                        }
                        //c.theSize.num = Convert.ToInt32(lines.ElementAt(1));
                    }
                    if (lines.ElementAt(0) == "Population")
                    {
                        c.population = Convert.ToInt32(lines.ElementAt(1));
                    }
                    if (lines.ElementAt(0) == "Region")
                    {
                        //c.region = mainLists.locationList.;
                    }
                }
                c.Number = mainLists.objNum;

                mainLists.objNum++;
                PPGit.mainLists.locationList.Add(c);
            }
            else if (type == "Country")
            {
                Lib.Country c = new Country(new Location(lines.ElementAt(1)));

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();

                    lines = line.Split(new char[] { ':' }).ToList();

                    if (lines.ElementAt(0) == "Description")
                    {
                        c.DescFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "History")
                    {
                        c.HistFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "Map")
                    {
                        c.map_file = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "Size")
                    {
                        //c.theSize.num = Convert.ToInt32(lines.ElementAt(1));
                    }
                    if (lines.ElementAt(0) == "Region")
                    {
                        //c.region = mainLists.locationList.;
                    }
                    if (lines.ElementAt(0) == "Citizens")
                    {
                        c.citizens = Convert.ToInt32(lines.ElementAt(1));
                    }
                    if (lines.ElementAt(0) == "Government")
                    {
                        if (lines.ElementAt(3) == "Communist")
                        {
                            c._ocracy = Country.government.Communist;
                        }
                        else if (lines.ElementAt(3) == "Confederation")
                        {
                            c._ocracy = Country.government.Confederation;
                        }
                        else if (lines.ElementAt(3) == "Democracy")
                        {
                            c._ocracy = Country.government.Democracy;
                        }
                        else if (lines.ElementAt(3) == "Dictatorship")
                        {
                            c._ocracy = Country.government.Dictatorship;
                        }
                        else if (lines.ElementAt(3) == "Monarchy")
                        {
                            c._ocracy = Country.government.Monarchy;
                        }
                        else if (lines.ElementAt(3) == "Theocracy")
                        {
                            c._ocracy = Country.government.Theocracy;
                        }
                    }
                    if (lines.ElementAt(0) == "Economy")
                    {
                        if (lines.ElementAt(3) == "Capitalist")
                        {
                            c.economy = Country.economies.Capitalist;
                        }
                        else if (lines.ElementAt(3) == "Socialist")
                        {
                            c.economy = Country.economies.Socialist;
                        }
                    }
                }
                c.Number = mainLists.objNum++;

                PPGit.mainLists.locationList.Add(c);
            }
            else if (type == "Planet")
            {
                Lib.Planet c = new Planet(new Location(lines.ElementAt(1)));

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();

                    lines = line.Split(new char[] { ':' }).ToList();

                    if (lines.ElementAt(0) == "Description")
                    {
                        c.DescFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "History")
                    {
                        c.HistFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "Map")
                    {
                        c.map_file = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "Size")
                    {
                        //c.theSize.num = Convert.ToInt32(lines.ElementAt(1));
                    }
                    if (lines.ElementAt(0) == "Region")
                    {
                        //c.region = mainLists.locationList.;
                    }
                    if (lines.ElementAt(0) == "Population")
                    {
                        c.population = Convert.ToInt32(lines.ElementAt(1));
                    }
                    if (lines.ElementAt(0) == "Technology")
                    {
                        if (lines.ElementAt(3) == "Industrial")
                        {
                            c.setLevel(Planet.technologyLevel.Industrial);
                        }
                        else if (lines.ElementAt(3) == "PreIndustrial")
                        {
                            c.setLevel(Planet.technologyLevel.PreIndustrial);
                        }
                        else if (lines.ElementAt(3) == "Modern")
                        {
                            c.setLevel(Planet.technologyLevel.Modern);
                        }
                        else if (lines.ElementAt(3) == "PreWarp")
                        {
                            c.setLevel(Planet.technologyLevel.PreWarp);
                        }
                        else if (lines.ElementAt(3) == "Primitive")
                        {
                            c.setLevel(Planet.technologyLevel.Primitive);
                        }
                        else if (lines.ElementAt(3) == "Spacefaring")
                        {
                            c.setLevel(Planet.technologyLevel.Spacefaring);
                        }
                    }
                    if (lines.ElementAt(0) == "Biome")
                    {
                        if (lines.ElementAt(3) == "Alpine")
                        {
                            c.myLand = Planet.biome.Alpine;
                        }
                        else if (lines.ElementAt(3) == "Chaparral")
                        {
                            c.myLand = Planet.biome.Chaparral;
                        }
                        else if (lines.ElementAt(3) == "Desert")
                        {
                            c.myLand = Planet.biome.Desert;
                        }
                        else if (lines.ElementAt(3) == "Grassland")
                        {
                            c.myLand = Planet.biome.Grassland;
                        }
                        else if (lines.ElementAt(3) == "Rainforest")
                        {
                            c.myLand = Planet.biome.Rainforest;
                        }
                        else if (lines.ElementAt(3) == "Taiga")
                        {
                            c.myLand = Planet.biome.Taiga;
                        }
                    }
                }
                c.Number = mainLists.objNum++;

                PPGit.mainLists.locationList.Add(c);
            }
            else if (type == "Region")
            {
                Lib.Region c = new Region(new Location(lines.ElementAt(1)));

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();

                    lines = line.Split(new char[] { ':' }).ToList();

                    if (lines.ElementAt(0) == "Description")
                    {
                        c.DescFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "History")
                    {
                        c.HistFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "Map")
                    {
                        c.map_file = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "Size")
                    {
                        //c.theSize.num = Convert.ToInt32(lines.ElementAt(1));
                    }
                }
                c.Number = mainLists.objNum++;

                PPGit.mainLists.locationList.Add(c);
            }
            else if (type == "Room")
            {
                Lib.room c = new room(new Location(lines.ElementAt(1)));

                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();

                    lines = line.Split(new char[] { ':' }).ToList();

                    if (lines.ElementAt(0) == "Description")
                    {
                        c.DescFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "History")
                    {
                        c.HistFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "Map")
                    {
                        c.map_file = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
                    }
                    if (lines.ElementAt(0) == "Size")
                    {
                        //c.theSize.num = Convert.ToInt32(lines.ElementAt(1));
                    }
                    if (lines.ElementAt(0) == "Dimensions")
                    {
                        List<string> Vals = lines.ElementAt(1).Split(new char[] { ',' }).ToList();

                        c.myRoom.x = Convert.ToInt32(Vals.ElementAt(0));
                        c.myRoom.y = Convert.ToInt32(Vals.ElementAt(1));

                        if (Vals.ElementAt(3) == "Inches")
                        {
                            c.myRoom.usedMeasurement = mainLists.measurement.Inches;
                        }
                        else if (Vals.ElementAt(3) == "Centimeters")
                        {
                            c.myRoom.usedMeasurement = mainLists.measurement.Centimeters;
                        }
                        else if (Vals.ElementAt(3) == "Feet")
                        {
                            c.myRoom.usedMeasurement = mainLists.measurement.Feet;
                        }
                        else if (Vals.ElementAt(3) == "Meters")
                        {
                            c.myRoom.usedMeasurement = mainLists.measurement.Meters;
                        }
                        else if (Vals.ElementAt(3) == "Yard")
                        {
                            c.myRoom.usedMeasurement = mainLists.measurement.Yard;
                        }
                        else if (Vals.ElementAt(3) == "Lightyear")
                        {
                            c.myRoom.usedMeasurement = mainLists.measurement.Lightyear;
                        }
                    }
                }
                c.Number = mainLists.objNum++;

                PPGit.mainLists.locationList.Add(c);
            }

            //name
            //c = new Location(lines.ElementAt(1));

            //while (!sr.EndOfStream)
            //{
            //    line = sr.ReadLine();

            //    lines = line.Split(new char[] { ':' }).ToList();

            //    if (lines.ElementAt(0) == "Description")
            //    {
            //        c.DescFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();
            //    }
            //    if (lines.ElementAt(0) == "Size")
            //    {
            //        c.theSize.num = Convert.ToInt32(lines.ElementAt(1));
            //    }
            //}
            //c.Number = mainLists.objNum;

            //mainLists.objNum++;
            //PPGit.mainLists.locationList.Add(c);
        }
    }
}