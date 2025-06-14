using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartCTaskA
{
    class IntQueue
    {
        public readonly int maxsize = 10;
        private int head = 0;
        private int tail = 0;
        private int top = 0;
        private int numItems = 0;
        private string[] store;

        public IntQueue()
        {
            store = new string[maxsize];
        }

        public IntQueue(int size)
        {
            maxsize = size;
            store = new string[maxsize];
        }

        public void Enqueue(string value)
        {
            if(IsFull())
            {
                return;
            }
            numItems++;
            store[tail] = value;
            if (++tail == maxsize)
            {
                tail = 0;
            }
        }

        public string Dequeue()
        {
            if(IsEmpty())
            {
                return null;
            }
            string headItem;
            numItems--;
            headItem = store[head];
            if (++head == maxsize)
            {
                head = 0;
            }
            return headItem;
        }

        public string Peek()//return top of stack without removing
        {
            if (!IsEmpty())
            {
                return store[top];
            }
            return null;
        }

        public bool IsEmpty()
        {
            return numItems == 0;
        }

        public bool IsFull()
        {
            return numItems == maxsize;
        }

        public string Print()
        {
            StringBuilder output = new StringBuilder();
            for (int i = top - 1; i >= 0; i--)
                output.Append(store[i] + Environment.NewLine);
            return output.ToString();
        }

        public string Display()
        {
            IntQueue newqueue = new IntQueue();
            string results = "";
            while (this.IsEmpty() == false)
            {
                string x = this.Dequeue();
                results += x + " , ";
                newqueue.Enqueue(x);
            }
            while (!newqueue.IsEmpty())
            {
                string x = newqueue.Dequeue();
                this.Enqueue(x);
            }
            return results;
        }

        public int Count()
        {
            return numItems;
        }
    } //class
}
