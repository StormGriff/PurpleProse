using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGit.Lib
{
    public class Location : Object
    {
        public string map_file { get; set; }
        public Location(string name, string desc = null, string hist = null, List<string> images = null) : base(name, desc, hist, images)
        {
            parent = null;
            theSize = new size();
            theSize.num = 0;
        }

        public size theSize;

        public Location parent { get; set; }
    }
}
