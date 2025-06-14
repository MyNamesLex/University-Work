using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace WebinarB_stacks
{
    class Employee : Person // inherits from Person class
    {
        private string specialism;
        private float salary; //in Thousands K

        //constructor
        public Employee(string name, string specialism, float salary) : base(name)
        {
            this.specialism = specialism;
            this.salary = salary;
        }
        public string Specialism
        {
            set { this.specialism = value; }
            get { return this.specialism; }
        }

        public float Salary
        {
            set { this.salary = value; }
            get { return this.salary; }
        }
    }

}
