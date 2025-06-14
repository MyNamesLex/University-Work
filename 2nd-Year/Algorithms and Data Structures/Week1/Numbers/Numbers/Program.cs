using System;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            string input;
            Console.WriteLine("Enter 1st Number :");
            input = Console.ReadLine();  //waits for user to hit return
            num1 = Convert.ToInt32(input);
            Console.WriteLine("Enter 2nd Number :");
            input = Console.ReadLine();
            num2 = Convert.ToInt32(input);
            Console.WriteLine("Sum is : {0}", sum(num1, num2));
            //{0} takes 1st argument and substitutes into string
            Console.ReadKey();  //waits for a key to press before ending
        }

        static int sum(int x, int y)
        {
            return x + y;
        }

    }
}
