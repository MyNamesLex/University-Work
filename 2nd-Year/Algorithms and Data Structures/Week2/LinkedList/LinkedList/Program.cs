using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkList myList = new LinkList(); //empty list created

            Console.WriteLine("In Order:");
            myList.InsertInOrder(5);
            Console.WriteLine(myList.DisplayItems());
            myList.InsertInOrder(9);
            Console.WriteLine(myList.DisplayItems());
            myList.InsertInOrder(3);
            Console.WriteLine(myList.DisplayItems());
            myList.InsertInOrder(6);
            Console.WriteLine(myList.DisplayItems());
            myList.InsertInOrder(4);
            Console.WriteLine(myList.DisplayItems());

            Console.WriteLine();
            Console.WriteLine("Number Of Items:");
            Console.WriteLine(myList.NumberOfItems());

            Console.WriteLine();
            Console.WriteLine("Is Present:");
            Console.WriteLine(myList.IsPresent(6));

            Console.WriteLine();
            Console.WriteLine("Remove Item:");
            myList.RemoveItem(6);
            Console.WriteLine(myList.DisplayItems());


            Console.WriteLine();
            Console.WriteLine("Number Of Items(Removed Item):");
            Console.WriteLine(myList.NumberOfItems());

            Console.WriteLine();
            Console.WriteLine("Is Present:");
            Console.WriteLine(myList.IsPresent(6));

            Console.ReadKey();
        }
    }
}
