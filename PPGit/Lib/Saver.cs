using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            return success;
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
        }

        private void SaveLocationInfo(string filepath, Location l)
        {

        }
    }
}
