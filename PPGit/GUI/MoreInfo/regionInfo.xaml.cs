using System;
using System.Windows.Controls;

using MahApps.Metro.Controls;


namespace PPGit.GUI.MoreInfo
{
    /// <summary>
    /// Interaction logic for regionInfo.xaml
    /// </summary>
    public partial class regionInfo : MetroWindow
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
