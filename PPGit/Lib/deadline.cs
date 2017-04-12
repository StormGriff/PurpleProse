using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPGit.Lib
{
    public class deadline
    {
        private DateTime newDeadline;
        private int wordCount;
        private bool usingWordCount;
        private string notes;
        private bool usingNotes;
        public deadline(int year, int month, int day, int wordCount, bool usingWordCount = false, string notes = null)
        {
            newDeadline = new DateTime(year, month, day);
            this.wordCount = wordCount;
            this.usingWordCount = usingWordCount;
            if (notes == null) usingNotes = false;
            else
            {
                usingNotes = true;
                this.notes = notes;
            }
        }
        public int[] changeDeadline
        { //Deadline... elements go year, month, day
            set
            {
                try
                {
                    newDeadline = new DateTime(value[0], value[1], value[2]);
                }
                catch (IndexOutOfRangeException)
                {
                }
            }
        }
        public bool thisDeadline(int year, int month, int day)
        {  //Is this the deadline?
            if (newDeadline.Year == year && newDeadline.Month == month && newDeadline.Day == day) return true;
            else return false;
        }
        public int theWordCount
        {
            set
            {
                wordCount = value;
            }
            get
            {
                return wordCount;
            }
        }
        public DateTime getDate
        {
            get
            {
                return newDeadline;
            }
        }
        public int wordsLeft
        {
            get
            {
                if (usingWordCount) return wordCount - PPGit.Lib.time.currentWords;
                else return 0;
            }
            set
            {
                int left = wordCount - PPGit.Lib.time.currentWords;
                int newValue = value - left; //What was the change?
                wordCount += newValue;
            }
        }
        public int timeLeft
        {
            get
            {
                if (DateTime.Now > newDeadline) return 0; //Deadline must be in the future
                else return (int)Math.Ceiling(newDeadline.Subtract(DateTime.Now).TotalDays); //Round number of days left up and return as int
            }
        }
        public string getSetNotes
        {
            get
            {
                if (usingNotes) return notes;
                else return null;
            }
            set
            {
                notes = value;
            }
        }
    }
}
