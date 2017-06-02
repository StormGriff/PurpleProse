using System;
using System.Windows.Controls;

using MahApps.Metro.Controls;


namespace PPGit.GUI.MoreInfo
{
    /// <summary>
    /// Interaction logic for planetInfo.xaml
    /// </summary>
    public partial class PlanetInfo : MetroWindow
    {
        Lib.Planet thisLoc;
        public PlanetInfo(Lib.Location theLoc)
        {
            thisLoc = (Lib.Planet)theLoc;
            InitializeComponent();
        }

        private void planetInfoFRM_Closed(object sender, EventArgs e)
        {
            (thisLoc.window as DetailWindows.LocationWindow).openWindow = false;
        }

        private void planetInfoFRM_Initialized(object sender, EventArgs e)
        {
            popTXT.Text = thisLoc.population.ToString();

            techBX.Items.Add(Lib.Planet.technologyLevel.Primitive); //Populate technology drop down
            techBX.Items.Add(Lib.Planet.technologyLevel.PreIndustrial);
            techBX.Items.Add(Lib.Planet.technologyLevel.Industrial);
            techBX.Items.Add(Lib.Planet.technologyLevel.PreWarp);
            techBX.Items.Add(Lib.Planet.technologyLevel.Modern);
            techBX.Items.Add(Lib.Planet.technologyLevel.Spacefaring);
            techBX.SelectedItem = thisLoc.getLevel();

            biomBX.Items.Add(Lib.Planet.biome.Alpine); //Populate biome drop down
            biomBX.Items.Add(Lib.Planet.biome.Chaparral);
            biomBX.Items.Add(Lib.Planet.biome.Desert);
            biomBX.Items.Add(Lib.Planet.biome.Grassland);
            biomBX.Items.Add(Lib.Planet.biome.Rainforest);
            biomBX.Items.Add(Lib.Planet.biome.Taiga);
            biomBX.SelectedItem = thisLoc.myLand;
        }

        private void popTXT_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                thisLoc.population = Convert.ToInt32(popTXT.Text);
            }
            catch (InvalidCastException) { }
        }

        private void techBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                thisLoc.setLevel((Lib.Planet.technologyLevel)techBX.SelectedItem);
            }
            catch (NullReferenceException) { }
        }

        private void biomBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                thisLoc.myLand = (Lib.Planet.biome)biomBX.SelectedItem;
            }
            catch (NullReferenceException) { }
        }
    }
}
