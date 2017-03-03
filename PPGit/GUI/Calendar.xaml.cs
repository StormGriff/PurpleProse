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
        public Calendar(int words = 0)
        {
            Lib.time.currentWords = words;
            InitializeComponent();
        }

        private SolidColorBrush deadlineColor = Brushes.OrangeRed;

        private void calWND_Loaded(object sender, RoutedEventArgs e)
        {
            PPGit.Lib.time.firstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            PPGit.Lib.time.lastDay = PPGit.Lib.time.firstDay.AddMonths(1).AddDays(-1);
            monthLBL.Content = PPGit.Lib.time.Name;
            SetLeft(); //How many days/words left?
            int x = 1; //Counting days
            if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Sunday) //Populating days
            {
                num1.Content = x;
                if (DateTime.Now.Day == x) day1.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day1.Background = deadlineColor;
                x++;
                num2.Content = x;
                if (DateTime.Now.Day == x) day2.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day2.Background = deadlineColor;
                x++;
                num3.Content = x;
                if (DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day3.Background = deadlineColor;
                x++;
                num4.Content = x;
                if (DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Monday) //Where does the month start?
            {
                num2.Content = x;
                if (DateTime.Now.Day == x) day2.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day2.Background = deadlineColor;
                x++;
                num3.Content = x;
                if (DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day3.Background = deadlineColor;
                x++;
                num4.Content = x;
                if (DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Tuesday)  //We are populating the first week
            {
                num3.Content = x;
                if (DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day3.Background = deadlineColor;
                x++;
                num4.Content = x;
                if (DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Wednesday)
            {
                num4.Content = x;
                if (DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Thursday)
            {
                num5.Content = x;
                if (DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Friday)
            {
                num6.Content = x;
                if (DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Saturday) {
                num7.Content = x;
                if (DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            //Populate the rest of the weeks
            if (x <= PPGit.Lib.time.lastDay.Day) {
                num8.Content = x;
                if (DateTime.Now.Day == x) day8.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day8.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num9.Content = x;
                if (DateTime.Now.Day == x) day9.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day9.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num10.Content = x;
                if (DateTime.Now.Day == x) day10.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day10.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num11.Content = x;
                if (DateTime.Now.Day == x) day11.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day11.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num12.Content = x;
                if (DateTime.Now.Day == x) day12.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day12.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num13.Content = x;
                if (DateTime.Now.Day == x) day13.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day13.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num14.Content = x;
                if (DateTime.Now.Day == x) day14.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day14.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num15.Content = x;
                if (DateTime.Now.Day == x) day15.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day15.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num16.Content = x;
                if (DateTime.Now.Day == x) day16.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day16.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num17.Content = x;
                if (DateTime.Now.Day == x) day17.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day17.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num18.Content = x;
                if (DateTime.Now.Day == x) day18.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day18.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num19.Content = x;
                if (DateTime.Now.Day == x) day19.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day19.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num20.Content = x;
                if (DateTime.Now.Day == x) day20.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day20.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num21.Content = x;
                if (DateTime.Now.Day == x) day21.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day21.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num22.Content = x;
                if (DateTime.Now.Day == x) day22.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day22.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num23.Content = x;
                if (DateTime.Now.Day == x) day23.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day23.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num24.Content = x;
                if (DateTime.Now.Day == x) day24.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day24.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num25.Content = x;
                if (DateTime.Now.Day == x) day25.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day25.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num26.Content = x;
                if (DateTime.Now.Day == x) day26.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day26.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num27.Content = x;
                if (DateTime.Now.Day == x) day27.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day27.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num28.Content = x;
                if (DateTime.Now.Day == x) day28.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day28.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num29.Content = x;
                if (DateTime.Now.Day == x) day29.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day29.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num30.Content = x;
                if (DateTime.Now.Day == x) day30.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day30.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num31.Content = x;
                if (DateTime.Now.Day == x) day31.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day31.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num32.Content = x;
                if (DateTime.Now.Day == x) day32.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day32.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num33.Content = x;
                if (DateTime.Now.Day == x) day33.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day33.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num34.Content = x;
                if (DateTime.Now.Day == x) day34.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day34.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num35.Content = x;
                if (DateTime.Now.Day == x) day35.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day35.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num36.Content = x;
                if (DateTime.Now.Day == x) day36.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day36.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num37.Content = x;
                if (DateTime.Now.Day == x) day37.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day37.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num38.Content = x;
                if (DateTime.Now.Day == x) day38.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day38.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num39.Content = x;
                if (DateTime.Now.Day == x) day39.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day39.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num40.Content = x;
                if (DateTime.Now.Day == x) day40.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day40.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num41.Content = x;
                if (DateTime.Now.Day == x) day41.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day41.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num42.Content = x;
                if (DateTime.Now.Day == x) day42.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day42.Background = deadlineColor;
                x++;
            }
        }

        private void SetLeft() { //Sets how many days and words left for deadline in GUI
            wordsLeftLBL.Visibility = Visibility.Hidden;
            daysLeftLBL.Visibility = Visibility.Hidden;
            int words = 0;
            int days = 0;
            DateTime lastDate = DateTime.MaxValue;
            foreach (PurpleProse.Lib.deadline theDeadline in Lib.time.getAllDeadlines()) {
                if (days == 0) days = theDeadline.timeLeft;
                else if (theDeadline.timeLeft < days) days = theDeadline.timeLeft;
                if (theDeadline.wordsLeft > 0 && theDeadline.getDate < lastDate) {
                    lastDate = theDeadline.getDate;
                    words = theDeadline.wordsLeft;
                }
            }
            if (days > 0) {
                daysLeftLBL.Content = days + " days left till nearest deadline";
                daysLeftLBL.Visibility = Visibility.Visible;
            }
            if (words > 0) {
                wordsLeftLBL.Content = words + " words left for nearest deadline";
                wordsLeftLBL.Visibility = Visibility.Visible;
            }
        }

        private void clearAll() {
            day1.Background = null;
            day2.Background = null;
            day3.Background = null;
            day4.Background = null;
            day5.Background = null;
            day6.Background = null;
            day7.Background = null;
            day8.Background = null;
            day9.Background = null;
            day10.Background = null;
            day11.Background = null;
            day12.Background = null;
            day13.Background = null;
            day14.Background = null;
            day15.Background = null;
            day16.Background = null;
            day17.Background = null;
            day18.Background = null;
            day19.Background = null;
            day20.Background = null;
            day21.Background = null;
            day22.Background = null;
            day23.Background = null;
            day24.Background = null;
            day25.Background = null;
            day26.Background = null;
            day27.Background = null;
            day28.Background = null;
            day29.Background = null;
            day30.Background = null;
            day31.Background = null;
            day32.Background = null;
            day33.Background = null;
            day34.Background = null;
            day35.Background = null;
            day36.Background = null;
            day37.Background = null;
            day38.Background = null;
            day39.Background = null;
            day40.Background = null;
            day41.Background = null;
            day42.Background = null;
        }

        private void rtBTN_Click(object sender, RoutedEventArgs e)
        {
            PPGit.Lib.time.firstDay = PPGit.Lib.time.firstDay.AddMonths(1);
            bool thisMonth = PPGit.Lib.time.thisMonth();
            PPGit.Lib.time.lastDay = PPGit.Lib.time.firstDay.AddMonths(1).AddDays(-1);
            monthLBL.Content = PPGit.Lib.time.Name;
            clearAll();
            SetLeft();
            int x = 1; //Counting days
            if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Sunday) //Populating days
            {
                num1.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day1.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day1.Background = deadlineColor;
                x++;
                num2.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day2.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day2.Background = deadlineColor;
                x++;
                num3.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day3.Background = deadlineColor;
                x++;
                num4.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Monday) //Where does the month start?
            {
                num1.Content = "";
                num2.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day2.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day2.Background = deadlineColor;
                x++;
                num3.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day3.Background = deadlineColor;
                x++;
                num4.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Tuesday)  //We are populating the first week
            {
                num1.Content = ""; //Clear out other two
                num2.Content = "";
                num3.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day3.Background = deadlineColor;
                x++;
                num4.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Wednesday)
            {
                num1.Content = "";
                num2.Content = "";
                num3.Content = "";
                num4.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Thursday)
            {
                num1.Content = "";
                num2.Content = "";
                num3.Content = "";
                num4.Content = "";
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Friday)
            {
                num1.Content = "";
                num2.Content = "";
                num3.Content = "";
                num4.Content = "";
                num5.Content = "";
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Saturday)
            {
                num1.Content = "";  //Clearing the other 6 days of the week
                num2.Content = "";
                num3.Content = "";
                num4.Content = "";
                num5.Content = "";
                num6.Content = "";
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            //Populate the rest of the weeks
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num8.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day8.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day8.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num9.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day9.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day9.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num10.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day10.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day10.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num11.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day11.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day11.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num12.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day12.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day12.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num13.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day13.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day13.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num14.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day14.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day14.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num15.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day15.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day15.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num16.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day16.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day16.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num17.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day17.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day17.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num18.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day18.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day18.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num19.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day19.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day19.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num20.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day20.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day20.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num21.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day21.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day21.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num22.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day22.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day22.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num23.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day23.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day23.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num24.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day24.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day24.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num25.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day25.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day25.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num26.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day26.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day26.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num27.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day27.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day27.Background = deadlineColor;
                x++;
            }
            else { //Clear the rest of them
                num27.Content = "";
                num28.Content = "";
                num29.Content = "";
                num30.Content = "";
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num28.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day28.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day28.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num28.Content = "";
                num29.Content = "";
                num30.Content = "";
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num29.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day29.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day29.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num29.Content = "";
                num30.Content = "";
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num30.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day30.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day30.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num30.Content = "";
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num31.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day31.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day31.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num32.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day32.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day32.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num33.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day33.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day33.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num34.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day34.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day34.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num35.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day35.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day35.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day) {
                num36.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day36.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day36.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day) {
                num37.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day37.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day37.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day) {
                num38.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day38.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day38.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day) {
                num39.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day39.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day39.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day) {
                num40.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day40.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day40.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day) {
                num41.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day41.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day41.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day) {
                num42.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day42.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day42.Background = deadlineColor;
            }
        }

        private void lftBTN_Click(object sender, RoutedEventArgs e)
        {
            PPGit.Lib.time.firstDay = PPGit.Lib.time.firstDay.AddMonths(-1);
            bool thisMonth = PPGit.Lib.time.thisMonth();
            PPGit.Lib.time.lastDay = PPGit.Lib.time.firstDay.AddMonths(1).AddDays(-1);
            monthLBL.Content = PPGit.Lib.time.Name;
            clearAll();
            SetLeft();
            int x = 1; //Counting days
            if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Sunday) //Populating days
            {
                num1.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day1.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day1.Background = deadlineColor;
                x++;
                num2.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day2.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day2.Background = deadlineColor;
                x++;
                num3.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day3.Background = deadlineColor;
                x++;
                num4.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Monday) //Where does the month start?
            {
                num1.Content = "";
                num2.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day2.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day2.Background = deadlineColor;
                x++;
                num3.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day3.Background = deadlineColor;
                x++;
                num4.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Tuesday)  //We are populating the first week
            {
                num1.Content = ""; //Clear out other two
                num2.Content = "";
                num3.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day3.Background = deadlineColor;
                x++;
                num4.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Wednesday)
            {
                num1.Content = "";
                num2.Content = "";
                num3.Content = "";
                num4.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Thursday)
            {
                num1.Content = "";
                num2.Content = "";
                num3.Content = "";
                num4.Content = "";
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Friday)
            {
                num1.Content = "";
                num2.Content = "";
                num3.Content = "";
                num4.Content = "";
                num5.Content = "";
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Saturday)
            {
                num1.Content = "";  //Clearing the other 6 days of the week
                num2.Content = "";
                num3.Content = "";
                num4.Content = "";
                num5.Content = "";
                num6.Content = "";
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            //Populate the rest of the weeks
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num8.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day8.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day8.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num9.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day9.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day9.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num10.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day10.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day10.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num11.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day11.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day11.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num12.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day12.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day12.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num13.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day13.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day13.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num14.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day14.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day14.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num15.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day15.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day15.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num16.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day16.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day16.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num17.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day17.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day17.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num18.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day18.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day18.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num19.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day19.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day19.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num20.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day20.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day20.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num21.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day21.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day21.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num22.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day22.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day22.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num23.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day23.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day23.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num24.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day24.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day24.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num25.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day25.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day25.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num26.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day26.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day26.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num27.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day27.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day27.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num27.Content = "";
                num28.Content = "";
                num29.Content = "";
                num30.Content = "";
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num28.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day28.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day28.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num28.Content = "";
                num29.Content = "";
                num30.Content = "";
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num29.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day29.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day29.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num29.Content = "";
                num30.Content = "";
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num30.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day30.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day30.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num30.Content = "";
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num31.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day31.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day31.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num32.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day32.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day32.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num33.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day33.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day33.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num34.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day34.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day34.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num35.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day35.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day35.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num36.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day36.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day36.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num37.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day37.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day37.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num38.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day38.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day38.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num39.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day39.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day39.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num40.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day40.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day40.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num41.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day41.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day41.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num42.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day42.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day42.Background = deadlineColor;
            }
        }

        private void addBTN_Click(object sender, RoutedEventArgs e)
        {
            addDeadline newDeadline = new addDeadline();
            newDeadline.ShowDialog();
            bool thisMonth = PPGit.Lib.time.thisMonth();
            clearAll();
            SetLeft();
            int x = 1; //Counting days
            if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Sunday) //Populating days
            {
                num1.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day1.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day1.Background = deadlineColor;
                x++;
                num2.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day2.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day2.Background = deadlineColor;
                x++;
                num3.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day3.Background = deadlineColor;
                x++;
                num4.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Monday) //Where does the month start?
            {
                num1.Content = "";
                num2.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day2.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day2.Background = deadlineColor;
                x++;
                num3.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day3.Background = deadlineColor;
                x++;
                num4.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Tuesday)  //We are populating the first week
            {
                num1.Content = ""; //Clear out other two
                num2.Content = "";
                num3.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day3.Background = deadlineColor;
                x++;
                num4.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Wednesday)
            {
                num1.Content = "";
                num2.Content = "";
                num3.Content = "";
                num4.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day4.Background = deadlineColor;
                x++;
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Thursday)
            {
                num1.Content = "";
                num2.Content = "";
                num3.Content = "";
                num4.Content = "";
                num5.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day5.Background = deadlineColor;
                x++;
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Friday)
            {
                num1.Content = "";
                num2.Content = "";
                num3.Content = "";
                num4.Content = "";
                num5.Content = "";
                num6.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day6.Background = deadlineColor;
                x++;
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Saturday)
            {
                num1.Content = "";  //Clearing the other 6 days of the week
                num2.Content = "";
                num3.Content = "";
                num4.Content = "";
                num5.Content = "";
                num6.Content = "";
                num7.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day7.Background = deadlineColor;
                x++;
            }
            //Populate the rest of the weeks
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num8.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day8.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day8.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num9.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day9.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day9.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num10.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day10.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day10.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num11.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day11.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day11.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num12.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day12.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day12.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num13.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day13.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day13.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num14.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day14.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day14.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num15.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day15.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day15.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num16.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day16.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day16.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num17.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day17.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day17.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num18.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day18.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day18.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num19.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day19.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day19.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num20.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day20.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day20.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num21.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day21.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day21.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num22.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day22.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day22.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num23.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day23.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day23.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num24.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day24.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day24.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num25.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day25.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day25.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num26.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day26.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day26.Background = deadlineColor;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num27.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day27.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day27.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num27.Content = "";
                num28.Content = "";
                num29.Content = "";
                num30.Content = "";
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num28.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day28.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day28.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num28.Content = "";
                num29.Content = "";
                num30.Content = "";
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num29.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day29.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day29.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num29.Content = "";
                num30.Content = "";
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num30.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day30.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day30.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num30.Content = "";
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num31.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day31.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day31.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num31.Content = "";
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num32.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day32.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day32.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num32.Content = "";
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num33.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day33.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day33.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num33.Content = "";
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num34.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day34.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day34.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num34.Content = "";
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num35.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day35.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day35.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num35.Content = "";
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num36.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day36.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day36.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num36.Content = "";
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num37.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day37.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day37.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num37.Content = "";
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num38.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day38.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day38.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num38.Content = "";
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num39.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day39.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day39.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num39.Content = "";
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num40.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day40.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day40.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num40.Content = "";
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num41.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day41.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day41.Background = deadlineColor;
                x++;
            }
            else
            { //Clear the rest of them
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num42.Content = x;
                if (thisMonth && DateTime.Now.Day == x) day42.Background = Brushes.LightGreen;
                else if (PPGit.Lib.time.deadlineMatch(x)) day42.Background = deadlineColor;
            }
        }

        private void day1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void day9_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
