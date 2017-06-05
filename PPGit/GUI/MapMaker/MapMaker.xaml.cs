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
using System.Windows.Shapes;
using Microsoft.Win32;

using MahApps.Metro.Controls;

namespace PPGit.GUI
{
    /// <summary>
    /// Interaction logic for MapMaker.xaml
    /// </summary>
    public partial class MapMaker : MetroWindow
    {
        private enum background { snow, desert, grass, water }

        public MapMaker()
        {
            InitializeComponent();
        }

        BitmapImage map = null;
        Image img = null;
        Uri picLoc;
        bool cntrl = false;
        bool z = false;
        bool shift = false;
        tutorial theTutorial;

        private void snowBTN_Click(object sender, RoutedEventArgs e)
        {
            changeBackground(background.snow);
        }

        private void backgroundLST_Click(object sender, RoutedEventArgs e)
        {
            (sender as MenuItem).ContextMenu.IsEnabled = true;
            (sender as MenuItem).ContextMenu.PlacementTarget = (sender as MenuItem);
            (sender as MenuItem).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as MenuItem).ContextMenu.IsOpen = true;
        }

        private void changeBackground(background whichOne) {
            ImageBrush newBrush = new ImageBrush();
            //Choose picture
            if(whichOne == background.snow) newBrush.ImageSource = new BitmapImage(new Uri(@"..\..\snow background.jpg", UriKind.Relative));
            if (whichOne == background.desert) newBrush.ImageSource = new BitmapImage(new Uri(@"..\..\desert background.jpg", UriKind.Relative));
            if (whichOne == background.grass) newBrush.ImageSource = new BitmapImage(new Uri(@"..\..\grass background.jpg", UriKind.Relative));
            if (whichOne == background.water) newBrush.ImageSource = new BitmapImage(new Uri(@"..\..\water background.jpg", UriKind.Relative));
            //Add background
            mapCVS.Background = newBrush;
            iconsLST.IsEnabled = true;
        }

        private void desertBTN_Click(object sender, RoutedEventArgs e)
        {
            changeBackground(background.desert);
        }

        private void grassBTN_Click(object sender, RoutedEventArgs e)
        {
            changeBackground(background.grass);
        }

        private void waterBTN_Click(object sender, RoutedEventArgs e)
        {
            changeBackground(background.water);
        }

        private void mountainBTN_Click(object sender, RoutedEventArgs e)
        {
            switchIcons();
            picLoc = new Uri(@"..\..\Map POIs\Mountains.png", UriKind.Relative); //Location of the image
            map = new BitmapImage(picLoc);
            img = new Image();
            img.Source = map;

            mapCVS.Children.Add(img); //Add image to canvas
        }

        private void switchIcons() {
            if(img != null) mapCVS.Children.Remove(img);
        }

        private void mapCVS_MouseMove(object sender, MouseEventArgs e)
        {
            if (img != null)
            {
                Point mousePosition = e.GetPosition(mapCVS);  //Follow the mouse
                Canvas.SetLeft(img, mousePosition.X - img.ActualWidth / 2);
                Canvas.SetTop(img, mousePosition.Y - img.ActualHeight / 2);
            }
        }

        private void lakeBTN_Click(object sender, RoutedEventArgs e)
        {
            switchIcons();
            picLoc = new Uri(@"..\..\Map POIs\Lake icon.png", UriKind.Relative); //Location of the image
            map = new BitmapImage(picLoc);
            img = new Image();
            img.Source = map;

            mapCVS.Children.Add(img); //Add image to canvas
        }

        private void mapMakerFRM_Initialized(object sender, EventArgs e)
        {
            iconsLST.IsEnabled = false;
            theTutorial = new tutorial();
        }

        private void cityBTN_Click(object sender, RoutedEventArgs e)
        {
            switchIcons();
            picLoc = new Uri(@"..\..\Map POIs\city icon.png", UriKind.Relative); //Location of the image
            map = new BitmapImage(picLoc);
            img = new Image();
            img.Source = map;

            mapCVS.Children.Add(img); //Add image to canvas
        }

        private void mapMakerFRM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl) cntrl = true;
            if (e.Key == Key.Z) z = true;
            if (e.Key == Key.LeftShift) shift = true;
            if (cntrl && z) {
                Image pullImage = Lib.mapStack.map.pushPop;
                if (pullImage != null) {
                    mapCVS.Children.Remove(pullImage);
                }
            }
        }

        private void mapMakerFRM_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl) cntrl = false;
            if (e.Key == Key.Z) z = false;
            if (e.Key == Key.LeftShift) shift = false;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            switchIcons();
            picLoc = new Uri(@"..\..\Map POIs\water segment.jpg", UriKind.Relative); //Location of the image
            map = new BitmapImage(picLoc);
            img = new Image();
            img.Source = map;

            mapCVS.Children.Add(img); //Add image to canvas
        }

        private void fileBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                (sender as MenuItem).ContextMenu.IsEnabled = true;
                (sender as MenuItem).ContextMenu.PlacementTarget = (sender as MenuItem);
                (sender as MenuItem).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                (sender as MenuItem).ContextMenu.IsOpen = true;
            }
            catch (NullReferenceException) { }
        }

        private void saveBTN_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog newSave = new SaveFileDialog();
            newSave.Filter = "Jpeg Files | *.jpeg";
            bool newResult = (bool)newSave.ShowDialog();
            if (newResult == true)
            {
                RenderTargetBitmap rtb = new RenderTargetBitmap((int)mapCVS.Width, (int)mapCVS.Height, 96d, 96d, PixelFormats.Default);
                rtb.Render(mapCVS);
                JpegBitmapEncoder newEncoder = new JpegBitmapEncoder();
                newEncoder.Frames.Add(BitmapFrame.Create(rtb));
                newEncoder.Save(System.IO.File.OpenWrite(newSave.FileName));
            }
        }

        private void mapCVS_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (img != null)
            {
                Lib.mapStack.map.pushPop = img; //push to stack
                if (!shift)
                {
                    img = null;
                    map = null;
                    picLoc = null;
                }
                else
                {
                    map = new BitmapImage(picLoc);
                    img = new Image();
                    img.Source = map;
                    mapCVS.Children.Add(img);
                }
            }
        }

        private void mapCVS_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (img != null) {
                mapCVS.Children.Remove(img);
                img = null;
                map = null;
                picLoc = null;
            }
        }

        private void openBTN_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openNew = new OpenFileDialog();
            openNew.Filter = "Jpeg Files | *.jpeg";
            bool result = (bool)openNew.ShowDialog();
            if (result == true) {
                mapCVS.Children.Clear();
                ImageBrush newImage = new ImageBrush();
                newImage.ImageSource = new BitmapImage(new Uri(openNew.FileName, UriKind.RelativeOrAbsolute));
                mapCVS.Background = newImage;
                iconsLST.IsEnabled = true;
            }
        }

        private void forestBTN_Click(object sender, RoutedEventArgs e)
        {
            switchIcons();
            picLoc = new Uri(@"..\..\Map POIs\forest icon.png", UriKind.Relative); //Location of the image
            map = new BitmapImage(picLoc);
            img = new Image();
            img.Source = map;

            mapCVS.Children.Add(img); //Add image to canvas
        }

        private void mapMakerFRM_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult newResult = MessageBox.Show("All unsaved changes will be lost.\nWould you like to close anyway?", "Warning!!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (newResult == MessageBoxResult.No) {
                e.Cancel = true;
            }
        }

        private void btnRightWindowChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            AppThemeChanger wnd = new AppThemeChanger();

            wnd.Show();
        }

        private void mapMakerFRM_Loaded(object sender, RoutedEventArgs e)
        {
            theTutorial.ShowDialog();
        }

        private void tutorialBTN_Click(object sender, RoutedEventArgs e)
        {
            theTutorial = new tutorial();
            theTutorial.ShowDialog();
        }
    }
}
