using System;

namespace Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numbers;
            float average;
            int total = 0;
            int count = 0;
            string input;
            Console.WriteLine("How many numbers? :");
            input = Console.ReadLine();  //waits for user to hit return
            numbers = Convert.ToInt32(input);
            while(count<numbers)
            {
                Console.WriteLine("Enter a Number :");
                input = Console.ReadLine();
                total = total + Convert.ToInt32(input); //Add to running total#
                count++;
            }
            average = (float)total / (float)numbers;
            Console.WriteLine("Average is : {0}", average);
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
            for (int i = 0; i < y; i++)
            {
                result = x * result;
            }
            return result;
        }

    }
}