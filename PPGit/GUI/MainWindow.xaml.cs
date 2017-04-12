using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

using PPGit.GUI.DetailWindows;

namespace PPGit.GUI
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        //static string texteditor; Currently using seperate class
        public ObservableCollection<Lib.Character> characters;
        public ObservableCollection<Lib.Location> locations;
        DataTable bindChar;
        //	TreeView Elements;

        public MainWindow()
        {
            characters = new ObservableCollection<Lib.Character>();
            locations = new ObservableCollection<Lib.Location>();
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
            //characters.Add(new PurpleProse.Lib.Character("bob", null, null, null, 20, null, null, null, null, null, null));
            //characters.Add(new PurpleProse.Lib.Character("Jimbo", null, null, null, 15, null, null, null, null, null, null));
            /*
			NewColumn("Name"); NewColumn("Age", "System.Int64"); NewColumn(new List<string> { "Gender", "Race", "Role", "hometown", "language" });
            //bindChar.Columns.Add(new DataColumn("Name"));
            //bindChar.Columns.Add(new DataColumn("Age"));

            UpdateBinding();

            DataGrid.DataContext = bindChar.DefaultView;
			*/

            PPGit.Lib.TextOps.editor = "D:\\Documents\\Visual Studio 2015\\Projects\\HelloWPF\\HelloWPF\\bin\\Debug\\HelloWPF.exe";//"D:\\Documents\\Visual Studio 2015\\Projects\\PurpleProse\\PPGit\\Resources\\HelloWPF - Shortcut.exe";
			//^ Intialization of default texteditor must be moved, and edited. ^
        }

        private void Window_Activated(object sender, System.EventArgs e)
        {
            if (this.IsLoaded && Elements.IsLoaded)
            {
                //UpdateBinding();
                var sub_folder = Elements.Items[0] as TreeViewItem;
                sub_folder.ItemsSource = null;
                sub_folder.ItemsSource = characters;

                sub_folder = Elements.Items[1] as TreeViewItem;
                sub_folder.ItemsSource = null;
                sub_folder.ItemsSource = locations;
            }
        }

        public void Elements_SourceUpdated(object sender, RoutedEventArgs e)
        {
        }

        private void Elements_Loaded(object sender, RoutedEventArgs e)
        {   /*
			// ... Create a TreeViewItem.
			TreeViewItem Characters_TVL = new TreeViewItem();
			Characters_TVL.Header = "Characters";
			
			// ... Create a second TreeViewItem.
			TreeViewItem _Locations = new TreeViewItem();
			_Locations.Header = "Locations";
			
			Elements.Items.Add(Characters_TVL);
			Elements.Items.Add(_Locations);
			*/
			
			var sub_folder = Elements.Items[0] as TreeViewItem;
			sub_folder.ItemsSource = null;
			sub_folder.ItemsSource = characters;
			
			sub_folder = Elements.Items[1] as TreeViewItem;
			sub_folder.ItemsSource = null;
			sub_folder.ItemsSource = locations;

        }

        private void Elements_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selection = (sender as TreeView).SelectedItem;
            
            /**/ if(selection is Lib.Character)
            {	var select = selection as Lib.Character;
				if ( null == select.Page)
				{	select.Page = new CharacterWindow(select);
					select.Page.Show();
				}else select.Page.Activate();
            }
			else if (selection is Lib.Location )
			{	var select = selection as Lib.Location;
				if (select.Page == null)
				{	select.Page = new LocationWindow(select);
					select.Page.Show();
				}else select.Page.Activate();
			}
			else if (selection is Lib.Object   )
			{	var select = selection as Lib.Object;
				if (select.Page == null) ;//{ select.Page = new ObjectWindow(select);select.Page.Show(); }
				else select.Page.Activate();
			}
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            (sender as MenuItem).ContextMenu.IsEnabled = true;
            (sender as MenuItem).ContextMenu.PlacementTarget = (sender as MenuItem);
            (sender as MenuItem).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as MenuItem).ContextMenu.IsOpen = true;
        }

        //need to add for location
        private void UpdateBinding()
        {
            bindChar.Clear();

            foreach (PPGit.Lib.Character c in characters)
            {
                DataRow dr = bindChar.NewRow();
                dr["Name"] = c.Name;
                dr["Age"] = c.charAge;
                dr["Race"] = c.charKind;
                dr["Gender"] = c.charGender;
                dr["Role"] = c.charRole;
                dr["Language"] = c.charLanguage;
                dr["Hometown"] = c.charHometown;
                bindChar.Rows.Add(dr);
            }
        }

        private void NewColumn(string label, string ctype = "System.String")
        {
            DataColumn dc = new DataColumn();
            dc.ColumnName = label;
            dc.DataType = System.Type.GetType(ctype);
            bindChar.Columns.Add(dc);
        }
        private void NewColumn(List<string> labels)
        {
            DataColumn dc;
            foreach (string label in labels)
            {
                dc = new DataColumn();
                dc.ColumnName = label;
                dc.DataType = System.Type.GetType("System.String");
                bindChar.Columns.Add(dc);
            }
        }

        private void Add_Character_LeftMouseUp(object sender, MouseButtonEventArgs e)
        {	Lib.Character New_Char = new Lib.Character("Michael", null, null, null, 0, null, null, null, null, null, null);
            characters.Add(New_Char);
            New_Char.Page = new CharacterWindow(New_Char);
            New_Char.Page.Show();
        }

        private void Add_Location_LeftMouseUp(object sender, MouseButtonEventArgs e)
        {	Lib.Location New_Loc = new Lib.Location("The_State", null, null, null);
            locations.Add(New_Loc);
            New_Loc.Page = new LocationWindow(New_Loc);
            New_Loc.Page.Show();
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
