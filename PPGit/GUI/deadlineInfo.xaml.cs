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
    /// Interaction logic for deadlineInfo.xaml
    /// </summary>
    public partial class deadlineInfo : Window
    {
        PurpleProse.Lib.deadline thisDeadline;
        public deadlineInfo(PurpleProse.Lib.deadline myDeadline)
        {
            InitializeComponent();
            thisDeadline = myDeadline;
        }

        private void deadlineInfo1_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime theDate = thisDeadline.getDate;
            string month = Lib.time.Name;
            string day = theDate.Day.ToString();
            string year = theDate.Year.ToString();
            this.Title = month + " " + day + ", " + year;
        }
    }
}
