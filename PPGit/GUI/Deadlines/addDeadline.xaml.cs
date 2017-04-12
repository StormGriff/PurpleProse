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

namespace PPGit.GUI.Deadlines
{
    /// <summary>
    /// Interaction logic for addDeadline.xaml
    /// </summary>
    public partial class addDeadline : MetroWindow
    {
        public addDeadline()
        {
            InitializeComponent();
        }

        private void btnRightWindowChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            AppThemeChanger wnd = new AppThemeChanger();

            wnd.Show();
        }

        private void cnclBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int num = 0;
                string newString;
                if (notesCHK.IsChecked == true) newString = notesTXT.Text;
                else newString = null;
                if (wrdCHK.IsChecked == true && wordCntTXT.Text == "") throw new InvalidCastException();
                if (wrdCHK.IsChecked == true) num = Convert.ToInt32(wordCntTXT.Text);
                if (wrdCHK.IsChecked == true && num < 1)
                { //It must be greater than 1
                    MessageBox.Show("NUMBER MUST BE GREATER THAN 1", "ERROR", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    wordCntTXT.Background = Brushes.Red;
                    wordCntTXT.Foreground = Brushes.White;
                }
                else if (dateCAL.SelectedDate > DateTime.Now) //Check if selectedDate is in the future
                {
                    bool usingWordCount;
                    if (wrdCHK.IsChecked == true) usingWordCount = true;
                    else usingWordCount = false;
                    PPGit.Lib.deadline newDeadline = new PPGit.Lib.deadline(dateCAL.SelectedDate.Value.Year, dateCAL.SelectedDate.Value.Month, dateCAL.SelectedDate.Value.Day, num, usingWordCount, newString);
                    PPGit.Lib.time.addDeadline = newDeadline;
                    this.Close();
                }
                else {
                    MessageBox.Show("ERROR: Date must be in the FUTURE!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (InvalidCastException)
            {
                MessageBox.Show("ERROR: No number entered", "ERROR", MessageBoxButton.OK, MessageBoxImage.Stop);
                wordCntTXT.Background = Brushes.Red;
                wordCntTXT.Foreground = Brushes.White;
            }
        }

        private void addDeadline1_Loaded(object sender, RoutedEventArgs e)
        {
            dateCAL.IsEnabled = false;
            wordCntLBL.IsEnabled = false;
            wordCntTXT.IsEnabled = false;
            notesTXT.IsEnabled = false;
        }

        private void grd1_MouseEnter(object sender, MouseEventArgs e)
        {
            dateCAL.IsEnabled = true;
        }

        private void grd1_MouseLeave(object sender, MouseEventArgs e)
        {
            dateCAL.IsEnabled = false;
        }

        private void dateCAL_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            Mouse.Capture(null);
        }

        private void wrdCHK_Checked(object sender, RoutedEventArgs e)
        {
            wordCntTXT.IsEnabled = true;
            wordCntLBL.IsEnabled = true;
        }

        private void wrdCHK_Unchecked(object sender, RoutedEventArgs e)
        {
            wordCntTXT.IsEnabled = false;
            wordCntLBL.IsEnabled = false;
        }

        private void notesCHK_Checked(object sender, RoutedEventArgs e)
        {
            notesTXT.IsEnabled = true;
        }

        private void notesCHK_Unchecked(object sender, RoutedEventArgs e)
        {
            notesTXT.IsEnabled = false;
        }
    }
}
