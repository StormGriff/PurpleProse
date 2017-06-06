using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGit
{
    public static class mainLists
    {
        public enum measurement { Inches, Centimeters, Feet, Meters, Yard, Lightyear };
        public enum ItemTypes { Character, Location, Building, City, Country, Planet, Region, Room};
        public static long objNum = 0;
        public static string projectDir = null;
        public static ObservableCollection<PPGit.Lib.Character> characterList = new ObservableCollection<Lib.Character>();
        public static ObservableCollection<PPGit.Lib.Location> locationList = new ObservableCollection<Lib.Location>();
        public static long wordCount = 0;
        public static string storyLocation = null; //Location of the story
        public static string locationToSaveTo = null;
        public static GUI.TextEditor.TextEditor fullEditor = null;  //Text editor for full story
        public static string storyTitle = null; //title of story

        public static int chapterCount = 0;
    }
}
