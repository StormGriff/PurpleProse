using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace PurpleProse
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 
	public static class ExtensionMethods 
		{
			private static Action EmptyDelegate = delegate() { };
			
			public static void Refresh(this UIElement uiElement)
			{ uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate); }
		}

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


		private void LoopingMethod()
		{
  			for (int i = 0; i < 10; i++)
  			{	//Elements.Items = i.ToString();
     			Elements.Refresh();
     			Thread.Sleep(100);
  			}
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

		private void Elements_Loaded(object sender, RoutedEventArgs e)
		{
			// ... Create a TreeViewItem.
			TreeViewItem _Characters = new TreeViewItem();
			_Characters.Header = "Characters";

			// ... Create a second TreeViewItem.
			TreeViewItem _Locations = new TreeViewItem();
			_Locations.Header = "Locations";
			
			Elements.Items.Add(_Characters);
			Elements.Items.Add(_Locations);
			
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
			else if (tree.SelectedItem is string)
			{
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
		{	PurpleProse.Lib.Character New_Char = new PurpleProse.Lib.Character(null, null, null, null, 20, null, null, null, null, null, null);
			characters.Add(New_Char);
			CharacterWindow CharWindow = new CharacterWindow(New_Char);
			CharWindow.Show();
			Elements.Items.Refresh();
			this.Refresh();
			LoopingMethod();
		}

		private void Elements_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
		{	Elements.Items.Refresh();
			Elements.UpdateLayout();
		}
	}
}
