using System;
using System.Collections.Generic;

namespace GraphWebinar
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> sequence = new LinkedList<int>();

            sequence.AddFirst(20);
            sequence.AddFirst(25);
            sequence.AddLast(30);

            //display

            foreach(int n in sequence)
            {
                Console.WriteLine(n);
            }

            sequence.Remove(30);

            foreach (int n in sequence)
            {
                Console.WriteLine(n);
            }

            sequence.RemoveFirst();

            sequence.RemoveLast();

            Console.WriteLine("num of elements " + sequence.Count);

            sequence.AddFirst(34);

            Console.WriteLine("first element" + sequence.First.Value);

            Console.ReadKey();
        }
    }
}
