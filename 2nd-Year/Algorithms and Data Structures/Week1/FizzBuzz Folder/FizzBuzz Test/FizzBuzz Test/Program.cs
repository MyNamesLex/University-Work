using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz_Test
{
    class Program
    {
        public static void Main()
        {
            for(int i = 0; i <= 100; i++)
            {
                bool fizz = i % 3 == 0;
                bool buzz = i % 5 == 0;
                if (fizz && buzz)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (fizz)
                {
                    Console.WriteLine("Fizz");
                }
                else if (buzz)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
