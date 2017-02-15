using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data;
using System.Diagnostics;

namespace PurpleProse
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
		//static string texteditor; Currently using seperate class
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
			
			/*texteditor*/ TextOps.editor = "D:\\Documents\\Visual Studio 2015\\Projects\\HelloWPF\\HelloWPF\\bin\\Debug\\HelloWPF.exe";//"D:\\Documents\\Visual Studio 2015\\Projects\\PurpleProse\\PPGit\\Resources\\HelloWPF - Shortcut.exe";
			// Intialization of default texteditor must be moved, and edited.
        }

		private void MenuItem_Click(object sender, RoutedEventArgs e) {
			(sender as MenuItem).ContextMenu.IsEnabled = true;
			(sender as MenuItem).ContextMenu.PlacementTarget = (sender as MenuItem);
			(sender as MenuItem).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
			(sender as MenuItem).ContextMenu.IsOpen = true;
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

		private void Add_Character_LeftMouseUp(object sender, MouseButtonEventArgs e) {
			PurpleProse.Lib.Character New_Char = new PurpleProse.Lib.Character(null, null, null, null, 20, null, null, null, null, null, null);
			characters.Add(New_Char);
			CharacterWindow CharWindow = new CharacterWindow(New_Char);
			CharWindow.Show();
			//MessageBox.Show(CharWindow.Getmessage());
			//CharWindow.ShowDialog();
		}
	}
}
