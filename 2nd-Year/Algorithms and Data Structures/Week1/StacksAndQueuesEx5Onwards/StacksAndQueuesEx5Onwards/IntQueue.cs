using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueuesEx5Onwards
{
    class IntQueue
    {
        public readonly int maxsize = 10;
        private int head = 0;
        private int tail = 0;
        private int top = 0;
        private int numItems = 0;
        private int[] store;

        public IntQueue()
        {
            store = new int[maxsize];
        }

        public IntQueue(int size)
        {
            maxsize = size;
            store = new int[maxsize];
        }

        public void Push(int value)
        {
            if (!IsFull())
            {
                store[top] = value;
                top++;
            }
        }

        public void Enqueue(int value)
        {
            numItems++;
            store[tail] = value;
            if (++tail == maxsize)
            {
                tail = 0;
            }
        }

        public int Dequeue()
        {
            int headItem;
            numItems--;
            headItem = store[head];
            if (++head == maxsize)
            {
                head = 0;
            }
            return headItem;
        }

        public int Peek()//return top of stack without removing
        {
            if (!IsEmpty())
            {
                return store[top];
            }
            return 0;
        }

        public bool IsEmpty()
        {
            return numItems == 0;
        }

        public bool IsFull()
        {
            return head == tail;
        }

        public string Print()
        {
            StringBuilder output = new StringBuilder();
            for (int i = top - 1; i >= 0; i--)
                output.Append(store[i] + Environment.NewLine);
            return output.ToString();
        }

        public string Number()
        {
            IntQueue newqueue = new IntQueue();
            string results = "";
            while (this.IsEmpty() == false)
            {
                int x = this.Dequeue();
                results += x.ToString() + ",";
                newqueue.Enqueue(x);
            }
            while (!newqueue.IsEmpty())
            {
                int x = newqueue.Dequeue();
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
