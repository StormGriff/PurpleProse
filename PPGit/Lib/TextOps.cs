using PPGit.GUI.TextEditor;
using PPGit.Lib;
using PPGit.Properties;
using System.Diagnostics;

namespace PPGit.Lib
{
	public static class TextOps
	{
		public static string editor = null;
		static public void Open()
		{	if (editor != null) Process.Start(editor);
			else
			{	TextEditor t = new TextEditor();
				t.Show();
			}
		}

		static public void Open(string file)
		{	if (editor != null) Process.Start(editor, "\"" + file + "\"");
			else
			{	TextEditor t = new TextEditor(file);
				t.Show();
			}
		}

		//v- If moved, undo unrolling.
		public static readonly char[] DIR_ILLEGALS = { '\\', '/',':','*','?', '<', '>', '|', Loader.ID_SEPARATOR };
		static public string ToDirectorySafe(string name)//Converts Object names into strings that may be used in file names
		{	string subdir = name;//This is just to make sure name is not edited, although I don't think it would be.
			//v- foreach(char illegal in DIR_ILLEGALS) subdir = subdir.Replace(illegal, '#'); #Unrolled -v
			subdir = subdir.Replace(DIR_ILLEGALS[0], '#').Replace(DIR_ILLEGALS[1], '#').Replace(DIR_ILLEGALS[2], '#').Replace(DIR_ILLEGALS[3], '#').Replace(DIR_ILLEGALS[4], '#').Replace(DIR_ILLEGALS[5], '#').Replace(DIR_ILLEGALS[6], '#').Replace(DIR_ILLEGALS[7], '#').Replace(DIR_ILLEGALS[8], '#');
			return subdir.ToLower();
		}
	}
}
