using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursion
{
    class Program
    {
		static void Main(string[] args)
		{
			int result = power(2, 3);
			Console.WriteLine("Power : " + result);

			int multi = multiply(2, 6);
			Console.WriteLine("Multiply : " + multi);

			Console.WriteLine();

			range(8, 5);
			Console.ReadLine();

			printNumbers(5);

			Console.ReadLine();
		}

		static void printNumbers(int n)
		{
			if (n > 0)
			{
				Console.WriteLine(" n = {0} ", n);
				printNumbers(n - 1);
			}
			Console.WriteLine("\n Recursion Unfolding  --- n = {0} ", n);
		}
		static void range(int start, int stop)
		/* Displays numbers between start and stop - start <= stop */
		{
			if (start == stop)
			{
				//stopping condition - display the last value - stop
				Console.WriteLine("Hit stop condition, stop : {0}", stop);
			}
			else if (start > stop) //wrong order - swap start and stop
			{
				range(stop, start); //swap start, stop in child copy of code
			}
			else
			{
				// recursive call and print start - assume 1 step away from stopping condition
				//1.1 name the nethod, 
				//1.2 - parameters - which one changes? - closing stopping condition
				//does it return anything?
				Console.WriteLine("start : {0}", start);
				range(start + 1, stop);
			}
		}
		static int power(int x, int y) // x the to power of y
		{
			//simplest example x power 0 = 1 //stopping condition
			if (y == 0)
				return 1; // stopping condition
						  //X power 2 = x * x * 1
						  //x power (y=3) = x * x * x * 1
			return power(x, y - 1) * x;
		}

		static int multiply(int x, int y) //return x * yy using addition only
		{
			if (y == 1)
				return x; //stopping condition
			return multiply(x, y - 1) + x;
		}
	}
}