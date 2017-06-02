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
using PPGit.Lib;

using MahApps.Metro.Controls;
using System.IO;

namespace PPGit.GUI.DetailWindows
{
    /// <summary>
    /// Interaction logic for LocationWindow.xaml
    /// </summary>
    public partial class LocationWindow : /*Adornment_Win/*/MetroWindow
    {
        private PPGit.Lib.Location Place;

        public bool openWindow;

        public LocationWindow(PPGit.Lib.Location place)
        {
            InitializeComponent();
            this.Place = place;
            this.Title = place.Name;
            Place.window = this;
            NameBox.Text = Place.Name;
            SizeBox.Text = Place.theSize.num.ToString();
            fillDescText();
            foreach (Lib.Location theLocs in mainLists.locationList) {
                if(theLocs.Name != place.Name) ParentLoc.Items.Add(theLocs.Name); //Add every location except this one
            }
            if (Place.parent != null) ParentLoc.SelectedValue = Place.parent.Name;
            measurementBX.Items.Add(mainLists.measurement.Centimeters/*.ToString()*/);
            measurementBX.Items.Add(mainLists.measurement.Feet/*.ToString()*/);
            measurementBX.Items.Add(mainLists.measurement.Inches/*.ToString()*/);
            measurementBX.Items.Add(mainLists.measurement.Lightyear/*.ToString()*/);
            measurementBX.Items.Add(mainLists.measurement.Meters/*.ToString()*/);
            measurementBX.SelectedValue = place.theSize.units/*.ToString()*/;
            //	ParentLoc.Text = Place.??.Name;
            //	LingBox.Text = Place.Language;
            //	RaceBox.Text = Place.Race;
            //	PopBox.Text = Place.Population;
            //	TerraBox.Text = Place.terrain;
            //	GovBox.Text = Place._ocracy;
            //	EconBox.Text = Place.economy;
            specialBX.Items.Add("Building");
            specialBX.Items.Add("City");
            specialBX.Items.Add("Country");
            specialBX.Items.Add("Planet");
            specialBX.Items.Add("Region");
            specialBX.Items.Add("Room");
            if (place is Lib.Building)
            {
                specialBX.SelectedValue = "Building";
            }
            else if (place is Lib.City)
            {
                specialBX.SelectedValue = "City";
            }
            else if (place is Lib.Country)
            {
                specialBX.SelectedValue = "Country";
            }
            else if (place is Lib.Planet)
            {
                specialBX.SelectedValue = "Planet";
            }
            else if (place is Lib.Region)
            {
                specialBX.SelectedValue = "Region";
            }
            else if (place is Lib.room) {
                specialBX.SelectedValue = "Room";
            }
            openWindow = false;

        }

        Binding name_binding;

        //Bug: Functions execute upon inital click. (Originally named XXX_LostKeyboardFocus)
        //ComboBox Tutorial: https://youtu.be/UDDYd3q5WM4

        private void NameBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
        { if (NameBox.Text != "") Place.Name = NameBox.Text; this.Title = Place.Name; }

        /*private void AgeBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (AgeBox.Text != "") try { Convert.ToInt64(AgeBox.Text); }
                catch (FormatException exc) { AgeBox.Clear(); }
                catch (OverflowException exc) { AgeBox.Text = "OvrFlo"; }
            //	else Place.Age = 0; 
        }*/

        private void SizeBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (SizeBox.Text != "")
            {
                string newText = "";
                foreach (char car in SizeBox.Text)
                {
                    if (char.IsDigit(car)) newText += car;
                }

                Place.theSize.num = Convert.ToInt32(newText);
            }
        }

        private void ParentLoc_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
        { /*Place. = ParentLoc.Text*/; }

        private void LingBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
        { /*Place.Langage = LingBox.Text*/; }

        private void RaceBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
        { /*Place.Race = RaceBox.Text*/; }

        /*private void PopBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (PopBox.Text != "") try {/*Place.population = Convert.ToInt64(PopBox.Text); }
                catch (FormatException exc) { PopBox.Clear(); }
                catch (OverflowException exc) { PopBox.Text = "OvrFlo"; }
        }*/

        private void TerraBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
        { /*Place.terrain = TerraBox.Text*/; }

        private void GovBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
        { /*Place._ocracy = GovBox.Text*/; }

        private void EconBox_LostKeyFocus(object sender, KeyboardFocusChangedEventArgs e)
        { /*Place.economy = EconBox.Text*/; }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) { Place.window = null; }

        private void DescBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Lib.TextOps.Open(Place);
            fillDescText();
        }

        private void fillDescText()
        {
            if (Place.DescFile != null)
            {
                FileStream fs = new FileStream(Place.DescFile, FileMode.Open);
                TextRange range = new TextRange(DescBox.Document.ContentStart, DescBox.Document.ContentEnd);
                range.Load(fs, DataFormats.Rtf);
                fs.Close();
            }
            else
            {
                TextRange range = new TextRange(DescBox.Document.ContentStart, DescBox.Document.ContentEnd);
                range.Text = "Double Click to add.";
            }
        }

        private void ParentLoc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Lib.Location theLoc in mainLists.locationList) {
                if (theLoc.Name == ParentLoc.SelectedItem.ToString()) Place.parent = theLoc;
            }
        }

        private void measurementBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (measurementBX.SelectedValue != null)
            {
                Place.theSize.units = (mainLists.measurement)measurementBX.SelectedValue;
            }
        }

        private void infoBTN_Click(object sender, RoutedEventArgs e)
        {
            if (!openWindow)
            {
                if (Place is Lib.Building)
                {
                    GUI.MoreInfo.Building info = new MoreInfo.Building(Place);
                    info.Show();
                    openWindow = true;
                }
                else if (Place is Lib.City)
                {
                    GUI.MoreInfo.city info = new MoreInfo.city(Place);
                    info.Show();
                    openWindow = true;
                }
                else if (Place is Lib.Country)
                {
                    GUI.MoreInfo.country info = new MoreInfo.country(Place);
                    info.Show();
                    openWindow = true;
                }
                else if (Place is Lib.Planet)
                {
                    GUI.MoreInfo.PlanetInfo info = new MoreInfo.PlanetInfo(Place);
                    info.Show();
                    openWindow = true;
                }
                else if (Place is Lib.Region)
                {
                    GUI.MoreInfo.regionInfo info = new MoreInfo.regionInfo(Place);
                    info.Show();
                    openWindow = true;
                }
                else if (Place is Lib.room) {
                    GUI.MoreInfo.roomInfo info = new MoreInfo.roomInfo(Place);
                    info.Show();
                    openWindow = true;
                }
            }
        }

        private void specialBX_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!openWindow)
            {
                Location old;
                if (specialBX.SelectedItem.ToString() == "Building" && !(Place is Lib.Building))
                { //Convert this location to a building
                    old = Place;
                    mainLists.locationList.Remove(Place);
                    Place = new Building(old);
                    mainLists.locationList.Add(Place);
                }
                else if (specialBX.SelectedItem.ToString() == "City" && !(Place is Lib.City))
                { //Convert place to city
                    old = Place;
                    mainLists.locationList.Remove(Place);
                    Place = new City(old);
                    mainLists.locationList.Add(Place);
                }
                else if (specialBX.SelectedItem.ToString() == "Country" && !(Place is Lib.Country))
                {
                    old = Place;
                    mainLists.locationList.Remove(Place);
                    Place = new Country(old);
                    mainLists.locationList.Add(Place);
                }
                else if (specialBX.SelectedItem.ToString() == "Planet" && !(Place is Lib.Planet))
                {
                    old = Place;
                    mainLists.locationList.Remove(Place);
                    Place = new Planet(old);
                    mainLists.locationList.Add(Place);
                }
                else if (specialBX.SelectedItem.ToString() == "Region" && !(Place is Lib.Region))
                {
                    old = Place;
                    mainLists.locationList.Remove(Place);
                    Place = new Region(old);
                    mainLists.locationList.Add(Place);
                }
                else if (specialBX.SelectedItem.ToString() == "Room" && !(Place is Lib.room)) {
                    old = Place;
                    mainLists.locationList.Remove(Place);
                    Place = new room(old);
                    mainLists.locationList.Add(Place);
                }
            }
            else {
                MessageBox.Show("Cannot complete while \"More Info\" window is open", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
