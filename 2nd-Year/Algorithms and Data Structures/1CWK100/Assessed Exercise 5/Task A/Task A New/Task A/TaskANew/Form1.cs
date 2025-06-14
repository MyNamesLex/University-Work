using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskANew
{
    public partial class Form1 : Form
    {
        private Graph<char> graphgraph = new Graph<char>();
        public Form1()
        {
            InitializeComponent();
        }
        private void InsertNodeButton_Click(object sender, EventArgs e)
        {
            
        }

        private void DirectEdgeTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void CountTextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void DirectEdgeButton_Click(object sender, EventArgs e)
        {
            graphgraph.AddEdge(Char.Parse(DirectEdgeTextBox.Text), Char.Parse(DirectEdgeNumberTwoTextBox.Text));
        }

        private void CountButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(graphgraph.NumNodesGraph().ToString(), "Nodes");
            MessageBox.Show(graphgraph.NumEdgesGraph().ToString(), "Edges");
        }

        private void InsertNodeButton_Click_1(object sender, EventArgs e)
        {
            graphgraph.AddNode(Char.Parse(InsertNodeTextBox.Text));
        }
    }
}
