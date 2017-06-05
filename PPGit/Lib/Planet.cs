using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGit.Lib
{
    public class Planet : Location
    {
        public Planet(int pop, biome land, technologyLevel developement, string name, string desc, string hist, List<string> images) : base(name, desc, hist, images)
        {
            population = pop;
            myLevel = developement;
            myLand = land;
        }
        public Planet(Location theLoc) : base(theLoc) {

        }
        public enum technologyLevel { Primitive, PreWarp, Modern, Spacefaring, PreIndustrial, Industrial}; //Not sure if we need more
        public enum biome { Taiga, Grassland, Chaparral, Desert, Rainforest, Alpine };
        public long population { get; set; }
        private technologyLevel myLevel;
        public biome myLand { get; set; }

        public void setLevel(technologyLevel theLevel)
        { //Set the technology level
            theLevel = myLevel;
        }
        public technologyLevel getLevel()
        { //Get the technology level
            return myLevel;
        }
    }
}
