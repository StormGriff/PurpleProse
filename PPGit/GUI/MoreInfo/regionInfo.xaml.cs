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

namespace PPGit.GUI.MoreInfo
{
    /// <summary>
    /// Interaction logic for regionInfo.xaml
    /// </summary>
    public partial class regionInfo : Window
    {
        Lib.Region thisLoc;
        public regionInfo(Lib.Location theLoc)
        {
            thisLoc = (Lib.Region)theLoc;
            InitializeComponent();
        }

        private void regionInfoFRM_Closed(object sender, EventArgs e)
        {
            (thisLoc.window as DetailWindows.LocationWindow).openWindow = false;
        }

        private void regionInfoFRM_Initialized(object sender, EventArgs e)
        {
            terrainTXT.Text = thisLoc.terrain;
        }

        private void terrainTXT_TextChanged(object sender, TextChangedEventArgs e)
        {
            thisLoc.terrain = terrainTXT.Text;
        }
    }
}
