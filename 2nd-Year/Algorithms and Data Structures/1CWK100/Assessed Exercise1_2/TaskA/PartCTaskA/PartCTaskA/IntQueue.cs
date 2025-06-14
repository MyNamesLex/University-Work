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
            store = new string[maxsize]; // initialise an empty array with the capacity of maxsize
        }

        public IntQueue(int size)
        {
            maxsize = size; //allows for the user to change the maxsize if the user wishes by the value of 'size'
            store = new string[maxsize]; //initialises the empty array with the new maxsize
        }

        public void Enqueue(string value)
        {
            if(IsFull()) //checks if it is full, if it is full it will return and not have done anything
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
            if(IsEmpty()) //checks if it is empty, if it is empty it will return and not have done anything
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

        public string Peek()
        {
            if (!IsEmpty())
            {
                return store[head];
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

        public string Display()
        {
            string results = "";
            IntQueue newqueue = new IntQueue(this.maxsize); // gives the newqueue a maxsize so it can hold more if the user changes the maxsize
            while (this.IsEmpty() == false)
            {
                string x = this.Dequeue();
                results += x + " ";
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

    } 
}
