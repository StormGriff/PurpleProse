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
using System.Data;

namespace PPGit.GUI.Recycle_Bin
{
    /// <summary>
    /// Interaction logic for RecycleBin.xaml
    /// </summary>
    public partial class RecycleBin : Window
    {
        DataTable newTable;
        public RecycleBin()
        {
            newTable = new DataTable();
            InitializeComponent();
        }

        private void recycleFRM_Loaded(object sender, RoutedEventArgs e)
        {
            /*DataColumn newCol = new DataColumn();
            newCol.ColumnName = "Name"; //Column 1
            newCol.DataType = System.Type.GetType("System.String");
            newTable.Columns.Add(newCol);
            DataColumn newCol2 = new DataColumn();
            newCol2.ColumnName = "Deletion in... (days)";
            newCol2.DataType = System.Type.GetType("System.Int64");
            newTable.Columns.Add(newCol2);*/
            newTable.Columns.Add("Name", typeof(string));
            newTable.Columns.Add("Deleted", typeof(string));
            List<PPGit.Lib.recycle.item> theList = PPGit.Lib.recycle.Bin.getList;
            foreach (PPGit.Lib.recycle.item thisOb in theList)
            {
                TimeSpan newSpan = thisOb.delete - DateTime.Now;
                DataRow newRow = newTable.NewRow();
                newRow["Name"] = thisOb.myObject.Name;
                newRow["Deleted"] = Math.Ceiling(newSpan.TotalDays).ToString() + " days";
                newTable.Rows.Add(newRow);
                //newTable.Rows.Add(thisOb.myObject.Name, newSpan.Days);
            }
            binLST.ItemsSource = newTable.DefaultView;
        }

        private void restoreBTN_Click(object sender, RoutedEventArgs e)
        {
            if (binLST.SelectedItem != null) {
                int num = binLST.SelectedIndex;
                string find = newTable.Rows[num][0].ToString();
                PPGit.Lib.recycle.Bin.restore(find);
                newTable.Rows.Remove(newTable.Rows[num]);
            }
        }
    }
}
