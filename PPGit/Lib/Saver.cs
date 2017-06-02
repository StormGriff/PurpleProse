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

            foreach(Character c in mainLists.characterList)
            {
                string rawText = c.Name;
                long num = c.Number;
                builder.Append(rawText);
                builder.Append(',');
                builder.Append(num.ToString());
                builder.Append("\n");
            }

            sw.Write(builder.ToString());
            sw.Flush();
        }

        private void SaveCharacterInfo()
        {

        }

        private void SaveLocationList(string filepath)
        {

        }

        private void SaveLocationInfo()
        {

        }
    }
}
