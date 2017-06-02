using System;
using System.Windows.Controls;

using MahApps.Metro.Controls;


namespace PPGit.GUI.MoreInfo
{
    /// <summary>
    /// Interaction logic for country.xaml
    /// </summary>
    public partial class country : MetroWindow
    {
        Lib.Country thisLoc;
        public country(Lib.Location loc)
        {
            thisLoc = (Lib.Country)loc;
            InitializeComponent();
        }

        private void countryInfoFRM_Closed(object sender, EventArgs e)
        {
            (thisLoc.window as DetailWindows.LocationWindow).openWindow = false;
        }

        private void countryInfoFRM_Initialized(object sender, EventArgs e)
        {
            econBX.Items.Add(Lib.Country.economies.Capitalist); //Populate economies drop down
            econBX.Items.Add(Lib.Country.economies.Socialist);
            econBX.SelectedItem = thisLoc.economy;

            govBX.Items.Add(Lib.Country.government.Democracy); //Populate government drop down
            govBX.Items.Add(Lib.Country.government.Dictatorship);
            govBX.Items.Add(Lib.Country.government.Monarchy);
            govBX.Items.Add(Lib.Country.government.Theocracy);
            govBX.Items.Add(Lib.Country.government.Confederation);
            govBX.Items.Add(Lib.Country.government.Communist);
            govBX.SelectedItem = thisLoc._ocracy;

            foreach (Lib.Location loc in mainLists.locationList) { //Populate region drop down
                if(loc is Lib.Region)
                {
                    regBX.Items.Add(loc);
                }
            }
            regBX.SelectedItem = thisLoc.regio;

            citizensTXT.Text = thisLoc.citizens.ToString();
        }

        private void citizensTXT_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                thisLoc.citizens = Convert.ToInt32(citizensTXT.Text);
            }
            catch (InvalidCastException) { }
        }

        private void govBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                thisLoc._ocracy = (Lib.Country.government)govBX.SelectedItem;
            }
            catch (NullReferenceException) { }
        }

        private void econBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                thisLoc.economy = (Lib.Country.economies)econBX.SelectedItem;
            }
            catch (NullReferenceException) { }
        }

        private void regBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                thisLoc.regio = (Lib.Region)regBX.SelectedItem;
            }
            catch (NullReferenceException) { }
        }
    }
}
