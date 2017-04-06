using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleProse.Lib
{
    public class Location : Object
    {
        public  enum measurement { Inches, Centimeters, Feet, Meters, Yard, Lightyear };
        public  string map_file { get; set; }
        public  Location(string name, string desc, string hist, string imageFile) : base(name, desc, hist, imageFile)
		{}
            
        public string size { get; set; }//Ex: 125 Leagues squared.	We could trun this into it its own object of class Size{ uint value; units; dimensions; }
    }
}
