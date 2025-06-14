using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebinarB_stacks
{
    public partial class Form1 : Form
    {
        private JobStack jobs = new JobStack(); //empty stack
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add job to the Stack
            //get contents of text boxes to populate?
            float salary = (float)Convert.ToDecimal(SalaryTextBox.Text);
            Employee newWorker = new Employee(NameTextBox.Text, SpecialTextBox.Text, salary);

            //new Job Object
            Job newJob = new Job(JobIDTextBox.Text, DescTextBox.Text, newWorker);
            jobs.Push(newJob);
        }

        private void NextJobButton_Click(object sender, EventArgs e)
        {
            Job nextJob = jobs.Peek();
            //use properties for Job to populate textBoxes
            NameTextBox.Text = nextJob.Worker.Name;
            JobIDTextBox.Text = nextJob.ID;
        }
    }
}
