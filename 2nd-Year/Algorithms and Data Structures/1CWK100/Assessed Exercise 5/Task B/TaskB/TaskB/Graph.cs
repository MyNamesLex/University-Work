using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TaskB

{
    public class Graph<T> where T : IComparable
    {
        private LinkedList<GraphNode<T>> nodes;
        private int countNode;
        private int countEdge;

        public Graph()
        {
            nodes = new LinkedList<GraphNode<T>>();
        }

        public bool IsEmptyGraph()
        {
            return nodes.Count==0;
        }

        public int NumNodesGraph()
        {
            return countNode;
        }

        public int NumEdgesGraph()
        {
            return countEdge;
        }

        public bool ContainsGraph(GraphNode<T> node)
        {
            if (node==null)
            {
                return false;
            }
            foreach(GraphNode<T> n in nodes)
            {
                if(n.ID.CompareTo(node.ID)==0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsAdjacent(GraphNode<T> from, GraphNode<T> to)
        {
            foreach(GraphNode<T> n in nodes)
            {
                if (n.ID.CompareTo(from.ID)==0)
                {
                    bool b = from.GetAdjList().Contains(to.ID);
                    if (b == true) return true;
                }
            }
            return false;
        }

        public void AddNode(T id)
        {
            if(ContainsGraph(GetNodeByID(id)))
            {
                return;
            }
            countNode++;
            nodes.AddLast(new GraphNode<T>(id));
        }
        public GraphNode<T> GetNodeByID(T id)
        {
            foreach (GraphNode<T> n in nodes)
            {
                if (id.CompareTo(n.ID) == 0) return n;
            }

            return null;
        }

        public void AddEdge(T from, T to)
        {
            GraphNode<T> n1 = GetNodeByID(from);

            GraphNode<T> n2 = GetNodeByID(to);
            if (IsAdjacent(GetNodeByID(from), GetNodeByID(to)))
            {
                return;
            }
            if (n1 != null && n2 != null)
            {
                countEdge++;
                n1.AddEdge(n2);
            }
            else
            {
                Console.WriteLine("nodes not found; no edge added");
            }
        }
    }
}
