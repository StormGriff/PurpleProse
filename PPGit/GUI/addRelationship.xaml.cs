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

namespace PPGit.GUI
{
    /// <summary>
    /// Interaction logic for addRelationship.xaml
    /// </summary>
    public partial class addRelationship : Window
    {
        Lib.Character theChar;
        public addRelationship(Lib.Character thisChar)
        {
            theChar = thisChar;
            InitializeComponent();
        }

        private void cnclBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void relAddFRM_Initialized(object sender, EventArgs e)
        {
            typeBX.Items.Add(Lib.Object.relationshipTypes.Father);  //Fill relationship types
            typeBX.Items.Add(Lib.Object.relationshipTypes.Mother);
            typeBX.Items.Add(Lib.Object.relationshipTypes.Sibling);
            typeBX.Items.Add(Lib.Object.relationshipTypes.Spouse);
            typeBX.Items.Add(Lib.Object.relationshipTypes.Friend);
            typeBX.Items.Add(Lib.Object.relationshipTypes.Enemy);

            if (mainLists.characterList.Count > 1)
            {
                foreach (Lib.Character myChar in mainLists.characterList) {
                    if (myChar != theChar && theChar.whatsTheRelationshipTo(myChar) == Lib.Object.relationshipTypes.Null) {
                        charBX.Items.Add(myChar);
                    }
                }
            }
            else {
                MessageBox.Show("NO OTHER CHARACTERS", "WARNING", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.Close();
            }
        }

        private void addBTN_Click(object sender, RoutedEventArgs e)
        {
            if (charBX.SelectedItem != null && typeBX.SelectedItem != null)
            {
                theChar.establishRelationship((charBX.SelectedItem as Lib.Character), (Lib.Object.relationshipTypes)typeBX.SelectedItem);
                MessageBox.Show("Relationship established", "SUCCESS", MessageBoxButton.OK, MessageBoxImage.None);
                this.Close();
            }
            else {
                MessageBox.Show("Invalid Selection", "ERROR", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
