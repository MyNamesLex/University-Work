using System;
using System.Collections.Generic;
using System.Text;

namespace WebinarB
{
    class Exercise
    {
        private int credits;
        private string name;

        public int Credits
        {
            get { return credits; }
            set { credits = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int CompareTo(Object other)
        {
            Exercise b = (Exercise)other;
            return this.Credits.CompareTo(b.Credits);
        }
    }
}
