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
using System.IO;
using PPGit.Lib;

using Ookii.Dialogs.Wpf;
using MahApps.Metro.Controls;

namespace PPGit.GUI.Launcher
{
    /// <summary>
    /// Interaction logic for Launcher.xaml
    /// </summary>
    public partial class Launcher : MetroWindow
    {
        public Launcher()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            bool loadSuccess;
            PPGit.Lib.Loader l = new Lib.Loader();
            MainWindow win = new MainWindow();

            loadSuccess = l.Load();

            if(loadSuccess)
            {
                this.Close();
                win.Show();
            }
            else
            {
                MessageBox.Show("An Error Occured.");
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog ofd = new VistaFolderBrowserDialog();

            if(ofd.ShowDialog() == true)
            {
                MainWindow win = new MainWindow();

                string rootpath = ofd.SelectedPath + "\\" + TextOps.ToDirectorySafe(txtNew.Text);
                mainLists.projectDir = rootpath;

                if(!Directory.Exists(rootpath))
                {
                    try
                    {

                        Directory.CreateDirectory(rootpath);

                        File.Create(rootpath + "\\" + TextOps.ToDirectorySafe(txtNew.Text) + ".proj");

                        //in root project folder
                        Directory.CreateDirectory(rootpath + "\\items");
                        Directory.CreateDirectory(rootpath + "\\story");

                        Directory.CreateDirectory(rootpath + "\\items\\characters");
                        Directory.CreateDirectory(rootpath + "\\items\\locations");
                        Directory.CreateDirectory(rootpath + "\\items\\events");

                        File.Create(rootpath + "\\items\\characters\\char.list");
                        File.Create(rootpath + "\\items\\locations\\loc.list");
                        File.Create(rootpath + "\\items\\events\\event.list");

                        this.Close();
                        win.Show();
                    }
                    catch(ArgumentException ex)
                    {
                        MessageBox.Show("INVALID NAME", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}
