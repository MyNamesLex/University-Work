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
            Console.WriteLine("Sum is : {0}, power is: {1}", sum(num1, num2), power(num1,num2));
            //{0} takes 1st argument and substitutes into string
            Console.ReadKey();  //waits for a key to press before ending
        }

        static int sum(int x, int y)
        {
                return x + y;
        }
        //2,0 = 1
        //2,1 = 2
        //2,2 = 1*2*2

        //power x = 2,y = 4 = 1*2*2*2*2
        //power x = 3,y = 2 = 1*3*3
        static int power(int x, int y)
        {
            int result = 1;
            for(int i=0; i < y; i++)
            {
                result = x * result;
            }
            return result;
        }

    }
}
