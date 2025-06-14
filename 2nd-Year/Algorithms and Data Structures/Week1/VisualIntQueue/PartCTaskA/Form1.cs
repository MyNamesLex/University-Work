using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PartCTaskA
{
    public partial class Form1 : Form
    {
        IntQueue queue = new IntQueue();
        public Form1()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string name = NameTextBox.Text;
            queue.Enqueue(name);
            QueueCountLabel.Text = "Count: " + queue.Count().ToString();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            queue.Dequeue();
            QueueCountLabel.Text = "Count: " + queue.Count().ToString();
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            string name = queue.Display();
            MessageBox.Show(name,"Names");
        }
    }
}
