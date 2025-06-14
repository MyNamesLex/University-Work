using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2;
            int r = 1;
            int dummy = 0;


            Console.WriteLine("Creating a nested loop");

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Inside the first loop");

                dummy++;

                for (int j = 0; j < n; j++)
                {

                    r = r + dummy;
                        Console.WriteLine("Inside the second loop " + r);


                }

            }

        }
    }
}
