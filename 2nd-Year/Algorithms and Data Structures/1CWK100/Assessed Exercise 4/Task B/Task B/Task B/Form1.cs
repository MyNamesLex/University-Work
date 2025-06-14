using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_B
{
    public partial class Form1 : Form
    {
        static LinkListGen<Request> listlist = new LinkListGen<Request>();

        public Form1()
        {
            InitializeComponent();
        }

        private static void Available()
        {
            LinkGen<Request> temp = listlist.List; 
            string buffer = ""; 
            string endtime = temp.Data.EndTime; 

            for(; temp != null; temp=temp.Next) 
            {
                if(temp.Data.StartTime.CompareTo(endtime) >= 0) 
                {
                    buffer += temp.Data.ToString(); 
                    endtime = temp.Data.EndTime;
                }
            }
            MessageBox.Show(buffer, "Timetable"); 
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            Request req = new Request(IDTextBox.Text, StartTimeTextBox.Text, EndTimeTextBox.Text);
            listlist.InsertInOrder(req);
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            listlist.Sort();
            Available();
        }
    }
}
