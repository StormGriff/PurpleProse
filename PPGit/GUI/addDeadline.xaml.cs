﻿using System;
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
                if (wordCntTXT.Text == "") throw new InvalidCastException();
                int num = Convert.ToInt32(wordCntTXT.Text);
                if (num < 1) { //It must be greater than 1
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
    }
}