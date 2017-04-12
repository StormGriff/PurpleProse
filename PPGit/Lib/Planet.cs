using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGit.Lib
{
    public class Planet : Location
    {
        public Planet(int pop, biome land, technologyLevel developement, string name, string desc, string hist, string imageFile, string other = "") : base(name, desc, hist, imageFile)
        {
            population = pop;
            myLevel = developement;
            myLand = land;
            if (myLevel == technologyLevel.Other) otherLevel = other;
        }
        public enum technologyLevel {Primitive, PreWarp, Modern, Spacefaring, PreIndustrial, Other}; //Not sure if we need more
        string otherLevel; //If the user chose other
        public  enum biome {Taiga, Grassland, Chaparral, Desert, Rainforest, Alpine};
        public  long population { get; set; }
        private technologyLevel myLevel;
        public  biome myLand	{ get; set; }

        public void setLevel(technologyLevel theLevel, string other = "") { //Set the technology level
            theLevel = myLevel;
            if (myLevel == technologyLevel.Other) otherLevel = other;
        }
        public string getLevel() { //Get the technology level
            if (myLevel == technologyLevel.Other) return otherLevel;
            return myLevel.ToString();
        }
    }
}
