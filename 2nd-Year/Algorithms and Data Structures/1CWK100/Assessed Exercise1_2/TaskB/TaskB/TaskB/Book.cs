using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TaskB
{
    class Book : IComparable
    {
        private string isbn;
        private string name;
        private string author;

        public Book(string author, string name, string isbn)
        {
            this.name = name;
            this.author = author;
            this.isbn = isbn;
        }
        
        public string Author
        {
            set { author = value; }
            get { return author; }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string ISBN
        {
            set { isbn = value; }
            get { return isbn; }
        }

        public int CompareTo(Object obj)
        {
            Book other = (Book)obj;
            return ISBN.CompareTo(other.ISBN);
        }

        public override string ToString()
        {
            return Name + ", " + Author + ", " + ISBN + "\n\n" ;
        }

    }
}
