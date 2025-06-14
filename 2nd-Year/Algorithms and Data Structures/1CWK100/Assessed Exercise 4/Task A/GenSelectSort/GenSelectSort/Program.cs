

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSelectSort
{
    class Program
    {

        static void swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        // Implement here the generic Selection Sort (SelecSortGen)
        static void MySelectedSort(Book[] a)  //Generic
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int smallest = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j].CompareTo(a[smallest]) < 0)
                    {
                        smallest = j;
                    }
                }
                swap(ref a[i], ref a[smallest]);
            }
        }

        static void MySelectedSort(int[] a) //Int
        {
            for (int i = 0; i < a.Length - 1; i++) 
            {
                int smallest = i; 
                for (int j = i + 1; j < a.Length; j++) 
                {
                    if (a[j] < a[smallest]) 
                    {
                        smallest = j; 
                    }
                }
                swap(ref a[i], ref a[smallest]); 
            }
        }

        static void MySelectedSort(string[] a) //String
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int smallest = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[j].CompareTo(a[smallest]) < 0)
                    {
                        smallest = j;
                    }
                }
                swap(ref a[i], ref a[smallest]);
            }
        }

        // use the main to test that SelecSortGen works
        static void Main(string[] args)
        {
            // Code to construct an array of Book

            string[] titles = {"Writing Solid Code",
                "Objects First","Programming Gems",
                "Head First Java","The C Programming Language",
                "Mythical Man Month","The Art of Programming",
                "Coding Complete","Design Patterns",
                "ZZ"};
            string[] authors = { "Maguire", "Kolling", "Bentley", "Sierra", "Richie", "Brooks", "Knuth", "McConnal", "Gamma", "Weiss" };
            string[] isbns = { "948343", "849328493", "38948932", "394834342", "983492389", "84928334", "4839455", "21331322", "348923948", "43893284",
                "9483294", "9823943" };

            Book[] library = new Book[10];


            // fill an array of books
            for (int i = 0; i < library.Length; i++)
            {
                library[i] = new Book(isbns[i], titles[i], authors[i]);

            }



            // call SelectSortGen to sort the array library (choose to sort the books by using either title, author or isbn)
            //display sorted array so you can check that the sorting method works also for an array of Book
            Console.WriteLine("Generic Book Sort (Before Sort): ");
            Console.WriteLine();
            foreach (Book book in library)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();

            MySelectedSort(library);
            Console.WriteLine("Generic Book Sort (After Sort): ");
            Console.WriteLine();
            foreach (Book book in library)
            {
                Console.WriteLine(book);
            }




            // create an array of int
            // call SelectSortGen to sort the array of int
            ////display sorted array so you can check that the sorting method works also for an array of int
            ///

            int[] test2 = new int[10];
            Random ranNum = new Random();

            int Min = 0;
            int Max = 200;

            for (int i = 0; i < test2.Length; i++)
            {
                test2[i] = ranNum.Next(Min, Max);
            }

            Console.WriteLine();
            Console.WriteLine("Selection Int Sort - before sorting");
            for (int i = 0; i < test2.Length; i++)
            {
                Console.WriteLine(test2[i]);
            }

            MySelectedSort(test2);
            Console.WriteLine();
            Console.WriteLine("Selection Int Sort - after sorting");

            for (int i = 0; i < test2.Length; i++)
            {
                Console.WriteLine(test2[i]);
            }

            // create an array of string
            // call SelectSortGen to sort the array of string 
            ////display sorted array so you can check that the sorting method works also for an array of string

            string[] test3 = new string[10];

            string[] a = {"Writing Solid Code",
                "Objects First","Programming Gems",
                "Head First Java","The C Programming Language",
                "Mythical Man Month","The Art of Programming",
                "Coding Complete","Design Patterns",
                "ZZ"};

            for (int i = 0; i < test3.Length; i++)
            {
                test3[i] = a[i];
            }

            Console.WriteLine();
            Console.WriteLine("Selection String Sort - before sorting");
            for (int i = 0; i < test3.Length; i++)
            {
                Console.WriteLine(test3[i]);
            }

            MySelectedSort(test3);
            Console.WriteLine();
            Console.WriteLine("Selection String Sort - after sorting");

            for (int i = 0; i < test3.Length; i++)
            {
                Console.WriteLine(test3[i]);
            }
            Console.ReadKey();
        }
    }
}
