using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGit.Lib
{
    public class City : Location
    {
        protected int myPopulation; //Population of the town
        public enum size { XSmall, Small, Medium, Large, XLarge }; //Size of the town, this might need to go in the parent class
        protected size mySize;
        public City(int pop, size theSize, string name, string desc, string hist, List<string> images) : base(name, desc, hist, images) {
            myPopulation = pop;
            mySize = theSize;
        }
        public  int population	{ get; set; } //Get and set the population
        public  size theSize	{ get; set; } //Get and set the size of the town/City
        public  Region region	{ get; set; }
   //     public  Country state	{ 
			//get { return state; }
   //         set { state = value; if (state.region != null) region = state.region; }
   //     }
    }
}
