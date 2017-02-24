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
    /// Interaction logic for addDeadline.xaml
    /// </summary>
    public partial class addDeadline : Window
    {
        public addDeadline()
        {
            InitializeComponent();
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
                if (wrdCHK.IsChecked == true && wordCntTXT.Text == "") throw new InvalidCastException();
                if(wrdCHK.IsChecked == true) num = Convert.ToInt32(wordCntTXT.Text);
                if (wrdCHK.IsChecked == true && num < 1) { //It must be greater than 1
                    MessageBox.Show("NUMBER MUST BE GREATER THAN 1", "ERROR", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    wordCntTXT.Background = Brushes.Red;
                    wordCntTXT.Foreground = Brushes.White;
                } else if (dateCAL.SelectedDate > DateTime.Now) //Check if selectedDate is in the future
                {
                    PurpleProse.Lib.deadline newDeadline = new PurpleProse.Lib.deadline(dateCAL.SelectedDate.Value.Year, dateCAL.SelectedDate.Value.Month, dateCAL.SelectedDate.Value.Day, num);
                    PPGit.Lib.time.addDeadline = newDeadline;
                    this.Close();
                 } else {
                    MessageBox.Show("ERROR: Date must be in the FUTURE!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            } catch (InvalidCastException) {
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
    }
}
