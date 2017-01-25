using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleProse.Lib
{
    public class Country : Location
    {	public Country(string name, string desc, string hist, string imageFile) : base(name, desc, hist, imageFile) { }
        
		public  Region regio   { get; set; }
		public  string _ocracy { get; set; } //Ex: Theocracy Democracy
		public  string values  { get; set; } //Ex: Totalatarian, Left_wing right_wing
		public  string economy { get; set; } //Ex: Communist, Market; Free Restricted Controled
    }
}
