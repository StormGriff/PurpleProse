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

namespace PurpleProse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
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

        #region Title Bar and Border

        private void TitleBarText_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MaxButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = (this.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        #endregion

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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            PPGit.GUI.Calendar newCal = new PPGit.GUI.Calendar();
            newCal.Show();
        }
    }
}
