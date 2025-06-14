using System;
using System.IO;

namespace Task_A
{
    class Program
    {
        static void Main(string[] args)
        {
            BSTree<string> tree = new BSTree<string>();

            readFile("textFile.txt", tree);
            tree.InOrder();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Height = {0}", tree.Height()); 

            Console.WriteLine();

            Console.WriteLine("Words = {0}", tree.Count());

            Console.WriteLine();
        }
        public static void readFile(string fileName, BSTree<string> tree)
        {
            const int MAX_FILE_LINES = 50000;
            string[] AllLines = new string[MAX_FILE_LINES];

            //reads from bin/DEBUG subdirectory of project directory
            AllLines = File.ReadAllLines(fileName);

            foreach (string line in AllLines) //visits each line of text one at a time
            {
                //split words using space , . ?
                string[] words = line.Split(' ', ',', '.', '?', ';', ':', '!');
                foreach (string word in words)
                    if (word != "")
                        tree.InsertItem(word.ToLower());
            }
        }
    }
}
