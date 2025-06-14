using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGen
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkGen<int> link1 = new LinkGen<int>(5);
            LinkListGen<int> myList = new LinkListGen<int>();

            myList.InsertInOrder(8);
            myList.InsertInOrder(6);
            myList.InsertInOrder(44);
            myList.InsertInOrder(23);
            myList.InsertInOrder(82);
            myList.InsertInOrder(2);

            myList.AppendItem(10); //Appended
            Console.WriteLine("(10 = Appended)");
            Console.WriteLine();

            Console.WriteLine("Display List");
            Console.WriteLine(myList.DisplayList());
            Console.WriteLine();

            Console.WriteLine("Number Of Items");
            Console.WriteLine(myList.NumberOfItems());
            Console.WriteLine();

            Console.WriteLine("Is Present");
            Console.WriteLine(myList.IsPresentItem(8));
            Console.WriteLine();

            myList.RemoveItem(8);
            myList.Sort();

            Console.WriteLine("Display List (Removed)");
            Console.WriteLine(myList.DisplayList());
            Console.WriteLine();

            Console.WriteLine("Number Of Items (Removed)");
            Console.WriteLine(myList.NumberOfItems());
            Console.WriteLine();

            Console.WriteLine("Is Present (Removed)");
            Console.WriteLine(myList.IsPresentItem(8));
            Console.ReadKey();

            Console.WriteLine(myList.IsPresentItem(8));
        }
    }
}
