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
    /// Interaction logic for tutorial.xaml
    /// </summary>
    public partial class tutorial : Window
    {
        public tutorial()
        {
            InitializeComponent();
        }

        private void playFromBeginning() {
            videoPlayer.Position = new TimeSpan(0);
            videoPlayer.Play();
        }

        private void tutorialFRM_Activated(object sender, EventArgs e)
        {
            playFromBeginning();
        }

        private void videoPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            playFromBeginning();
        }

        private void clsBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tutorialFRM_Deactivated(object sender, EventArgs e)
        {
            videoPlayer.Pause();
        }
    }
}
