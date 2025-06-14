using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueuesEx5Onwards
{
    class Program
    {
        static void Main(string[] args)
        {
            IntQueue queue = new IntQueue();
            queue.Enqueue(10);
            queue.Enqueue(10);
            queue.Enqueue(10);
            queue.Enqueue(10);
            queue.Enqueue(10);
            System.Console.WriteLine(queue.Number());
            System.Console.WriteLine(queue.Count());
            System.Console.ReadKey();
        }
    }
}