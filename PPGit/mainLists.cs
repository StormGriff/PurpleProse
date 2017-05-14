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
        public static string projectDir = null;
        public static ObservableCollection<PPGit.Lib.Character> characterList = new ObservableCollection<Lib.Character>();
        public static ObservableCollection<PPGit.Lib.Location> locationList = new ObservableCollection<Lib.Location>();
    }
}
