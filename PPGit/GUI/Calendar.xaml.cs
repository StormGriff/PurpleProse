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
    /// Interaction logic for Calendar.xaml
    /// </summary>
    public partial class Calendar : Window
    {
        public Calendar()
        {
            InitializeComponent();
        }

        private void calWND_Loaded(object sender, RoutedEventArgs e)
        {
            var firstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            var lastDay = firstDay.AddMonths(1).AddDays(-1);
            monthLBL.Content = PPGit.Lib.time.monthName(DateTime.Now.Month);
            int x = 1; //Counting days
            if (firstDay.DayOfWeek == DayOfWeek.Sunday) //Populating days
            {
                num1.Content = x;
                x++;
                num2.Content = x;
                x++;
                num3.Content = x;
                x++;
                num4.Content = x;
                x++;
                num5.Content = x;
                x++;
                num6.Content = x;
                x++;
                num7.Content = x;
                x++;
            }
            else if (firstDay.DayOfWeek == DayOfWeek.Monday) //Where does the month start?
            {
                num2.Content = x;
                x++;
                num3.Content = x;
                x++;
                num4.Content = x;
                x++;
                num5.Content = x;
                x++;
                num6.Content = x;
                x++;
                num7.Content = x;
                x++;
            }
            else if (firstDay.DayOfWeek == DayOfWeek.Tuesday)  //We are populating the first week
            {
                num3.Content = x;
                x++;
                num4.Content = x;
                x++;
                num5.Content = x;
                x++;
                num6.Content = x;
                x++;
                num7.Content = x;
                x++;
            }
            else if (firstDay.DayOfWeek == DayOfWeek.Wednesday)
            {
                num4.Content = x;
                x++;
                num5.Content = x;
                x++;
                num6.Content = x;
                x++;
                num7.Content = x;
                x++;
            }
            else if (firstDay.DayOfWeek == DayOfWeek.Thursday)
            {
                num5.Content = x;
                x++;
                num6.Content = x;
                x++;
                num7.Content = x;
                x++;
            }
            else if (firstDay.DayOfWeek == DayOfWeek.Friday)
            {
                num6.Content = x;
                x++;
                num7.Content = x;
                x++;
            }
            else if (firstDay.DayOfWeek == DayOfWeek.Saturday) {
                num7.Content = x;
                x++;
            }
            //Populate the rest of the weeks
            if (x <= lastDay.Day) {
                num8.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num9.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num10.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num11.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num12.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num13.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num14.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num15.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num16.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num17.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num18.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num19.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num20.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num21.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num22.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num23.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num24.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num25.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num26.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num27.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num28.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num29.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num30.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num31.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num32.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num33.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num34.Content = x;
                x++;
            }
            if (x <= lastDay.Day)
            {
                num35.Content = x;
                x++;
            }
        }
    }
}
