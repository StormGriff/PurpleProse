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

using MahApps.Metro.Controls;
using MahApps.Metro;

namespace PPGit.GUI.MusicPlayer
{
    /// <summary>
    /// Interaction logic for MusicPlayer.xaml
    /// </summary>
    public partial class MusicPlayer : MetroWindow
    {
        Music m = new Music();

        public MusicPlayer()
        {
            InitializeComponent();
        }

        private void btnRightWindowChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            AppThemeChanger wnd = new AppThemeChanger();

            wnd.Show();
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            Ookii.Dialogs.Wpf.VistaOpenFileDialog ofd = new Ookii.Dialogs.Wpf.VistaOpenFileDialog();

            if(ofd.ShowDialog() == true)
            {
                m.open(ofd.FileName);
                txtNowPlaying.Text = ofd.FileName;
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            m.play();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            m.stop();
            txtNowPlaying.Text = "";
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            m.pause();
        }
    }
}
