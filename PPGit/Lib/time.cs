using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGit.Lib
{
    public static class time
    {
        public static DateTime firstDay;
        public static DateTime lastDay;
        private static List<PPGit.Lib.deadline> deadlines = new List<PPGit.Lib.deadline>();
        public static int currentWords;
        public static PPGit.Lib.deadline addDeadline
        {
            set
            {
                deadlines.Add(value);
            }
        }
        public static List<PPGit.Lib.deadline> getAllDeadlines()
        {
            return deadlines;
        }
        public static void removeDeadline(PPGit.Lib.deadline removeThis)
        {
            deadlines.Remove(removeThis);
        }
        public static bool deadlineMatch(int day)
        { //Do we have a match?
            foreach (PPGit.Lib.deadline newDead in deadlines)
            {
                if (newDead.thisDeadline(firstDay.Year, firstDay.Month, day)) return true;
            }
            return false; //No match
        }
        public static PPGit.Lib.deadline returnDeadline(int day)
        {
            DateTime date = new DateTime(firstDay.Year, firstDay.Month, day);
            foreach (PPGit.Lib.deadline thisDeadline in deadlines)
            {
                if (thisDeadline.getDate == date) return thisDeadline;
            }
            return null;
        }
        public static string Name
        {
            get
            {
                string month;
                switch (firstDay.Month)
                {
                    case 1:
                        month = "January";
                        break;
                    case 2:
                        month = "February";
                        break;
                    case 3:
                        month = "March";
                        break;
                    case 4:
                        month = "April";
                        break;
                    case 5:
                        month = "May";
                        break;
                    case 6:
                        month = "June";
                        break;
                    case 7:
                        month = "July";
                        break;
                    case 8:
                        month = "August";
                        break;
                    case 9:
                        month = "September";
                        break;
                    case 10:
                        month = "October";
                        break;
                    case 11:
                        month = "November";
                        break;
                    case 12:
                        month = "December";
                        break;
                    default:
                        return "INVALID";
                }
                return month + " " + firstDay.Year;
            }
        }
        public static bool thisMonth()
        {
            if (firstDay.Month == DateTime.Now.Month && firstDay.Year == DateTime.Now.Year) return true;
            else return false;
        }
    }
}
