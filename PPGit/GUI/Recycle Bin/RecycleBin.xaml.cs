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

namespace PPGit.GUI.Recycle_Bin
{
    /// <summary>
    /// Interaction logic for RecycleBin.xaml
    /// </summary>
    public partial class RecycleBin : Window
    {
        public RecycleBin()
        {
            InitializeComponent();
        }

        private void recycleFRM_Initialized(object sender, EventArgs e)
        {
            PPGit.Lib.recycle.Bin.add(new PurpleProse.Lib.Character("John", null, null, null, 0, null, null, null, null, null, null));
            PPGit.Lib.recycle.Bin.add(new PurpleProse.Lib.Character("James", null, null, null, 0, null, null, null, null, null, null));
            PPGit.Lib.recycle.Bin.add(new PurpleProse.Lib.Character("Jack", null, null, null, 0, null, null, null, null, null, null));
            PPGit.Lib.recycle.Bin.add(new PurpleProse.Lib.Character("Jill", null, null, null, 0, null, null, null, null, null, null));
            List<PPGit.Lib.recycle.item> theList = PPGit.Lib.recycle.Bin.getList;
            foreach (PPGit.Lib.recycle.item thisOb in theList) {
                TimeSpan newSpan = thisOb.delete - DateTime.Now;
                binLST.Items.Add(thisOb.myObject.Name + "  |  " + newSpan.Days + " days remaining");
            }
        }
    }
}
