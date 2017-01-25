using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleProse.Lib
{
    class deadline
    {
        private DateTime newDeadline;
        public deadline(int year, int month, int day) {
            newDeadline = new DateTime(year, month, day);
        }
        public int[] changeDeadline { //Deadline... elements go year, month, day
            set {
                try
                {
                    newDeadline = new DateTime(value[0], value[1], value[2]);
                }
                catch (IndexOutOfRangeException) {
                }
            }
        }
        public DateTime getDate {
            get {
                return newDeadline;
            }
        }
        public int timeLeft {
            get {
                if (DateTime.Now > newDeadline) return 0; //Deadline must be in the future
                else return (int)Math.Ceiling(newDeadline.Subtract(DateTime.Now).TotalDays); //Round number of days left up and return as int
            }
        }
    }
}
