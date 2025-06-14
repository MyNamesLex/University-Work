using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private List<Student> studentlist;
        public Form1()
        {
            InitializeComponent();
            studentlist = new List<Student>();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //create a student - constructor - name, age, id
            int newAge = Convert.ToInt32(ageTextBox.Text);
            Student newStudent = new Student(nameTextBox.Text, newAge, IDTextBox.Text);
            //add it to List?
            studentlist.Add(newStudent);
            //increment count - display it
            CountLabel.Text = "Count = " + studentlist.Count();

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            //Search for the student to remove
            // get ID for student to delete - textbox
            Student removeStu = new Student("", 0, IDTextBox.Text);  // create a new object for comparison
            foreach (Student current in studentlist) // go through each student
            {
                if (current.CompareTo(removeStu) == 0) //found student to be removed
                {
                    removeStu = current;
                    break;
                }
            }
            studentlist.Remove(removeStu);
            CountLabel.Text = "Count = " + studentlist.Count();
        }
    }
}
