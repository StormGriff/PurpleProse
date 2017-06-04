using System;
using System.Collections.Generic;
using System.Data;
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

namespace PPGit.GUI
{
    /// <summary>
    /// Interaction logic for relationships.xaml
    /// </summary>
    public partial class relationships : Window
    {
        Lib.Character myChar;
        DataTable thisTable;
        public relationships(Lib.Character thisChar)
        {
            myChar = thisChar;
            thisTable = new DataTable();
            InitializeComponent();
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            string newName = "";
            foreach (char theChar in myChar.Name) {
                newName += char.ToUpper(theChar);
            }
            this.Title = newName + " RELATIONSHIPS"; //Change title
            thisTable.Columns.Add("Character", typeof(string));
            thisTable.Columns.Add("Relationship", typeof(string));
            refreshRelationships();
        }

        private void refreshRelationships() {
            thisTable.Rows.Clear();
            foreach (Lib.Character theChar in mainLists.characterList)
            {
                if (myChar.whatsTheRelationshipTo(theChar) != Lib.Object.relationshipTypes.Null) {
                    DataRow newRow = thisTable.NewRow();
                    newRow["Character"] = theChar.Name;
                    newRow["Relationship"] = myChar.whatsTheRelationshipTo(theChar).ToString();
                    thisTable.Rows.Add(newRow);
                }
            }
            relationshipDTA.ItemsSource = thisTable.DefaultView;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e) //Adding relationships
        {
            if (mainLists.characterList.Count > 1)
            {
                GUI.addRelationship thisRel = new addRelationship(myChar);
                thisRel.ShowDialog();
                refreshRelationships();
            }else MessageBox.Show("NO OTHER CHARACTERS", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void relationshipFRM_Closed(object sender, EventArgs e)
        {
            if (myChar.window != null) {
                (myChar.window as GUI.DetailWindows.CharacterWindow).openWindow = false;
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e) //Delete button
        {
            if (relationshipDTA.SelectedItem != null) {
                foreach (Lib.Character thisChar in mainLists.characterList) //Get datarows and compare foreach datarow in table
                {
                    if (thisChar.Name == relationshipDTA.SelectedValue.ToString()) myChar.removeRelationship(thisChar);
                }
            }
        }
    }
}
