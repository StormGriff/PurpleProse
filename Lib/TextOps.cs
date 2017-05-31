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
        {
            if (editor != null) Process.Start(editor);
            else
            {
                TextEditor t = new TextEditor();
                t.Show();
            }
        }
        static public void Open(Lib.Object theObject)
        {
            /*if (editor != null) Process.Start(editor, "\"" + file + "\"");
            else
            {*/
                TextEditor t = new TextEditor(theObject);
                t.ShowDialog();
            //}
        }
    }
}
