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
    public partial class timer : Form
    {
        private int totalSeconds;
        private bool isPaused = false;
        public timer()
        {
            InitializeComponent();
            InitComboBoxes();
        }

        private void InitComboBoxes()
        {
            for (int i = 0; i < 24; i++)
                comboBox1.Items.Add(i.ToString("D2"));
            for (int i = 0; i < 60; i++)
            {
                comboBox2.Items.Add(i.ToString("D2"));
                comboBox3.Items.Add(i.ToString("D2"));
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int hours = int.Parse(comboBox1.SelectedItem.ToString());
            int minutes = int.Parse(comboBox2.SelectedItem.ToString());
            int seconds = int.Parse(comboBox3.SelectedItem.ToString());

            totalSeconds = (hours * 3600) + (minutes * 60) + seconds;
            UpdateLabel();
            timer1.Start(); // Gunakan timer1 yang ada di Form
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
            totalSeconds = 0;
            UpdateLabel();
            button2.Text = "Pause";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (totalSeconds > 0)
            {
                totalSeconds--;
                UpdateLabel();
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("Waktu Habis!", "Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void UpdateLabel()
        {
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;
            label4.Text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }
    }
}
