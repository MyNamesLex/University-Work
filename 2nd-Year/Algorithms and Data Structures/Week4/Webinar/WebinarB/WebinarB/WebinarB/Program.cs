using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace WebinarB
{
    class Program
    {
        static void swap(ref int x, ref int y)
        {
            int temp = x;
            x = y;
            y = temp;
        }

        static void swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
        static void quicksortDD2(int[] items, int left, int right)
        {

            //partioning lefft and right

            int i, j;

            i = left; j = right;

            int pivot = items[left];

            // will do partitioning

            while (i <= j)
            {
                // i movement from left to right 

                for (; (items[i] < pivot) && (i < right); i++) ;

                // j movement from right to left

                for (; (pivot < items[j]) && (j > left); j--) ;

                if (i <= j)
                    swap(ref items[i++], ref items[j--]);

                //call recursively on left and right partition
            }
            //recursive on the left and right partitions
            if (left < j)
                quicksortDD2(items, left, j);

            if (i < right)
                quicksortDD2(items, i, right);
        }

        static void quickSortDD2(Exercise[] items, int left, int right)
        {

            //partioning lefft and right

            int i, j;

            i = left; j = right;

            Exercise pivot = items[left];

            // will do partitioning

            while (i <= j)
            {
                // i movement from left to right 

                for (; (items[i].CompareTo(pivot) < 0) && (i < right); i++) ;

                // j movement from right to left

                for (; (pivot.CompareTo(items[j]) < 0) && (j > left); j--) ;

                if (i <= j)
                    swap(ref items[i++], ref items[j--]);

                //call recursively on left and right partition
            }
            //recursive on the left and right partitions
            if (left < j)
                quickSortDD2(items, left, j);

            if (i < right)
                quickSortDD2(items, i, right);
        }

        static void minexercise(Exercise[] arrayex, int n)
        {
            int sum = 0;

            quickSortDD2(arrayex, 0, arrayex.Length - 1);

            while(sum != n)
            {
                // 50 25 10 5 1
                Exercise x;
                int i = -1;

                do
                {
                    i++;
                    x = arrayex[i];
                }
                while (x.Credits + sum > n);

                sum = sum + x.Credits;

                Console.WriteLine("Exercise" + x.Name + "credits" + x.Credits);
            }
        }

        static void Main(string[] args)
        {

            int Min = 0; int Max = 200;

            int[] test2 = new int[10];

            Random randNum = new Random();

            for (int i = 0; i<test2.Length;i++ )
            {
                test2[i] = randNum.Next(Min, Max);
            }

            Console.WriteLine("Quicksort - before sorting");

            for(int i = 0; i < test2.Length; i++)
            {
                Console.WriteLine(test2[i]);
            }

            //call quicksort
            quicksortDD2(test2, 0, test2.Length - 1);

            Console.WriteLine("Quicksort - after sorting");

            for (int i = 0; i < test2.Length; i++)
            {
                Console.WriteLine(test2[i]);
            }

            Console.WriteLine("How many type of exercise ?");

            int numex = Convert.ToInt32(Console.ReadLine());

            Exercise[] arrayex = new Exercise[numex];

            for(int i = 0; i !=(arrayex.Length); i++)
            {
                Exercise e = new Exercise();

                Console.WriteLine("Exercise Name");
                e.Name = Console.ReadLine();

                Console.WriteLine("Exercise Credits");
                e.Credits = Convert.ToInt32(Console.ReadLine());

                arrayex[i] = e;


            }

            for(int i = 0; i != (arrayex.Length); i++)
            {
                Console.WriteLine("Exercise Name" + arrayex[i].Name + "credits " + arrayex[i].Credits);
            }

            quickSortDD2(arrayex, 0, arrayex.Length - 1);

            for (int i = 0; i != (arrayex.Length); i++)
            {
                Console.WriteLine("Exercise Name" + arrayex[i].Name + "credits " + arrayex[i].Credits);
            }

            Console.WriteLine("Total Number Of Credits ?");
            int totcredits = Convert.ToInt32(Console.ReadLine());

            minexercise(arrayex, totcredits);

            Console.ReadKey();
        }
    }
}
