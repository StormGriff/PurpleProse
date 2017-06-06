using System;
using System.Windows.Controls;

using MahApps.Metro.Controls;


namespace PPGit.GUI.MoreInfo
{
    /// <summary>
    /// Interaction logic for roomInfo.xaml
    /// </summary>
    public partial class roomInfo : MetroWindow
    {
        private Lib.room thisLoc;
        public roomInfo(Lib.Location theLoc)
        {
            thisLoc = (Lib.room)theLoc;
            InitializeComponent();
        }

        private void roomInfoFRM_Closed(object sender, EventArgs e)
        {
            if (thisLoc.window != null)
            {
                (thisLoc.window as DetailWindows.LocationWindow).openWindow = false;
            }
        }

        private void roomInfoFRM_Initialized(object sender, EventArgs e)
        {
            lengthTXT.Text = thisLoc.getDimensions[0].ToString();
            widthTXT.Text = thisLoc.getDimensions[1].ToString();

            unitBX.Items.Add(mainLists.measurement.Centimeters); //Populate units drop down
            unitBX.Items.Add(mainLists.measurement.Feet);
            unitBX.Items.Add(mainLists.measurement.Inches);
            unitBX.Items.Add(mainLists.measurement.Meters);
            unitBX.Items.Add(mainLists.measurement.Yard);
            unitBX.SelectedItem = thisLoc.measuringIn;

            foreach (Lib.Location theLoc in mainLists.locationList) {
                if (theLoc is Lib.Building) {
                    buildingBX.Items.Add(theLoc);
                }
            }
            buildingBX.SelectedItem = thisLoc.Complex;
        }

        private void setDimensions() {
            if (lengthTXT.Text != "" && widthTXT.Text != "") {
                try
                {
                    double[] dim = new double[2];
                    dim[0] = Convert.ToDouble(lengthTXT.Text);
                    dim[1] = Convert.ToDouble(widthTXT.Text);
                    thisLoc.getDimensions = dim;
                }
                catch (InvalidCastException) { }
            }
        }

        private void lengthTXT_TextChanged(object sender, TextChangedEventArgs e)
        {
            setDimensions();
        }

        private void widthTXT_TextChanged(object sender, TextChangedEventArgs e)
        {
            setDimensions();
        }

        private void unitBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                thisLoc.measuringIn = (mainLists.measurement)unitBX.SelectedItem;
            }
            catch (NullReferenceException) { }
        }

        private void buildingBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                thisLoc.Complex = (Lib.Building)buildingBX.SelectedItem;
            }
            catch (NullReferenceException) { }
        }
    }
}
