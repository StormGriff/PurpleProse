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
using System.IO;

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

            //PPGit.Lib.TextOps.editor = "D:\\Documents\\Visual Studio 2015\\Projects\\HelloWPF\\HelloWPF\\bin\\Debug\\HelloWPF.exe";//"D:\\Documents\\Visual Studio 2015\\Projects\\PurpleProse\\PPGit\\Resources\\HelloWPF - Shortcut.exe";
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
            
            if(selection is Lib.Character)								//If the slected item is a character
            {	var Acharacter = selection as Lib.Character;			//call it Acharacter
				if ( Acharacter.window == null)							//if it does not have a window
				{	Acharacter.window = new CharacterWindow(Acharacter);//	create a new window for it
					Acharacter.window.Show();							//	and make it visable
				}else Acharacter.window.Activate();						//otherwise make its window active
            }
			else if (selection is Lib.Location )					//If the slected item is a location
			{	var Alocation = selection as Lib.Location;			//call it Alocation
				if (Alocation.window == null)						//if it does not have a window
				{	Alocation.window =new LocationWindow(Alocation);//	create a new window for it
					Alocation.window.Show();						//	and make it visable
				}else Alocation.window.Activate();					//otherwise make its window active
			}
			else if (selection is Lib.Object   )				//If the slected item is a misc. item
			{	var Athing = selection as Lib.Object;			//call it Athing
				if (Athing.window == null) ;					//if it does not have a window
				/*{	Athing.window = new ObjectWindow(Athing);	//	create a new window for it
				 *	Athing.window.Show(); }*/					//	and make it visable
				else Athing.window.Activate();					//otherwise make its window active
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
			// ^Create a character^

            characters.Add(New_Char);						//Add it to the list of characters
            New_Char.window = new CharacterWindow(New_Char);//give it a window (stored inside for later reference)
            New_Char.window.Show();							//Show it.
        }

        private void Add_Location_LeftMouseUp(object sender, MouseButtonEventArgs e)
        {	Lib.Location New_Loc = new Lib.Location("The_State", null, null, null);
			// ^Create a location^

            locations.Add(New_Loc);						//Add it to the list of locations
            New_Loc.window = new LocationWindow(New_Loc);//give it a window (stored inside for later reference)
            New_Loc.window.Show();						//Show it.
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

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            // Get all info and write to file in the created file structure
            // Compress the file into a zip file
            // Change zip file to be a custom zip file

            // For load: unzip custom zip file

            StringBuilder sb = new StringBuilder();

            // Characters
            /*foreach (TreeViewItem node in Elements.)
            {
                sb.AppendLine(node.Name);
            }

            SaveFileDialog saveList = new SaveFileDialog();

            saveList.DefaultExt = "*.mvia";
            saveList.Filter = "MVIA Files|*.mvia";

            if (saveList.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveList.FileName, sb.ToString());
            }*/
        }
    }
}
