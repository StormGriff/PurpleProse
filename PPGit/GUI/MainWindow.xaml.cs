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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

using MahApps.Metro.Controls;
using MahApps.Metro;

namespace PPGit.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        List<PurpleProse.Lib.Character> characters;
        List<PurpleProse.Lib.Location> locations;
        DataTable bindChar;

        public MainWindow()
        {
            characters = new List<PurpleProse.Lib.Character>();
            locations = new List<PurpleProse.Lib.Location>();
            bindChar = new DataTable();

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            characters.Add(new PurpleProse.Lib.Character("bob", null, null, null, 20, null, null, null, null, null, null));
            characters.Add(new PurpleProse.Lib.Character("Jimbo", null, null, null, 15, null, null, null, null, null, null));

            

            DataColumn dc = new DataColumn();
            dc.ColumnName = "Name";
            dc.DataType = System.Type.GetType("System.String");
            bindChar.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "Age";
            dc.DataType = System.Type.GetType("System.Int64");
            bindChar.Columns.Add(dc);

            //bindChar.Columns.Add(new DataColumn("Name"));
            //bindChar.Columns.Add(new DataColumn("Age"));

            UpdateBinding();

            DataGrid.DataContext = bindChar.DefaultView;
        }

        //need to add for location
        private void UpdateBinding()
        {
            bindChar.Clear();

            foreach(PurpleProse.Lib.Character c in characters)
            {
                DataRow dr = bindChar.NewRow();
                dr["Name"] = c.Name;
                dr["Age"] = c.charAge;
                bindChar.Rows.Add(dr);
            }
        }

        private void Text_Click(object sender, RoutedEventArgs e)
        {
            PPGit.GUI.TextEditor test = new PPGit.GUI.TextEditor();

            test.Show();
        }

        private void Cal_Click(object sender, RoutedEventArgs e)
        {
            PPGit.GUI.Deadlines.Calendar test = new Deadlines.Calendar();

            test.Show();
        }

        private void Theme_Click(object sender, RoutedEventArgs e)
        {
            PPGit.GUI.AppThemeChanger temp = new PPGit.GUI.AppThemeChanger();

            temp.Show();
        }

        private void Music_Click(object sender, RoutedEventArgs e)
        {
            //PPGit.GUI.MusicPlayer.MusicPlayer temp = new MusicPlayer.MusicPlayer();

            //temp.Show();
        }

        private void btnRightWindowChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            AppThemeChanger wnd = new AppThemeChanger();

            wnd.Show();
        }
    }
}
