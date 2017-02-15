using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class Form1 : Form
    {

        Music m = new Music();
        public Form1()
        {
            InitializeComponent();
        }

        // OPEN/BROWSE button
        private void button1_Click(object sender, EventArgs e)
        {

            /*openFileDialog1.Filter = "(mp3,wav,mp4,mov,wmv,mpg)|*.mp3;*.wav;*.mp4;*.mov;*.wmv;*.mpg|all files|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                txtbxFilepath.Text = openFileDialog1.FileName;*/

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                m.open(openFileDialog1.FileName);
                txtbxFilepath.Text = openFileDialog1.FileName;
            }
        }

        // PAUSE button
        private void button3_Click(object sender, EventArgs e)
        {
            m.pause();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            m.play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            m.stop();
            txtbxFilepath.Text = "";
        }
    }
}
