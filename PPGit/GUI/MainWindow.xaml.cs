using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
//using PurpleProse.Lib;
using System.Collections.ObjectModel;

namespace PurpleProse
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 

	public partial class MainWindow : Window
    {
		//static string texteditor; Currently using seperate class
        ObservableCollection<Lib.Character> characters;
        ObservableCollection<Lib.Location> locations;
        DataTable bindChar;
	//	TreeView Elements;

        public MainWindow()
        {
            characters = new ObservableCollection<Lib.Character>();
            locations = new ObservableCollection<Lib.Location>();
            bindChar = new DataTable();
            InitializeComponent();
			Create_Elements();
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

			TextOps.editor = "D:\\Documents\\Visual Studio 2015\\Projects\\HelloWPF\\HelloWPF\\bin\\Debug\\HelloWPF.exe";//"D:\\Documents\\Visual Studio 2015\\Projects\\PurpleProse\\PPGit\\Resources\\HelloWPF - Shortcut.exe";
			// Intialization of default texteditor must be moved, and edited.
        }

		private void Window_Activated(object sender, System.EventArgs e)
		{if(this.IsLoaded && Elements.IsLoaded){
				//UpdateBinding();
				//Elements.;
				//Elements.UpdateLayout();
				//Elements.Items.Refresh();
				//Dispatcher.Invoke();
		}}

		private void Create_Elements()
		{	if(Elements != null) Elements.Items.Clear();
			Elements = new TreeView();
			TreeList.Children.Add(Elements);
			Elements.Loaded += Elements_Loaded;
			Elements.SelectedItemChanged += Elements_SelectedItemChanged;
			Elements.Height=483; Width=135;
			VerticalAlignment = VerticalAlignment.Top;
			Elements.Visibility = Visibility.Visible;

		//	BindingExpression binding = MainWindow.GetBindingExpression(TextBox.TextProperty);
		//	binding.UpdateSource();
		}

		public void Elements_SourceUpdated(object sender, RoutedEventArgs e)
		{
		}

		private void Elements_Loaded(object sender, RoutedEventArgs e)
		{	/*
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
			sub_folder.ItemsSource = characters;
			//TreeViewItem.SetBinding(sub_folder, characters);

			/**/sub_folder = Elements.Items[1] as TreeViewItem;
			sub_folder.ItemsSource = locations;
			//Elements.Items[0].Add(new Lib.Character("Jimbo", null, null, null, 15, null, null, null, null, null, null));
		
		}

		private void Elements_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			var tree = sender as TreeView;

			// ... Determine type of SelectedItem.
			if (tree.SelectedItem is TreeViewItem)
			{	var item = tree.SelectedItem as TreeViewItem;
				
			}
			else if (tree.SelectedItem is Lib.Object)
			{	//tree.its_window.Show();
			}
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
            {	DataRow dr = bindChar.NewRow();
                dr["Name"	 ] = c.Name;
                dr["Age"	 ] = c.charAge;
				dr["Race"	 ] = c.charKind;
				dr["Gender"	 ] = c.charGender;
				dr["Role"	 ] = c.charRole;
				dr["Language"] = c.charLanguage;
				dr["Hometown"] = c.charHometown;
                bindChar.Rows.Add(dr);
            }
        }

		private void NewColumn(string label, string ctype = "System.String")
		{	DataColumn dc = new DataColumn();
			dc.ColumnName = label;
			dc.DataType = System.Type.GetType(ctype);
			bindChar.Columns.Add(dc);
		}
		private void NewColumn(List<string> labels)
		{	DataColumn dc;
			foreach(string label in labels)
			{	dc = new DataColumn();
				dc.ColumnName = label;
				dc.DataType = System.Type.GetType("System.String");
				bindChar.Columns.Add(dc);
			}
		}

		private void Add_Character_LeftMouseUp(object sender, MouseButtonEventArgs e)
		{	Lib.Character New_Char = new PurpleProse.Lib.Character("Michael", null, null, null, 0, null, null, null, null, null, null);
			New_Char.its_window =  new CharacterWindow(New_Char);
			characters.Add(New_Char);
		//	CharacterWindow CharWindow = new CharacterWindow(New_Char);
			New_Char.its_window.Show();
		//	Elements.Visibility=Visibility.Hidden;
		//	Create_Elements();
		}
		
		private void Add_Location_LeftMouseUp(object sender, MouseButtonEventArgs e)
		{	PurpleProse.Lib.Location New_Loc = new PurpleProse.Lib.Location(null, null, null, null);
			New_Loc.its_window =  new LocationWindow(New_Loc);
			locations.Add(New_Loc);
		//	LocationWindow LocWindow = new LocationWindow(New_Loc);
			New_Loc.its_window.Show();
		//	Elements.Visibility=Visibility.Hidden;
		//	Create_Elements();
		}
	}
}
