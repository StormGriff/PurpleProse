using System.Diagnostics;

namespace PPGit.Lib
{
    public static class TextOps
    {
        public static string editor;
        static public void Open(string file) { Process.Start(editor, "\"" + file + "\""); }
    }
}
