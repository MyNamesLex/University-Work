using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            BSTree<int> myTree = new BSTree<int>();

            myTree.InsertItem(50);
            myTree.InsertItem(20);
            myTree.InsertItem(30);
            myTree.InsertItem(60);
            myTree.InsertItem(70);

            Console.WriteLine("InOrder");
            myTree.InOrder();

            Console.WriteLine();

            Console.WriteLine("Height");
            Console.WriteLine(myTree.Height());

            Console.WriteLine();

            Console.WriteLine("PreOrder");
            myTree.PreOrder();

            Console.Read();
        }
    }
}
