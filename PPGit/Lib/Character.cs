using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PurpleProse.Lib
{
    // Behaviors per an instance of a character
    public class Character : Object 
    {
        //private string charName;
        //private string charDesc;
        //private string charHist;
        //private string charImg;

        // Using Properties: Character attribute file names + extension
        public int		charAge		{ get; set; }
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

        public Character() : base(null, null, null, null)
        {}

        public Character(string charName, string charDesc, string charHist, string charImg,
                        int charAge, string charKind, string charGender, string charRole,
                        string charSketches, string charLanguage, string charHometown)
            : base(charName, charDesc, charHist, charImg)
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
