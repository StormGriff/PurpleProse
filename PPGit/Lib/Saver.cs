using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Windows;
//using System.IO

namespace PPGit.Lib
{
    public class Saver
    {

        public bool Save()
        {
            bool success = false;

            if(mainLists.projectDir == null)
            {
                success = false;
            }
            else
            {
                SaveProjectFile();
                SaveCharacterList(mainLists.projectDir + "\\items\\characters\\char.list");
                SaveLocationList(mainLists.projectDir + "\\items\\locations\\loc.list");
            }


            WrapUp();

            return success;
        }

        private static void WrapUp()
        {
            // Get root directory
            //mainLists.projectDir
            if (mainLists.projectDir != null)
            {
                var lastFolder = mainLists.basePath = mainLists.projectDir;
                var parentDir = Directory.GetParent(mainLists.basePath);
                mainLists.basePath = parentDir.ToString();

                var di = new DirectoryInfo(mainLists.projectDir);
                var di_base = new DirectoryInfo(mainLists.basePath);
                di.Attributes &= ~FileAttributes.ReadOnly;
                di_base.Attributes &= ~FileAttributes.ReadOnly;

                foreach (var file in di.GetFiles("*", SearchOption.AllDirectories))
                    file.Attributes &= ~FileAttributes.ReadOnly;

                
                //var baseDir = Directory.GetParent(path.EndsWith("\\") ? path : string.Concat(path, "\\"));

                // TODO: if file already exists, replace
                ZipFile.CreateFromDirectory(mainLists.projectDir, mainLists.basePath + "\\"+ mainLists.projectName +".zip");
            }
            else
            {
                /*string[] files = textBox1.Text.Split(',');
                ZipArchive zip = ZipFile.Open(saveFileDialog1.FileName, ZipArchiveMode.Create);
                foreach (string file in files)
                {
                    zip.CreateEntryFromFile(file, Path.GetFileName(file), CompressionLevel.Optimal);
                }
                zip.Dispose();*/
            }

            var compressedPath = mainLists.basePath + "\\" + mainLists.projectName + ".zip";
            var result = Path.ChangeExtension(mainLists.basePath + "\\" + mainLists.projectName + ".zip", ".ppprj");

            File.Move(compressedPath, Path.ChangeExtension(compressedPath, ".ppprj"));
            //myfile.replace(extension, ".Jpeg");
            MessageBox.Show("PPProj file created successfully!");
        }

        private void SaveProjectFile()
        {

        }

        private void SaveCharacterList(string filepath)
        {
            StreamWriter sw = new StreamWriter(filepath);
            StringBuilder builder = new StringBuilder();
            string charFolder;

            foreach(Character c in mainLists.characterList)
            {
                string rawText = c.Name;
                long num = c.Number;
                builder.Append(rawText);
                builder.Append(',');
                builder.Append(num.ToString());
                builder.Append("\n");

                charFolder = c.Name.ToLower().Replace(" ", string.Empty) + c.Number.ToString();
                SaveCharacterInfo(Path.GetDirectoryName(filepath) + "\\" + charFolder + "\\" + c.Name.ToLower().Replace(" ", string.Empty) + ".info", c);
            }

            sw.Write(builder.ToString());
            sw.Flush();

            sw.Close();
        }

        private void SaveCharacterInfo(string filepath, Character c)
        {
            StreamWriter sw = new StreamWriter(filepath);
            StringBuilder builder = new StringBuilder();
            string folder = Path.GetDirectoryName(filepath);

            builder.Append("Name:");
            builder.Append(c.Name);
            builder.Append("\n");

            builder.Append("Age:");
            builder.Append(c.charAge);
            builder.Append("\n");

            if(c.charGender != null)
            {
                builder.Append("Gender:");
                builder.Append(c.charGender);
                builder.Append("\n");
            }
            if(c.charKind != null)
            {
                builder.Append("Race:");
                builder.Append(c.charKind);
                builder.Append("\n");
            }
            if(c.DescFile != null)
            {
                builder.Append("Description:desc.txt\n");
            }
            if(c.charRole != null)
            {
                builder.Append("Role:");
                builder.Append(c.charRole);
                builder.Append("\n");
            }
            if(c.charLanguage != null)
            {
                builder.Append("Language:");
                builder.Append(c.charLanguage);
                builder.Append("\n");
            }
            if(c.charHometown != null)
            {
                builder.Append("Hometown:");
                builder.Append(c.charHometown);
                builder.Append("\n");
            }

            sw.Write(builder.ToString());
            sw.Flush();

            sw.Close();
        }

        private void SaveLocationList(string filepath)
        {
            StreamWriter sw = new StreamWriter(filepath);
            StringBuilder builder = new StringBuilder();
            string locFolder;

            foreach (Location l in mainLists.locationList)
            {
                string rawText = l.Name;
                long num = l.Number;
                builder.Append(rawText);
                builder.Append(',');
                builder.Append(num.ToString());
                builder.Append("\n");

                locFolder = l.Name.ToLower().Replace(" ", string.Empty) + l.Number.ToString();
                SaveLocationInfo(Path.GetDirectoryName(filepath) + "\\" + locFolder + "\\" + l.Name.ToLower().Replace(" ", string.Empty) + ".info", l);
            }

            sw.Write(builder.ToString());
            sw.Flush();
            sw.Close();
        }

        private void SaveLocationInfo(string filepath, Location l)
        {
            StreamWriter sw = new StreamWriter(filepath);
            StringBuilder builder = new StringBuilder();

            if(l is Building)
            {
                Building temp = (Building)l;

                builder.Append("Building\n");

                //Name needs to be near top to reduce amount of storage required before instatiation of new object during load
                SaveGeneralLocData(ref builder, l);

                if (temp.getnumStories != null)
                {
                    builder.Append("Stories:");
                    builder.Append(temp.getnumStories);
                    builder.Append("\n");
                }

                builder.Append("Rooms:");
                builder.Append(temp.numRooms);
                builder.Append("\n");
                

                builder.Append("Dimensions:");
                builder.Append(temp.myDimensions.x);
                builder.Append(',');
                builder.Append(temp.myDimensions.y);
                builder.Append(',');
                builder.Append(temp.myDimensions.z);
                builder.Append(',');
                builder.Append(temp.myDimensions.myMeasurement.ToString());
                builder.Append("\n");


            }
            else if(l is City)
            {
                City temp = (City)l;

                //Name needs to be near top to reduce amount of storage required before instatiation of new object during load
                SaveGeneralLocData(ref builder, l);

                builder.Append("City\n");

                builder.Append("Population:");
                builder.Append(temp.population);
                builder.Append("\n");

                builder.Append("Size:");
                builder.Append(temp.MySize.ToString());
                builder.Append("\n");

                if(temp.region != null)
                {
                    builder.Append("Region:");
                    builder.Append(temp.region.ToString());
                    builder.Append("\n");
                }
            }
            else if (l is Country)
            {
                Country temp = (Country)l;

                //Name needs to be near top to reduce amount of storage required before instatiation of new object during load
                SaveGeneralLocData(ref builder, l);

                builder.Append("Country\n");

                if(temp.region != null)
                {
                    builder.Append("Region:");
                    builder.Append(temp.region.ToString());
                    builder.Append("\n");
                }

                builder.Append("Government:");
                builder.Append(temp._ocracy.ToString());
                builder.Append("\n");

                builder.Append("Economy:");
                builder.Append(temp.economy.ToString());
                builder.Append("\n");

                builder.Append("Citizens:");
                builder.Append(temp.citizens.ToString());
                builder.Append("\n");
            }
            else if (l is Planet)
            {
                Planet temp = (Planet)l;

                //Name needs to be near top to reduce amount of storage required before instatiation of new object during load
                SaveGeneralLocData(ref builder, l);

                builder.Append("Planet\n");

                builder.Append("Technology:");
                builder.Append(temp.getLevel().ToString());
                builder.Append("\n");

                builder.Append("Population:");
                builder.Append(temp.population.ToString());
                builder.Append("\n");

                builder.Append("Biome:");
                builder.Append(temp.myLand.ToString());
                builder.Append("\n");
            }
            else if (l is Region)
            {
                builder.Append("Region\n");

                //Name needs to be near top to reduce amount of storage required before instatiation of new object during load
                SaveGeneralLocData(ref builder, l);
            }
            else if (l is room)
            {
                room temp = (room)l;

                //Name needs to be near top to reduce amount of storage required before instatiation of new object during load
                SaveGeneralLocData(ref builder, l);

                builder.Append("Room\n");

                builder.Append("Dimensions:");
                builder.Append(temp.myRoom.x);
                builder.Append(',');
                builder.Append(temp.myRoom.y);
                builder.Append(',');
                builder.Append(temp.myRoom.usedMeasurement.ToString());
                builder.Append("\n");
            }
            else //if l is Location
            {
                builder.Append("Location\n");

                //Name needs to be near top to reduce amount of storage required before instatiation of new object during load
                SaveGeneralLocData(ref builder, l);
            }
            
        }

        private void SaveGeneralLocData(ref StringBuilder builder, Location l)
        {
            builder.Append("Name:");
            builder.Append(l.Name);
            builder.Append("\n");

            if (l.DescFile != null)
            {
                builder.Append("Description:desc.txt\n");
            }
            if (l.HistFile != null)
            {
                builder.Append("History:hist.txt\n");
            }
            if (l.map_file != null)
            {
                builder.Append("Map:map.jpg");
            }
        }
    }
}
