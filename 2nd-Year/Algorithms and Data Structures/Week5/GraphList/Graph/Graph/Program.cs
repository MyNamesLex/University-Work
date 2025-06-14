using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<char> myGraph = new Graph<char>();

            myGraph.AddNode('A');
            myGraph.AddNode('B');
            myGraph.AddNode('C');
            myGraph.AddNode('D');
            myGraph.AddNode('E');

            myGraph.AddEdge('A', 'B');
            myGraph.AddEdge('A', 'C');
            myGraph.AddEdge('B', 'C');
            myGraph.AddEdge('D', 'A');
            myGraph.AddEdge('D', 'E');
            myGraph.AddEdge('A', 'E');

            Console.WriteLine("is graph empty ? " + myGraph.IsEmptyGraph());

            Console.WriteLine("is node {0} adjacent to node {1} + Answer :{2} ",
            myGraph.GetNodeByID('C').ID,
            myGraph.GetNodeByID('B').ID,
            myGraph.IsAdjacent(myGraph.GetNodeByID('B'),
                myGraph.GetNodeByID('C')));
            Console.ReadKey();
        }
    }
}
