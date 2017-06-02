using System;
using System.Windows.Controls;

using MahApps.Metro.Controls;


namespace PPGit.GUI.MoreInfo
{
    /// <summary>
    /// Interaction logic for Building.xaml
    /// </summary>
    public partial class Building : MetroWindow
    {
        Lib.Building thisBuilding;
        public Building(Lib.Location theLoc)
        {
            thisBuilding = (Lib.Building)theLoc;
            InitializeComponent();
        }

        private void buildingInfo_Initialized(object sender, EventArgs e)
        {
            widthTXT.Text = thisBuilding.getWidth.ToString();
            heightTXT.Text = thisBuilding.getHeight.ToString();
            lengthTXT.Text = thisBuilding.getLength.ToString();
            storiesTXT.Text = thisBuilding.getnumStories.ToString();
            roomsTXT.Text = thisBuilding.numRooms.ToString();
            measurementBX.Items.Add(mainLists.measurement.Inches); //Add values to combo box
            measurementBX.Items.Add(mainLists.measurement.Centimeters);
            measurementBX.Items.Add(mainLists.measurement.Feet);
            measurementBX.Items.Add(mainLists.measurement.Meters);
            measurementBX.Items.Add(mainLists.measurement.Yard);

            measurementBX.SelectedItem = thisBuilding.getMeasurement;
        }

        private void changeDimensions() {
            try
            {
                mainLists.measurement measure;
                if (measurementBX.SelectedValue.ToString() == "Inches") measure = mainLists.measurement.Inches;
                else if (measurementBX.SelectedValue.ToString() == "Centimeters") measure = mainLists.measurement.Centimeters;
                else if (measurementBX.SelectedValue.ToString() == "Feet") measure = mainLists.measurement.Feet;
                else if (measurementBX.SelectedValue.ToString() == "Yard") measure = mainLists.measurement.Yard;
                else measure = mainLists.measurement.Meters;
                try
                {
                    thisBuilding.setDimensions(Convert.ToInt32(heightTXT.Text), Convert.ToInt32(widthTXT.Text), Convert.ToInt32(lengthTXT.Text), measure);
                }
                catch (InvalidCastException) { }
            }
            catch (NullReferenceException) { }
        }

        private void widthTXT_TextChanged(object sender, TextChangedEventArgs e)
        {
            changeDimensions();
        }

        private void lengthTXT_TextChanged(object sender, TextChangedEventArgs e)
        {
            changeDimensions();
        }

        private void heightTXT_TextChanged(object sender, TextChangedEventArgs e)
        {
            changeDimensions();
        }

        private void measurementBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            changeDimensions();
        }

        private void storiesTXT_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!thisBuilding.setNumStories(storiesTXT.Text)) storiesTXT.Text = "";
        }

        private void roomsTXT_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                thisBuilding.numRooms = Convert.ToInt32(roomsTXT.Text);
            }
            catch (InvalidCastException) { }
        }

        private void buildingInfo_Closed(object sender, EventArgs e)
        {
            (thisBuilding.window as DetailWindows.LocationWindow).openWindow = false;
        }
    }
}
