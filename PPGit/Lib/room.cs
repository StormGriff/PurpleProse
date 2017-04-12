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
        private struct dimensions {
            public double x;
            public double y;
            public measurement usedMeasurement;
        }
        dimensions myRoom;
        private string myDescription;

        public room(double x, double y, measurement measuredIn, string descriptionFile, string name, string desc, string hist, string imageFile) : base(name, desc, hist, imageFile) {
			myRoom = new dimensions();
			myRoom.x = x;
			myRoom.y = y;
			myRoom.usedMeasurement = measuredIn;
			this.myDescription = descriptionFile;
		}

        public double[] getDimensions { //The first element in the array is x, the second is y
			set { myRoom.x = value[0];/*
				*/myRoom.y = value[1]; }
			
			get { double[] myDim = new double[2];/*
				*/myDim[0] = myRoom.x;			/*
				*/myDim[1] = myRoom.y;			/*
				*/return myDim;/*				*/ }
		}

        public measurement measuringIn {
            get { return myRoom.usedMeasurement; }
            set { myRoom.usedMeasurement = value; }
        }
        private Building complex;
        public Building Complex {
			get { return complex; }
            set { complex = value; }
        }
    }
}
