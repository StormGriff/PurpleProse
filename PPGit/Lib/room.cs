using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PPGit.Lib
{
    public class room : Location
    {
        private struct dimensions
        {
            public double x;
            public double y;
            public mainLists.measurement usedMeasurement;
        }
        dimensions myRoom;

        public room(double x, double y, mainLists.measurement measuredIn, string name, string desc, string hist, List<string> images) : base(name, desc, hist, images)
        {
            myRoom = new dimensions();
            myRoom.x = x;
            myRoom.y = y;
            myRoom.usedMeasurement = measuredIn;
        }
        public room(Location theLoc) : base(theLoc) {

        }

        public double[] getDimensions
        { //The first element in the array is x, the second is y
            set
            {
                myRoom.x = value[0];/*
				*/
                myRoom.y = value[1];
            }

            get
            {
                double[] myDim = new double[2];/*
				*/
                myDim[0] = myRoom.x;            /*
				*/
                myDim[1] = myRoom.y;            /*
				*/
                return myDim;/*				*/
            }
        }

        public mainLists.measurement measuringIn
        {
            get { return myRoom.usedMeasurement; }
            set { myRoom.usedMeasurement = value; }
        }
        private Building complex;
        public Building Complex
        {
            get { return complex; }
            set { complex = value; }
        }
    }
}
