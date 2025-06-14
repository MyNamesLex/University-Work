using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_B
{
    class LinkListGen<T> where T : IComparable
    {
        private LinkGen<T> list; 

        public LinkListGen()
        {
            list = null;
        }

        public LinkGen<T> List 
        {
            set { this.list = value; }
            get { return list; }
        }

        public void AddItem(T item)
        {
            list = new LinkGen<T>(item, list); 
        }
        public string DisplayList()
        {
            LinkGen<T> temp = list;
            string buffer = "";
            while (temp != null) 
            {
                buffer += temp.Data.ToString() + ",";
                temp = temp.Next;
            }
            return buffer;
        }

        public int NumberOfItems()
        {
            LinkGen<T> temp = list;
            int count = 0;
            while (temp != null) 
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
            while (temp != null) 
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
            if (item.CompareTo(temp.Data) == 0)
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
                if (temp == null || item.CompareTo(temp.Data) == 0)
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
    }
}
