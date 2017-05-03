using PPGit.GUI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PPGit
{
    /// <summary>
    /// Interaction logic for Launcher.xaml
    /// </summary>
    public partial class Launcher : Window
    {
        public Launcher()
        {
            InitializeComponent();

            ImageBrush myBrush = new ImageBrush();
            Uri imgUri = new Uri(@"pack://application:,,,/PPGit;component/Resources/scroll1.png"); //(BaseUriHelper.GetBaseUri(this), "/Images/cursive.png");
            myBrush.ImageSource = new BitmapImage(imgUri);
            this.Background = myBrush;

        }

        private void create_btn_Click(object sender, RoutedEventArgs e)
        {
            // Create Folder Structure (proj name + path prompt tbd)
            // FOLDER STRUCTURE 
            // (1) Create folder "MyProject"
            // (2) Create subfolder MyProject->"Items"
            // (3) subfolders MyProject->Items->Locations, 
            //                  MyProject->Items->Characters

            String firstFolder = @"C:\MyProject";

            if (!Directory.Exists(firstFolder))
            {
                Directory.CreateDirectory(firstFolder);
            }

            // TODO: Create custom file inside firstFolder: MyProject.info
            // Fow now: MyProject.info.txt
            if (!File.Exists(firstFolder + @"\MyProject.info.txt"))
            {
                //File.Create(firstFolder + @"\MyProject.info.txt");
                TextWriter tw = new StreamWriter(firstFolder + @"\MyProject.info.txt");
                tw.WriteLine("FirstLineTest");
                tw.Close();
            }
            else if (File.Exists(firstFolder + @"\MyProject.info.txt"))
            {
                using (var tw = new StreamWriter(firstFolder + @"\MyProject.info.txt", true))
                {
                    tw.WriteLine("FirstLineTest");
                    tw.Close();
                }
            }


            string itemsSubFolder = System.IO.Path.Combine(firstFolder, "items");
            if (!Directory.Exists(itemsSubFolder))
            {
                Directory.CreateDirectory(itemsSubFolder);

                // Inside itemsSubFolder, create subfolder "characters"
                string charactersSubFolder = System.IO.Path.Combine(itemsSubFolder, "characters");
                if (!Directory.Exists(charactersSubFolder))
                {
                    Directory.CreateDirectory(charactersSubFolder);

                    // TODO: Create custom file inside charactersSubFolder: characters.list
                    // Fow now: characters.list.txt
                    if (!File.Exists(charactersSubFolder + @"\characters.list.txt"))
                    {
                        //File.Create(charactersSubFolder + @"\characters.list.txt");
                        TextWriter tw = new StreamWriter(charactersSubFolder + @"\characters.list.txt");
                        tw.WriteLine("FirstLineTest");
                        tw.Close();

                        // NOTE: When a new character is created in the app, 
                        //  For every new unique character
                        //      -log unique id + char name + other info to characters.list
                        //      -create a subfolder inside charactersSubFolder "Char_Name" 
                        //      and two subfolders inside Char_Name subfolders: "images", "texts"
                        //      and  text (custom) file "Char_Name.info(.txt)" 
                        //  If character with same info already exists 
                        //      -do not replace / do not do anything
                    }
                }

                // Inside itemsSubFolder, create another subfolder "locations"
                string locationsSubFolder = System.IO.Path.Combine(itemsSubFolder, "locations");
                if (!Directory.Exists(locationsSubFolder))
                {
                    Directory.CreateDirectory(locationsSubFolder);

                    // TODO: Create custom file inside locationsSubFolder: locations.list
                    // Fow now: locations.list.txt
                    if (!File.Exists(locationsSubFolder + @"\locations.list.txt"))
                    {
                        //File.Create(locationsSubFolder + @"\locations.list.txt");
                        TextWriter tw = new StreamWriter(locationsSubFolder + @"\locations.list.txt");
                        tw.WriteLine("FirstLineTest");
                        tw.Close();

                        // NOTE: When a new location is created in the app, 
                        //  For every new unique location
                        //      -log unique id + loc name + other info to locations.list
                        //      -create a subfolder inside locationssSubFolder "Loc_Name" 
                        //      and two subfolders inside Loc_Name subfolders: "images", "texts"
                        //      and  text (custom) file "Loc_Name.info(.txt)" 
                        //  If location with same info already exists 
                        //      -do not replace / do not do anything

                    }
                }



                // Inside itemsSubFolder, create another subfolder "events"
                string eventsSubFolder = System.IO.Path.Combine(itemsSubFolder, "events");
                if (!Directory.Exists(eventsSubFolder))
                {
                    Directory.CreateDirectory(eventsSubFolder);

                    // TODO: Create custom file inside eventsSubFolder: events.list
                    // Fow now: events.list.txt
                    if (!File.Exists(eventsSubFolder + @"\events.list.txt"))
                    {
                        //File.Create(eventsSubFolder + @"\events.list.txt");
                        TextWriter tw = new StreamWriter(eventsSubFolder + @"\events.list.txt");
                        tw.WriteLine("FirstLineTest");
                        tw.Close();

                        // NOTE: When a new event is created in the app, 
                        //  For every new unique event
                        //      -log unique id + event name + other info to events.list
                        //      -create a subfolder inside eventsSubFolder "Event_Name" 
                        //      and two subfolders inside Event_Name subfolders: "images", "texts"
                        //      and  text (custom) file "Event_Name.info(.txt)" 
                        //  If Events with same info already exists 
                        //      -do not replace / do not do anything

                    }
                }

            }

            string storySubFolder = System.IO.Path.Combine(firstFolder, "story");
            if (!Directory.Exists(storySubFolder))
            {
                Directory.CreateDirectory(storySubFolder);


                // TODO: Create custom file inside storySubFolder: stories.list
                // Fow now: stories.list.txt
                if (!File.Exists(storySubFolder + @"\stories.list.txt"))
                {
                    //File.Create(storySubFolder + @"\stories.list.txt");
                    TextWriter tw = new StreamWriter(storySubFolder + @"\stories.list.txt");
                    tw.WriteLine("FirstLineTest");
                    tw.Close();

                    // NOTE: When a new story chapter is created in the app, 
                    //  For every new unique character
                    //      -log unique id + story name + other info to stories.list
                    
                    //  If story with same info already exists 
                    //      -do not replace / do not do anything
                }


                // NOTE:
                // -When a new chapter is created, 
                //  automatically set the path to save/open to {storySubFolder path + <chapterfilename>.txt}
                // -
            }




            MainWindow mainWin = new MainWindow();
            this.Close();

            // Folder structure creation code here


            // Launch GUI/MainWindow.xaml
            mainWin.Show();


        }
    }
}
