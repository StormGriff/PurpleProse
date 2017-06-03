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

using MahApps.Metro.Controls;

namespace PPGit.GUI.NewObject
{
    /// <summary>
    /// Interaction logic for NewItemWizard.xaml
    /// </summary>
    public partial class NewItemWizard : MetroWindow
    {
        mainLists.ItemTypes type;
        public bool DialogRes;

        public NewItemWizard()
        {
            InitializeComponent();
        }

        public mainLists.ItemTypes GetSelectedItemType()
        {
            //take the selected item as string, and manipulate it to get the text content
            string content = lstList.SelectedItem.ToString().Split(new char[] { ':' }).ElementAt(1).Replace(" ", string.Empty);
            if(content == "Character")
            {
                type = mainLists.ItemTypes.Character;
            }
            else if(content == "Location")
            {
                type = mainLists.ItemTypes.Location;
            }
            else if(content == "Building(Location)")
            {
                type = mainLists.ItemTypes.Building;
            }
            else if (content == "City(Location)")
            {
                type = mainLists.ItemTypes.City;
            }
            else if (content == "Country(Location)")
            {
                type = mainLists.ItemTypes.Country;
            }
            else if (content == "Planet(Location)")
            {
                type = mainLists.ItemTypes.Planet;
            }
            else if (content == "Region(Location)")
            {
                type = mainLists.ItemTypes.Region;
            }
            else if (content == "Room(Location)")
            {
                type = mainLists.ItemTypes.Room;
            }

            return type;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogRes = false;
            this.Close();
        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            DialogRes = true;
            this.Close();
        }
    }
}
