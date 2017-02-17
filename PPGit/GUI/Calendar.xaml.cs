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
            PPGit.Lib.time.firstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            PPGit.Lib.time.lastDay = PPGit.Lib.time.firstDay.AddMonths(1).AddDays(-1);
            monthLBL.Content = PPGit.Lib.time.monthName(DateTime.Now.Month);
            int x = 1; //Counting days
            if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Sunday) //Populating days
            {
                num1.Content = x;
                if (DateTime.Now.Day == x) day1.Background = Brushes.LightGreen;
                x++;
                num2.Content = x;
                if (DateTime.Now.Day == x) day2.Background = Brushes.LightGreen;
                x++;
                num3.Content = x;
                if (DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                x++;
                num4.Content = x;
                if (DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                x++;
                num5.Content = x;
                if (DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                x++;
                num6.Content = x;
                if (DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                x++;
                num7.Content = x;
                if (DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Monday) //Where does the month start?
            {
                num2.Content = x;
                if (DateTime.Now.Day == x) day2.Background = Brushes.LightGreen;
                x++;
                num3.Content = x;
                if (DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                x++;
                num4.Content = x;
                if (DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                x++;
                num5.Content = x;
                if (DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                x++;
                num6.Content = x;
                if (DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                x++;
                num7.Content = x;
                if (DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Tuesday)  //We are populating the first week
            {
                num3.Content = x;
                if (DateTime.Now.Day == x) day3.Background = Brushes.LightGreen;
                x++;
                num4.Content = x;
                if (DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                x++;
                num5.Content = x;
                if (DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                x++;
                num6.Content = x;
                if (DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                x++;
                num7.Content = x;
                if (DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Wednesday)
            {
                num4.Content = x;
                if (DateTime.Now.Day == x) day4.Background = Brushes.LightGreen;
                x++;
                num5.Content = x;
                if (DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                x++;
                num6.Content = x;
                if (DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                x++;
                num7.Content = x;
                if (DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Thursday)
            {
                num5.Content = x;
                if (DateTime.Now.Day == x) day5.Background = Brushes.LightGreen;
                x++;
                num6.Content = x;
                if (DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                x++;
                num7.Content = x;
                if (DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Friday)
            {
                num6.Content = x;
                if (DateTime.Now.Day == x) day6.Background = Brushes.LightGreen;
                x++;
                num7.Content = x;
                if (DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Saturday) {
                num7.Content = x;
                if (DateTime.Now.Day == x) day7.Background = Brushes.LightGreen;
                x++;
            }
            //Populate the rest of the weeks
            if (x <= PPGit.Lib.time.lastDay.Day) {
                num8.Content = x;
                if (DateTime.Now.Day == x) day8.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num9.Content = x;
                if (DateTime.Now.Day == x) day9.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num10.Content = x;
                if (DateTime.Now.Day == x) day10.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num11.Content = x;
                if (DateTime.Now.Day == x) day11.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num12.Content = x;
                if (DateTime.Now.Day == x) day12.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num13.Content = x;
                if (DateTime.Now.Day == x) day13.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num14.Content = x;
                if (DateTime.Now.Day == x) day14.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num15.Content = x;
                if (DateTime.Now.Day == x) day15.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num16.Content = x;
                if (DateTime.Now.Day == x) day16.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num17.Content = x;
                if (DateTime.Now.Day == x) day17.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num18.Content = x;
                if (DateTime.Now.Day == x) day18.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num19.Content = x;
                if (DateTime.Now.Day == x) day19.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num20.Content = x;
                if (DateTime.Now.Day == x) day20.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num21.Content = x;
                if (DateTime.Now.Day == x) day21.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num22.Content = x;
                if (DateTime.Now.Day == x) day22.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num23.Content = x;
                if (DateTime.Now.Day == x) day23.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num24.Content = x;
                if (DateTime.Now.Day == x) day24.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num25.Content = x;
                if (DateTime.Now.Day == x) day25.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num26.Content = x;
                if (DateTime.Now.Day == x) day26.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num27.Content = x;
                if (DateTime.Now.Day == x) day27.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num28.Content = x;
                if (DateTime.Now.Day == x) day28.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num29.Content = x;
                if (DateTime.Now.Day == x) day29.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num30.Content = x;
                if (DateTime.Now.Day == x) day30.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num31.Content = x;
                if (DateTime.Now.Day == x) day31.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num32.Content = x;
                if (DateTime.Now.Day == x) day32.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num33.Content = x;
                if (DateTime.Now.Day == x) day33.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num34.Content = x;
                if (DateTime.Now.Day == x) day34.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num35.Content = x;
                if (DateTime.Now.Day == x) day35.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num36.Content = x;
                if (DateTime.Now.Day == x) day36.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num37.Content = x;
                if (DateTime.Now.Day == x) day37.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num38.Content = x;
                if (DateTime.Now.Day == x) day38.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num39.Content = x;
                if (DateTime.Now.Day == x) day39.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num40.Content = x;
                if (DateTime.Now.Day == x) day40.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num41.Content = x;
                if (DateTime.Now.Day == x) day41.Background = Brushes.LightGreen;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num42.Content = x;
                if (DateTime.Now.Day == x) day42.Background = Brushes.LightGreen;
                x++;
            }
        }

        private void rtBTN_Click(object sender, RoutedEventArgs e)
        {
            PPGit.Lib.time.firstDay = PPGit.Lib.time.firstDay.AddMonths(1);
            PPGit.Lib.time.lastDay = PPGit.Lib.time.firstDay.AddMonths(1).AddDays(-1);
            monthLBL.Content = PPGit.Lib.time.monthName(PPGit.Lib.time.firstDay.Month);
            int x = 1; //Counting days
            if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Sunday) //Populating days
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
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Monday) //Where does the month start?
            {
                num1.Content = "";
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
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Tuesday)  //We are populating the first week
            {
                num1.Content = ""; //Clear out other two
                num2.Content = "";
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
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Wednesday)
            {
                num1.Content = "";
                num2.Content = "";
                num3.Content = "";
                num4.Content = x;
                x++;
                num5.Content = x;
                x++;
                num6.Content = x;
                x++;
                num7.Content = x;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Thursday)
            {
                num1.Content = "";
                num2.Content = "";
                num3.Content = "";
                num4.Content = "";
                num5.Content = x;
                x++;
                num6.Content = x;
                x++;
                num7.Content = x;
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
                x++;
                num7.Content = x;
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
                x++;
            }
            //Populate the rest of the weeks
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num8.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num9.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num10.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num11.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num12.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num13.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num14.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num15.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num16.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num17.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num18.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num19.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num20.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num21.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num22.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num23.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num24.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num25.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num26.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num27.Content = x;
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
                x++;
            }
            else
            { //Clear the rest of them
                num41.Content = "";
                num42.Content = "";
            }
            if (x <= PPGit.Lib.time.lastDay.Day) {
                num42.Content = x;
            }
        }

        private void lftBTN_Click(object sender, RoutedEventArgs e)
        {
            PPGit.Lib.time.firstDay = PPGit.Lib.time.firstDay.AddMonths(-1);
            PPGit.Lib.time.lastDay = PPGit.Lib.time.firstDay.AddMonths(1).AddDays(-1);
            monthLBL.Content = PPGit.Lib.time.monthName(PPGit.Lib.time.firstDay.Month);
            int x = 1; //Counting days
            if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Sunday) //Populating days
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
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Monday) //Where does the month start?
            {
                num1.Content = "";
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
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Tuesday)  //We are populating the first week
            {
                num1.Content = ""; //Clear out other two
                num2.Content = "";
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
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Wednesday)
            {
                num1.Content = "";
                num2.Content = "";
                num3.Content = "";
                num4.Content = x;
                x++;
                num5.Content = x;
                x++;
                num6.Content = x;
                x++;
                num7.Content = x;
                x++;
            }
            else if (PPGit.Lib.time.firstDay.DayOfWeek == DayOfWeek.Thursday)
            {
                num1.Content = "";
                num2.Content = "";
                num3.Content = "";
                num4.Content = "";
                num5.Content = x;
                x++;
                num6.Content = x;
                x++;
                num7.Content = x;
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
                x++;
                num7.Content = x;
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
                x++;
            }
            //Populate the rest of the weeks
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num8.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num9.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num10.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num11.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num12.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num13.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num14.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num15.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num16.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num17.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num18.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num19.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num20.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num21.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num22.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num23.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num24.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num25.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num26.Content = x;
                x++;
            }
            if (x <= PPGit.Lib.time.lastDay.Day)
            {
                num27.Content = x;
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
            }
        }
    }
}
