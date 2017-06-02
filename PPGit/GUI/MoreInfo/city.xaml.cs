using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PPGit.GUI.MoreInfo
{
    /// <summary>
    /// Interaction logic for city.xaml
    /// </summary>
    public partial class city : Window
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
            sizeBX.SelectedValue = thisLoc.relativeSize;

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
                thisLoc.relativeSize = (Lib.City.size)sizeBX.SelectedItem;
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
            (thisLoc.window as DetailWindows.LocationWindow).openWindow = false;
        }
    }
}
