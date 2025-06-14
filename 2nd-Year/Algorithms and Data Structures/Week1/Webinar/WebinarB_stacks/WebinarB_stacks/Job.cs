using System;
using System.Collections.Generic;
using System.Text;

namespace WebinarB_stacks
{
    class Job : IComparable
    {
        private string id, description;
        private Employee worker;

        // constructor
        public Job(string id, string desc, Employee worker)
        {
            this.id = id;
            this.description = desc;
            this.worker = worker;
        }

        //properties
        public Employee Worker
        {
            get { return worker; }
            set { worker = value; }

        }

        public string ID
        {
            get { return id; }
            set { id = value; }

        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }

        }

        public int CompareTo(Object obj) //implementation of CompareTo
        {					// 		for IComparable

            Job other = (Job)obj;
            return id.CompareTo(other.id);
        }
    }

}
