using System;
using System.Collections.Generic;
using System.Text;

namespace WebinarB_stacks
{
    class JobStack
    {
        private const int maxsize = 10; //size of array
        private int top = 0;
        private Job[] array = new Job[maxsize]; //creating empty array of type Job

        public void Push(Job value)
        {
            if(!IsFull())
            {
                array[top] = value;
                top++;
            }
        }

        public Job Pop()
        {
            if (!IsEmpty())
            { 
                return array[--top];
            }
            return null;
        }

        public Job Peek()//return top of stack without removing
        {
            if(!IsEmpty())
            {
                return array[top];
            }
            return null;
        }

        public bool IsEmpty()
        {
            return top == 0;
        }

        public bool IsFull()
        {
            return top == maxsize;
        }

        public string Print()
        {
            StringBuilder output = new StringBuilder();
            for (int i = top - 1; i >= 0; i--)
                output.Append(array[i] + Environment.NewLine);
            return output.ToString();
        }

    }

}
