using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace watch.GUI
{
    public partial class stopwatch : Form
    {
        private int elapsedTime = 0;
        private bool isPaused = false;
        public stopwatch()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            elapsedTime++;
            UpdateLabel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
            {
                timer1.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
                isPaused = true;
                button2.Text = "Resume";
            }
            else
            {
                timer1.Start();
                isPaused = false;
                button2.Text = "Pause";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            elapsedTime = 0;
            UpdateLabel();
            isPaused = false;
            button2.Text = "PAUSE";
        }
        private void UpdateLabel()
        {
            int hours = elapsedTime / 3600;
            int minutes = (elapsedTime % 3600) / 60;
            int seconds = elapsedTime % 60;
            label1.Text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }
    }
}
