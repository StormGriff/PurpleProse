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
        public MapMaker()
        {
            InitializeComponent();
        }

        private void snowBTN_Click(object sender, RoutedEventArgs e)
        {
            ImageBrush newBrush = new ImageBrush();
            newBrush.ImageSource = new BitmapImage(new Uri(@"..\..\snow background.jpg", UriKind.Relative));
            mapCVS.Background = newBrush;
        }

        private void backgroundLST_Click(object sender, RoutedEventArgs e)
        {
            (sender as MenuItem).ContextMenu.IsEnabled = true;
            (sender as MenuItem).ContextMenu.PlacementTarget = (sender as MenuItem);
            (sender as MenuItem).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as MenuItem).ContextMenu.IsOpen = true;
        }
    }
}
