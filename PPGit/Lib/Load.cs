using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Win32;


namespace PPGit.Lib
{
    public class Loader
    {
        /// <summary>
        /// Executes a load operation for a full project
        /// User should select a .proj file
        /// </summary>
        public void Load()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Project File .proj|*.proj";
            string directory;

            ofd.InitialDirectory = "C:\\";

            if (ofd.ShowDialog() == true)
            {
                directory = Path.GetDirectoryName(ofd.FileName);
                mainLists.projectDir = directory;
                LoadProjectFile(ofd.FileName);
                LoadCharacterList(directory + "\\items\\characters\\char.list");
                LoadLocationList(directory + "\\items\\locations\\loc.list");
            }
            else
            {

            }
        }

        private void LoadProjectFile(string filepath)
        {
            FileStream fs = File.Open(filepath, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line;

            while (!sr.EndOfStream) { line = sr.ReadLine(); }
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

                lines = line.Split(new char[] { ',' }).ToList();

                folderName = lines.ElementAt(0).Replace(" ", string.Empty).ToLower() + lines.ElementAt(1);

                LoadCharacterInfo(Path.GetDirectoryName(filepath) + "\\" + folderName, lines.ElementAt(0).Replace(" ", string.Empty).ToLower());
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

                if (lines.ElementAt(0) == "Age") c.charAge = Convert.ToInt32(lines.ElementAt(1));

                if (lines.ElementAt(0) == "Race") c.charKind = lines.ElementAt(1);

                if (lines.ElementAt(0) == "Gender") c.charGender = lines.ElementAt(1);

                if (lines.ElementAt(0) == "Role") c.charRole = lines.ElementAt(1);

                if (lines.ElementAt(0) == "Language") c.charLanguage = lines.ElementAt(1);

                if (lines.ElementAt(0) == "Hometown") c.charHometown = lines.ElementAt(1);

                if (lines.ElementAt(0) == "Description") c.DescFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();

                if (lines.ElementAt(0) == "Text") /*TODO*/;

                if (lines.ElementAt(0) == "Image") c.Images.Add(filepath + "\\images\\" + lines.ElementAt(1).ToString());
            }
            c.Number = mainLists.objNum;

            //c.window = new PPGit.GUI.DetailWindows.CharacterWindow(c);
            mainLists.objNum++;
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
            List<string> lines = new List<string>();
            PPGit.Lib.Location c;

            //reads the first line, which is the name
            //allows the instantiation for c, since the character class requires a name parameter
            line = sr.ReadLine();
            lines = line.Split(new char[] { ':' }).ToList();

            //name
            c = new Location(lines.ElementAt(1));

            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();

                lines = line.Split(new char[] { ':' }).ToList();

                if (lines.ElementAt(0) == "Description") c.DescFile = filepath + "\\texts\\" + lines.ElementAt(1).ToString();

                if (lines.ElementAt(0) == "Size") c.size = lines.ElementAt(1);
            }
            c.Number = mainLists.objNum;

            mainLists.objNum++;
            PPGit.mainLists.locationList.Add(c);
        }
    }
}