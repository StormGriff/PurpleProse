using System;
using System.Windows.Controls;

using MahApps.Metro.Controls;


namespace PPGit.GUI.MoreInfo
{
    /// <summary>
    /// Interaction logic for city.xaml
    /// </summary>
    public partial class city : MetroWindow
    {
        private Lib.City thisLoc;
        public city(Lib.Location theLoc)
        {
            thisLoc = (Lib.City)theLoc;
            InitializeComponent();
        }

        private void cityInfoFRM_Initialized(object sender, EventArgs e)
        {
            foreach (Lib.Location myLoc in mainLists.locationList) { //Add regions
                if (myLoc is Lib.Region) {
                    regionBX.Items.Add(myLoc);
                }
            }

            if (thisLoc.region is Lib.Region) {
                regionBX.SelectedItem = thisLoc.region;
            }

            sizeBX.Items.Add(Lib.City.size.XSmall); //Add sizes
            sizeBX.Items.Add(Lib.City.size.Small);
            sizeBX.Items.Add(Lib.City.size.Medium);
            sizeBX.Items.Add(Lib.City.size.Large);
            sizeBX.Items.Add(Lib.City.size.XLarge);
            sizeBX.SelectedValue = thisLoc.MySize;

            popTXT.Text = thisLoc.population.ToString();
        }

        private void popTXT_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                thisLoc.population = Convert.ToInt32(popTXT.Text);
            }
            catch (InvalidCastException) {
                popTXT.Text = "";
            }
        }

        private void sizeBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                thisLoc.MySize = (Lib.City.size)sizeBX.SelectedItem;
            }
            catch (NullReferenceException) { }
        }

        private void regionBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                thisLoc.region = (Lib.Region)regionBX.SelectedItem;
            }
            catch (NullReferenceException) { }
        }

        private void cityInfoFRM_Closed(object sender, EventArgs e)
        {
            if (thisLoc.window != null)
            {
                (thisLoc.window as DetailWindows.LocationWindow).openWindow = false;
            }
        }
    }
}
