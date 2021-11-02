using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void klopButton_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"C:\Sveta\NIK\myGame\a.jpg";

        }

        private void kachinButton_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"C:\Sveta\NIK\myGame\k.jpg";

        }

        private void startImageButton_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"C:\Sveta\NIK\myGame\a.jpg";
        }
    }
}
