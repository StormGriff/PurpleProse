using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PurpleProse
{
	public static class TextOps
	{	public static string editor;
		static public void Open(string file) { Process.Start(editor, "\"" + file + "\""); }
		/*public int Atoi(string text) {
			
		}*/
	}
}
