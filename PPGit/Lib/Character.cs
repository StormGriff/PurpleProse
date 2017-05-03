using System.Collections.Generic;
using System.IO;

namespace PPGit.Lib
{
    // Behaviors per an instance of a character
    public class Character : Object 
    {
        //private string charName;
        //private string charDesc;
        //private string charHist;
        //private List<string> images;

        // Using Properties: Character attribute file names + extension
        public long		charAge		{ get; set; }
        public string	charKind	{ get; set; } // Make a list struct
        public string	charGender	{ get; set; } // Make a list struct
        public string	charRole	{ get; set; }
        public string	charSketches{ get; set; }
        public string	charLanguage{ get; set; } // Make a list struct
        public string	charHometown{ get; set; } 
        public enum kindTypes { Null, Human, Animal, Plant, Cyborg};
        public enum humanLanguage { English, Hebrew, Japanese, Mandarin, Cantonese, German, Swahili, Tagalog };
        public enum gender { Female, Male, NotInList, NULL };

        public string charBioFile	{ get; set; } // filename of the text that contains all info, including txt file names of desc, hist, sketches

        //public Character() : base(null, null, null, null)
        //{}

        public Character(string charName, string charDesc = null, string charHist = null, List<string> images = null,
                        int charAge = 0, string charKind = null, string charGender = null, string charRole = null,
                        string charSketches = null, string charLanguage = null, string charHometown = null)
            : base(charName, charDesc, charHist, images)
        {
            this.charAge = charAge;
            this.charKind = charKind;
            this.charGender = charGender;
            this.charRole = charRole;
            this.charSketches = charSketches;
            this.charLanguage = charLanguage;
            this.charHometown = charHometown;
        }

        public string[] GetCharSketchesText()
        { 
            string[] charSketchesText = File.ReadAllLines(charSketches);
            return charSketchesText;
        }

        public void WriteCharSketches(string[] charSketchesText)
			{ File.WriteAllLines(charSketches, charSketchesText); }

        /*
        public void StoreCharInfoToText()
        {
            object[] charInfoStr = { getName(), // character's name
                                     charAge,
                                   };
        }
        * // Make a function that stores a objects into a file (see serializable)
        */
    }
}
