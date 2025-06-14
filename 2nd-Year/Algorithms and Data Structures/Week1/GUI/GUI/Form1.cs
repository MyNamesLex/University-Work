using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (RedCheckBox.Checked == true)
            {
                messageTextBox.ForeColor = Color.Red;
                messageTextBox.Text = "Hi";
            }
            else
            {
                messageTextBox.ForeColor = Color.Black;
                messageTextBox.Text = "Hi";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void messageTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ColourCheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
