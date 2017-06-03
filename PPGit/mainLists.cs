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
        public static long objNum = 0;
        public static string projectDir = null; // Root dir
        public static ObservableCollection<PPGit.Lib.Character> characterList = new ObservableCollection<Lib.Character>();
        public static ObservableCollection<PPGit.Lib.Location> locationList = new ObservableCollection<Lib.Location>();
        public static long wordCount = 0;
        public static string storyLocation = null; //Location of the story (doesn't include file name of story)
        public static string locationToSaveTo = null;
        public static GUI.TextEditor.TextEditor fullEditor = null;  //Text editor for full story

        public static int chapterCount = 0;
    }
}
