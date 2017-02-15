using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MusicPlayer
{
    class Music
    {
        //To import the dll winmn.dll which allows to play mp3 files
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string lpstrCommand, StringBuilder lpstrReturnString,
            int uReturnLength, int hwndCallback);

        //To open a file to our application
        public void open(string file)
        {
            string command = "open \"" + file + "\" type MPEGVideo alias MyMusic";
            mciSendString(command, null, 0, 0);
        }

        //To play the file
        public void play()
        {
            string command = "play MyMusic";
            mciSendString(command, null, 0, 0);
        }

        //To pause the file
        public void pause()
        {
            string command = "stop MyMusic";
            mciSendString(command, null, 0, 0);

        }

        //To stop the file
        public void stop()
        {
            string command = "close MyMusic";
            mciSendString(command, null, 0, 0);
        }
    }
}
