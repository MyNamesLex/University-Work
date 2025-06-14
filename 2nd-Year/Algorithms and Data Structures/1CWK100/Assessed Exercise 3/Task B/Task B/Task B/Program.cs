using System;
using System.IO;

namespace Task_B
{
    class Program
    {
        static void Main(string[] args)
        {
            AVLTree<int> tree = new AVLTree<int>();
            AVLTree<int> tree2 = new AVLTree<int>();

            tree.InsertItem(5); //test left rotation
            tree.InsertItem(15);
            tree.InsertItem(25);
            tree.InsertItem(35);

            Console.WriteLine("SubTree Check True: " + tree.SubTree(tree2));

            tree2.InsertItem(5);
            tree2.InsertItem(15);
            tree2.InsertItem(25);
            Console.WriteLine();

            Console.WriteLine("SubTree Check False: " + tree.SubTree(tree2));
            Console.WriteLine();

            Console.WriteLine("Equals False: " + tree.Equals(tree2));

            Console.WriteLine();

            tree2.InsertItem(35);

            Console.WriteLine("Equals True: " + tree.Equals(tree2));

            Console.WriteLine();

            Console.WriteLine("Height of node: {0}", tree.Height());

            Console.WriteLine();

            tree.InOrder(); // display whole tree

            Console.WriteLine();
            
            tree2.InOrder();

            Console.ReadKey();
        }
    }
}
