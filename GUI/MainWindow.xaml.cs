﻿using System;
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

using System.IO;
using MahApps.Metro.Controls;

using PPGit.GUI.DetailWindows;

namespace PPGit.GUI
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        //static string texteditor; Currently using seperate class
        //	TreeView Elements;

        public MainWindow()
        {
            mainLists.characterList = new ObservableCollection<Lib.Character>();
            mainLists.locationList = new ObservableCollection<Lib.Location>();

            InitializeComponent();
        }

        private void NewCharacter()
        {
            Lib.Character New_Char = new Lib.Character("Michael", null, null, null, 0, null, null, null, null, null, null);
            // ^Create a character^

            Directory.CreateDirectory(mainLists.projectDir + "\\items\\characters\\" + New_Char.Name.ToLower() + mainLists.objNum);
            Directory.CreateDirectory(mainLists.projectDir + "\\items\\characters\\" + New_Char.Name.ToLower() + mainLists.objNum + "\\images");
            Directory.CreateDirectory(mainLists.projectDir + "\\items\\characters\\" + New_Char.Name.ToLower() + mainLists.objNum + "\\texts");

            New_Char.Number = mainLists.objNum;
            mainLists.objNum++;

            File.Create(mainLists.projectDir + "\\items\\characters\\" + New_Char.Name.ToLower() + New_Char.Number + "\\" + New_Char.Name.ToLower() + ".info");

            

            mainLists.characterList.Add(New_Char);						//Add it to the list of characters

            New_Char.window = new CharacterWindow(New_Char);//give it a window (stored inside for later reference)
            New_Char.window.Show();							//Show it.
        }

        private void NewLocation()
        {
            Lib.Location New_Loc = new Lib.Location("The_State", null, null, null);
            // ^Create a location^

            Directory.CreateDirectory(mainLists.projectDir + "\\items\\locations\\" + New_Loc.Name.ToLower() + mainLists.objNum);
            Directory.CreateDirectory(mainLists.projectDir + "\\items\\locations\\" + New_Loc.Name.ToLower() + mainLists.objNum + "\\images");
            Directory.CreateDirectory(mainLists.projectDir + "\\items\\locations\\" + New_Loc.Name.ToLower() + mainLists.objNum + "\\texts");

            New_Loc.Number = mainLists.objNum;
            mainLists.objNum++;

            File.Create(mainLists.projectDir + "\\items\\locations\\" + New_Loc.Name.ToLower() + New_Loc.Number + "\\" + New_Loc.Name.ToLower() + ".info");

            mainLists.locationList.Add(New_Loc);						//Add it to the list of locations
            New_Loc.window = new LocationWindow(New_Loc);//give it a window (stored inside for later reference)
            New_Loc.window.Show();						//Show it.
        }

        private void ResetDisplay()
        {
            lblDisplayHeader.Content = null;
            lblDisplayLine1.Content = null;
            lblDisplayLine2.Content = null;
            lblDisplayLine3.Content = null;
            blkDisplayLines.Text = null;
        }


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
                sub_folder.ItemsSource = mainLists.characterList;

                sub_folder = Elements.Items[1] as TreeViewItem;
                sub_folder.ItemsSource = null;
                sub_folder.ItemsSource = mainLists.locationList;
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
            sub_folder.ItemsSource = mainLists.characterList;

            sub_folder = Elements.Items[1] as TreeViewItem;
            sub_folder.ItemsSource = null;
            sub_folder.ItemsSource = mainLists.locationList;

        }

        private void Elements_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var selection = (sender as TreeView).SelectedItem;

            if (selection is Lib.Character)								//If the slected item is a character
            {
                var Acharacter = selection as Lib.Character;            //call it Acharacter
                string role;

                if(Acharacter.charRole != null)
                {
                    role = " ( " + Acharacter.charRole + " ) ";
                }
                else
                {
                    role = null;
                }

                lblDisplayHeader.Content = Acharacter.Name + role;
                lblDisplayLine1.Content = Acharacter.charAge;
                lblDisplayLine2.Content = Acharacter.charKind;
                lblDisplayLine3.Content = Acharacter.charGender;
                blkDisplayLines.Text = Acharacter.DescText;
            }
            else if (selection is Lib.Location)                 //If the slected item is a location
            {
                var Alocation = selection as Lib.Location;          //call it Alocation

                lblDisplayHeader.Content = Alocation.Name;
                lblDisplayLine1.Content = Alocation.size;
                blkDisplayLines.Text = Alocation.DescText;
            }
            else if (selection is Lib.Object)               //If the slected item is a misc. item
            {
                var Athing = selection as Lib.Object;           //call it Athing
                if (Athing.window == null) ;                    //if it does not have a window
                                                                /*{	Athing.window = new ObjectWindow(Athing);	//	create a new window for it
                                                                 *	Athing.window.Show(); }*/                    //	and make it visable
                else Athing.window.Activate();                  //otherwise make its window active
            }
        }

        private void Elements_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selection = (sender as TreeView).SelectedItem;

            if (selection is Lib.Character)								//If the slected item is a character
            {
                var Acharacter = selection as Lib.Character;            //call it Acharacter
                if (Acharacter.window == null)                          //if it does not have a window
                {
                    Acharacter.window = new CharacterWindow(Acharacter);//	create a new window for it
                    Acharacter.window.Show();                           //	and make it visable
                }
                else Acharacter.window.Activate();						//otherwise make its window active
            }
            else if (selection is Lib.Location)                 //If the slected item is a location
            {
                var Alocation = selection as Lib.Location;          //call it Alocation
                if (Alocation.window == null)                       //if it does not have a window
                {
                    Alocation.window = new LocationWindow(Alocation);//	create a new window for it
                    Alocation.window.Show();                        //	and make it visable
                }
                else Alocation.window.Activate();                   //otherwise make its window active
            }
            else if (selection is Lib.Object)               //If the slected item is a misc. item
            {
                var Athing = selection as Lib.Object;           //call it Athing
                if (Athing.window == null) ;                    //if it does not have a window
                                                                /*{	Athing.window = new ObjectWindow(Athing);	//	create a new window for it
                                                                 *	Athing.window.Show(); }*/                    //	and make it visable
                else Athing.window.Activate();                  //otherwise make its window active
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            (sender as MenuItem).ContextMenu.IsEnabled = true;
            (sender as MenuItem).ContextMenu.PlacementTarget = (sender as MenuItem);
            (sender as MenuItem).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as MenuItem).ContextMenu.IsOpen = true;
        }

        private void btnRightWindowChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            AppThemeChanger wnd = new AppThemeChanger();

            wnd.Show();
        }

        private void NewCharacterContextMenu_Click(object sender, RoutedEventArgs e)
        {
            NewCharacter();
        }

        private void NewLocationContextMenu_Click(object sender, RoutedEventArgs e)
        {
            NewLocation();
        }

        private void ViewEditContextMenu_Click(object sender, RoutedEventArgs e)
        {
            var selection = Elements.SelectedItem;

            if (selection is Lib.Character)								//If the slected item is a character
            {
                var Acharacter = selection as Lib.Character;            //call it Acharacter
                if (Acharacter.window == null)                          //if it does not have a window
                {
                    Acharacter.window = new CharacterWindow(Acharacter);//	create a new window for it
                    Acharacter.window.Show();                           //	and make it visable
                }
                else Acharacter.window.Activate();						//otherwise make its window active
            }
            else if (selection is Lib.Location)                 //If the slected item is a location
            {
                var Alocation = selection as Lib.Location;          //call it Alocation
                if (Alocation.window == null)                       //if it does not have a window
                {
                    Alocation.window = new LocationWindow(Alocation);//	create a new window for it
                    Alocation.window.Show();                        //	and make it visable
                }
                else Alocation.window.Activate();                   //otherwise make its window active
            }
            else if (selection is Lib.Object)               //If the slected item is a misc. item
            {
                var Athing = selection as Lib.Object;           //call it Athing
                if (Athing.window == null) ;                    //if it does not have a window
                                                                /*{	Athing.window = new ObjectWindow(Athing);	//	create a new window for it
                                                                 *	Athing.window.Show(); }*/                    //	and make it visable
                else Athing.window.Activate();                  //otherwise make its window active
            }
        }

        private void DeleteContextMenu_Click(object sender, RoutedEventArgs e)
        {
            var selection = Elements.SelectedItem;

            if (selection is Lib.Character)								//If the slected item is a character
            {
                var Acharacter = selection as Lib.Character;            //call it Acharacter

                mainLists.characterList.Remove(Acharacter);

                Directory.Delete(mainLists.projectDir + "\\items\\characters\\" + Acharacter.Name.ToLower() + Acharacter.Number, true);

                ResetDisplay();
            }
            else if (selection is Lib.Location)                 //If the slected item is a location
            {
                var Alocation = selection as Lib.Location;          //call it Alocation

                mainLists.locationList.Remove(Alocation);

                Directory.Delete(mainLists.projectDir + "\\items\\locations\\" + Alocation.Name.ToLower() + Alocation.Number, true);

                ResetDisplay();
            }
            else if (selection is Lib.Object)               //If the slected item is a misc. item
            {
                var Athing = selection as Lib.Object;           //call it Athing

            }
        }

        private void btnViewEdit_Click(object sender, RoutedEventArgs e)
        {
            var selection = Elements.SelectedItem;

            if (selection is Lib.Character)								//If the slected item is a character
            {
                var Acharacter = selection as Lib.Character;            //call it Acharacter
                if (Acharacter.window == null)                          //if it does not have a window
                {
                    Acharacter.window = new CharacterWindow(Acharacter);//	create a new window for it
                    Acharacter.window.Show();                           //	and make it visable
                }
                else Acharacter.window.Activate();						//otherwise make its window active
            }
            else if (selection is Lib.Location)                 //If the slected item is a location
            {
                var Alocation = selection as Lib.Location;          //call it Alocation
                if (Alocation.window == null)                       //if it does not have a window
                {
                    Alocation.window = new LocationWindow(Alocation);//	create a new window for it
                    Alocation.window.Show();                        //	and make it visable
                }
                else Alocation.window.Activate();                   //otherwise make its window active
            }
            else if (selection is Lib.Object)               //If the slected item is a misc. item
            {
                var Athing = selection as Lib.Object;           //call it Athing
                if (Athing.window == null) ;                    //if it does not have a window
                                                                /*{	Athing.window = new ObjectWindow(Athing);	//	create a new window for it
                                                                 *	Athing.window.Show(); }*/                    //	and make it visable
                else Athing.window.Activate();                  //otherwise make its window active
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var selection = Elements.SelectedItem;

            if (selection is Lib.Character)								//If the slected item is a character
            {
                var Acharacter = selection as Lib.Character;            //call it Acharacter

                mainLists.characterList.Remove(Acharacter);

                Lib.Recycle.Bin.add(Acharacter); //Add to recycle bin

                ResetDisplay();
            }
            else if (selection is Lib.Location)                 //If the slected item is a location
            {
                var Alocation = selection as Lib.Location;          //call it Alocation

                mainLists.locationList.Remove(Alocation);

                Lib.Recycle.Bin.add(Alocation); //Add to recycle bin

                ResetDisplay();
            }
            else if (selection is Lib.Object)               //If the slected item is a misc. item
            {
                var Athing = selection as Lib.Object;           //call it Athing

            }
        }

        private void mnuCalendar_Click(object sender, RoutedEventArgs e)
        {
            PPGit.GUI.Deadlines.Calendar win;
            if (mainLists.wordCount > 0) win = new Deadlines.Calendar(mainLists.wordCount);
            else win = new Deadlines.Calendar();
            win.Show();
        }

        private void mnuRestoreItems_Click(object sender, RoutedEventArgs e)
        {
            PPGit.GUI.RecycleBin.RecycleBin win = new RecycleBin.RecycleBin();
            win.Show();
        }

        private void mnuMusic_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void mnuNewProject_Click(object sender, RoutedEventArgs e)
        {

        }

        private void mnuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void storyBTN_Click(object sender, RoutedEventArgs e)
        {
            if (mainLists.fullEditor != null)
            {
                mainLists.fullEditor.Activate();
            }
            else {
                if (mainLists.storyLocation == null) mainLists.fullEditor = new TextEditor.TextEditor(true);
                else mainLists.fullEditor = new TextEditor.TextEditor(mainLists.storyLocation, true); //True for full story
                mainLists.fullEditor.Show();
            }
        }
    }
}
