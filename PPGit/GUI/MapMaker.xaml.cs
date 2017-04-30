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

namespace PPGit.GUI
{
    /// <summary>
    /// Interaction logic for MapMaker.xaml
    /// </summary>
    public partial class MapMaker : Window
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
            picLoc = new Uri(@"..\..\Map POIs\mountains.png", UriKind.Relative); //Location of the image
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

        private void mapCVS_MouseDown(object sender, MouseButtonEventArgs e)
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
                else {
                    map = new BitmapImage(picLoc);
                    img = new Image();
                    img.Source = map;
                    mapCVS.Children.Add(img);
                }
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
    }
}
