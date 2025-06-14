using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task_B
{
    class Node<T> where T : IComparable
    {
        private T data;
        public Node<T> Left, Right;
        private int balanceFactor;
        public Node(T item)
        {
            data = item;
            Left = null;
            Right = null;
        }
        public T Data
        {
            set { data = value; }
            get { return data; }
        }
        public int BalanceFactor
        {
            set { balanceFactor = value; }
            get { return balanceFactor; }
        }
    }
}
