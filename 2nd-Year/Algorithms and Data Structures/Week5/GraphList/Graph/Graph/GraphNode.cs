using System;
using System.Collections.Generic;
using System.Text;

namespace Graph
{
    public class GraphNode<T>
    {
        private T id; //data stored in the Node

        private LinkedList<T> adjList;

        public GraphNode(T id)
        {
            this.id = id;
            adjList = new LinkedList<T>();
        }

        public T ID
        {
            set { id = value; }
            get { return id; }
        }

        public void AddEdge(GraphNode<T> to)
        {
            adjList.AddLast(to.ID);
        }

        public LinkedList<T> GetAdjList()
        {
            return adjList;
        }


    }
}