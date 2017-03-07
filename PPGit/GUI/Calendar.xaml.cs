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

        private void showDeadlineInfo(int day) {
            PurpleProse.Lib.deadline thisDeadline = PPGit.Lib.time.returnDeadline(day);
            PPGit.GUI.deadlineInfo newInfo = new deadlineInfo(thisDeadline);
            newInfo.ShowDialog();
        }

        private void wordsLeftOutput() {
            int num = 0;
            foreach (PurpleProse.Lib.deadline thisDeadline in Lib.time.getAllDeadlines()) {
                if (num == 0) num = thisDeadline.theWordCount;
                else if (thisDeadline.theWordCount < num && thisDeadline.theWordCount != 0) num = thisDeadline.theWordCount;
            }
            if (num == 0) wordsLeftLBL.IsEnabled = false;
            else wordsLeftLBL.Content = num + " Words left for nearest deadline";
        }

        private void day1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day1.Background == deadlineColor) {
                showDeadlineInfo(Convert.ToInt32(num1.Content));
                wordsLeftOutput();
            }
        }

        private void day9_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day9.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num9.Content));
                wordsLeftOutput();
            }
        }

        private void day2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day2.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num2.Content));
                wordsLeftOutput();
            }
        }

        private void day3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day3.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num3.Content));
                wordsLeftOutput();
            }
        }

        private void day4_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day4.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num4.Content));
                wordsLeftOutput();
            }
        }

        private void day5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day5.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num5.Content));
                wordsLeftOutput();
            }
        }

        private void day6_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day6.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num6.Content));
                wordsLeftOutput();
            }
        }

        private void day7_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day7.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num7.Content));
                wordsLeftOutput();
            }
        }

        private void day8_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day8.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num8.Content));
                wordsLeftOutput();
            }
        }

        private void day10_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day10.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num10.Content));
                wordsLeftOutput();
            }
        }

        private void day11_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day11.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num11.Content));
                wordsLeftOutput();
            }
        }

        private void day12_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day12.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num12.Content));
                wordsLeftOutput();
            }
        }

        private void day13_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day13.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num13.Content));
                wordsLeftOutput();
            }
        }

        private void day14_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day14.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num14.Content));
                wordsLeftOutput();
            }
        }

        private void day15_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day15.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num15.Content));
                wordsLeftOutput();
            }
        }

        private void day16_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day16.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num16.Content));
                wordsLeftOutput();
            }
        }

        private void day17_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day17.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num17.Content));
                wordsLeftOutput();
            }
        }

        private void day18_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day18.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num18.Content));
                wordsLeftOutput();
            }
        }

        private void day19_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day19.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num19.Content));
                wordsLeftOutput();
            }
        }

        private void day20_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day20.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num20.Content));
                wordsLeftOutput();
            }
        }

        private void day21_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day21.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num21.Content));
                wordsLeftOutput();
            }
        }

        private void day22_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day22.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num22.Content));
                wordsLeftOutput();
            }
        }

        private void day23_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day23.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num23.Content));
                wordsLeftOutput();
            }
        }

        private void day24_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day24.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num24.Content));
                wordsLeftOutput();
            }
        }

        private void day25_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day25.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num25.Content));
                wordsLeftOutput();
            }
        }

        private void day26_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day26.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num26.Content));
                wordsLeftOutput();
            }
        }

        private void day27_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day27.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num27.Content));
                wordsLeftOutput();
            }
        }

        private void day28_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day28.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num28.Content));
                wordsLeftOutput();
            }
        }

        private void day29_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day29.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num29.Content));
                wordsLeftOutput();
            }
        }

        private void day30_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day30.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num30.Content));
                wordsLeftOutput();
            }
        }

        private void day31_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day31.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num31.Content));
                wordsLeftOutput();
            }
        }

        private void day32_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day32.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num32.Content));
                wordsLeftOutput();
            }
        }

        private void day33_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day33.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num33.Content));
                wordsLeftOutput();
            }
        }

        private void day34_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day34.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num34.Content));
                wordsLeftOutput();
            }
        }

        private void day35_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day35.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num35.Content));
                wordsLeftOutput();
            }
        }

        private void day36_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day36.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num36.Content));
                wordsLeftOutput();
            }
        }

        private void day37_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day37.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num37.Content));
                wordsLeftOutput();
            }
        }

        private void day38_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day38.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num38.Content));
                wordsLeftOutput();
            }
        }

        private void day39_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day39.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num39.Content));
                wordsLeftOutput();
            }
        }

        private void day40_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day40.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num40.Content));
                wordsLeftOutput();
            }
        }

        private void day41_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day41.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num41.Content));
                wordsLeftOutput();
            }
        }

        private void day42_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (day42.Background == deadlineColor)
            {
                showDeadlineInfo(Convert.ToInt32(num42.Content));
                wordsLeftOutput();
            }
        }
    }
}
