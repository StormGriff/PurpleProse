using System;
using System.Collections.Generic;
using System.IO;
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

namespace PPGit.GUI.TextEditor
{
    /// <summary>
    /// Interaction logic for changeStoryTitle.xaml
    /// </summary>
    public partial class changeStoryTitle : Window
    {
        string path;
        public changeStoryTitle(string namePath)
        {
            path = namePath;
            InitializeComponent();
        }

        private void saveBTN_Click(object sender, RoutedEventArgs e)
        {
            string newString = "";
            foreach (char upper in nameTXT.Text) {
                newString += char.ToUpper(upper);
            }
            File.WriteAllText(path, newString);
            this.DialogResult = true;
        }

        private void cancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
