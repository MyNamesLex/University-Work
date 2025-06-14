using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListGen
{
    class LinkListGen<T> where T : IComparable
    {
        private LinkGen<T> list;

        public LinkListGen()
        {
            list = null;
        }
        public void AddItem(T item)
        {
            list = new LinkGen<T> (item, list); // create a new link on the front of the list
        }
        public string DisplayList()
        {
            LinkGen<T> temp = list;
            string buffer = "";
            while (temp != null) // move one link and add data to the buffer
            {
                buffer += temp.Data + ",";
                temp = temp.Next;
            }
            return buffer;
        }

        public int NumberOfItems()
        {
            LinkGen<T> temp = list;
            int count = 0;
            while (temp != null) // move one link and add 1 to count
            {
                temp = temp.Next;
                count = count + 1;
            }
            return count;
        }
        
        
        public bool IsPresentItem(T item)
        {
            LinkGen<T> temp = list;
            bool present = false;
            while (temp != null) // sets bool present false if it is not null, move a link and set present to false
            {
                if (item.Equals(temp.Data))
                {
                    present = true;
                    return present;
                }
                temp = temp.Next;
            }
            return present;
        }
        
        public void AppendItem(T item)
        {
            LinkGen<T> temp = list;

            if (temp == null)
            {
                list = new LinkGen<T>(item);
            }
            else
            {
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = new LinkGen<T>(item);
            }
        }
        public void RemoveItem(T item)
        {
            LinkGen<T> temp = list;
            if (item.Equals(temp.Data))
            {
                list = list.Next;
                return;
            }

            LinkGen<T> linkprevious = list;
            temp = temp.Next;

            while (temp != null)
            {
                linkprevious = temp;
                temp = temp.Next;
                if (temp == null || temp.Data.CompareTo(item) == 0)
                {
                    break;
                }
            }

            if (temp == null)
            {
                return;
            }
            linkprevious.Next = temp.Next;
        }

        public void InsertInOrder(T item)
        {
            LinkGen<T> temp = list;
            LinkGen<T> prev = list;

            if (list == null)
            {
                this.AddItem(item);
                return;
            }

            if (item.Equals(temp.Data))
            {
                LinkGen<T> before = new LinkGen<T>(item);
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

            LinkGen<T> newcell = new LinkGen<T>(item);
            newcell.Next = temp;
            prev.Next = newcell;
        }

        public void Sort()
        {
            LinkGen<T> temp = list;
            LinkListGen<T> sortedlist = new LinkListGen<T>();

            while (temp != null)
            {
                sortedlist.InsertInOrder(temp.Data);
                temp = temp.Next;
            }
            list = sortedlist.list;
        }

        public void Concat(LinkListGen<T> list2)
        {
            // Pre: True
            //Post: list becomes concatenation of list and list2 e.g. [2,3,4], [6,7,8] = [2,3,4,6,7,8]
            //Hint – easy to write in terms using AppendItem
        }

        public void Copy(LinkListGen<T> list2)
        {
            // Pre: True
            //Post: list contains the same items as in list2
            //Hint – easy to write in terms of Concat, think about what Concat does
        }
    }
}
