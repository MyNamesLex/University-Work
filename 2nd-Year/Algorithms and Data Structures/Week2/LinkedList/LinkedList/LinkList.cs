using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class LinkList
    {
        private Link list = null; //default value – empty list

        public void AddItem(int item) //add item to front of list
        {
            list = new Link(item, list);
        }

        public string DisplayItems() //write items to string and return
        {
            Link temp = list;
            string buffer = "";
            while (temp != null) // move one link and add data to the buffer
            {
                buffer += temp.Data + ","; 
                temp = temp.Next; 
            }
            return buffer;
        }

        public int NumberOfItems() // returns number of items in list
        {
            Link temp = list;
            int count = 0;
            while (temp != null) // move one link and add 1 to count
            {
                temp = temp.Next;
                count = count + 1;
            }
            return count;
        }
        public bool IsPresent(int item) //checks if a value is in the list
        {
            Link temp = list;
            bool present = false;
            while (temp != null) // sets bool present false if it is not null, move a link and set present to false
            {
                if(temp.Data == item)
                {
                    present = true;
                    return present;
                }
                temp = temp.Next;
            }
            return present; 
        }

        public void AppendItem(int item) //add item to the Next part of the cell
        {
            Link temp = list;

            if (temp == null)
                list = new Link(item);
            else
            {
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = new Link(item);
            }
        }


            public void RemoveItem(int item) //remove a specific item from the list
        {
            Link temp = list;
            if(temp.Data.CompareTo(item) == 0)
            {
                list = list.Next;
                return;
            }

            Link linkprevious = list;
            temp = temp.Next;

            while(temp != null)
            {
                linkprevious = temp;
                temp = temp.Next;
                if (temp == null || temp.Data.CompareTo(item) == 0)
                {
                    break;
                }
            }

            if(temp == null)
            {
                return;
            }

            linkprevious.Next = temp.Next;
        }

        public void InsertInOrder(int item) // Add list too sorted list, use CompareTo function to organise it
        {
            Link temp = list;
            Link prev = list;

            if(list == null)
            {
                this.AddItem(item);
                return;
            }

            if(temp.Data.CompareTo(item) >= 0)
            {
                Link before = new Link(item);
                before.Next = list;
                list = before;
                return;
            }
            temp = temp.Next;
            while (temp != null)
            {
                if (temp.Data.CompareTo(item) <= 0)
                {
                    prev = temp;
                    temp = temp.Next;
                }
                else
                {
                    break;
                }
            }

            Link newcell = new Link(item);
            newcell.Next = temp;
            prev.Next = newcell;
        }

    }
}
