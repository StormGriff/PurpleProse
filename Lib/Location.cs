﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGit.Lib
{
    public class Location : Object
    {
        public enum measurement { Inches, Centimeters, Feet, Meters, Yard, Lightyear };
        public string map_file { get; set; }
        public Location(string name, string desc = null, string hist = null, List<string> images = null) : base(name, desc, hist, images)
        { }

        public string size { get; set; }//Ex: 125 Leagues squared.	We could trun this into it its own object of class Size{ uint value; units; dimensions; }
    }
}
