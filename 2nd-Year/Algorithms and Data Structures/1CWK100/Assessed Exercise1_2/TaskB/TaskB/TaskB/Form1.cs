using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskB
{
    public partial class Form1 : Form
    {
        LinkListGen<Book> listlist = new LinkListGen<Book>();
        public Form1()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Book book = new Book(AuthorTextBox.Text, NameTextBox.Text, ISBNTextBox.Text);
            listlist.InsertInOrder(book);
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(listlist.DisplayList());
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Book book = new Book(AuthorTextBox.Text, NameTextBox.Text, ISBNTextBox.Text);
            listlist.RemoveItem(book);
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            listlist.Sort();
        }
    }
}
