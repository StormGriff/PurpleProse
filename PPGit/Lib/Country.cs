using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGit.Lib
{
    public class Country : Location
    {
        public enum government { Monarchy, Democracy, Dictatorship, Theocracy, Confederation, Communist }
        public enum economies { Capitalist, Socialist }
        public Country(string name, string desc, string hist, List<string> images) : base(name, desc, hist, images) { }

        public Country(Location theLoc) : base(theLoc) {

        }

        public Region region { get; set; }
        public government _ocracy { get; set; }
        public economies economy { get; set; }
        public int citizens { get; set; }
    }
}

