using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_476_Client
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F1 = new Form1();
            F1.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            label1.Text = radioButton1.Text.ToString();
            label2.Text = "";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = radioButton2.Text.ToString();
            label2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label1.Text == "No game selected")
            {
                label2.Text = "Please select a game";
                return;
            }
            else
            {
                MessageBox.Show(label1.Text);
            }
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }
    }
}
