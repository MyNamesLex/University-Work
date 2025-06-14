using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class Graph<T> where T : IComparable
    {
        private LinkedList<GraphNode<T>> nodes;

        public Graph()
        {
            nodes = new LinkedList<GraphNode<T>>();
        }

        public bool IsEmptyGraph()
        {
            return nodes.Count==0;
        }

        public void AddNode(T id)
        {
            nodes.AddLast(new GraphNode<T>(id));
        }

        public bool ContainsGraph(GraphNode<T> node)
        {
            foreach(GraphNode<T> n in nodes)
            {
                if(n.ID.CompareTo(node.ID)==0)
                {
                    return true;
                }
            }
            return false;
        }

        public GraphNode<T> GetNodeByID(T id)
        {
            foreach(GraphNode<T> n in nodes)
            {
                if (id.CompareTo(n.ID) == 0) return n;
            }

            return null;
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

        public void AddEdge(T from, T to)
        {
            GraphNode<T> n1 = GetNodeByID(from);

            GraphNode<T> n2 = GetNodeByID(to);

            if (n1 != null && n2 != null)
            {
                n1.AddEdge(n2);
            }
            else
            {
                Console.WriteLine("nodes not found; no edge added");
            }
        }
    }
}
