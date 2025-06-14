using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_B
{
    class Request : IComparable
    {
        public string id;
        public string starttime;
        public string endtime;

        public Request(string id, string starttime, string endtime)
        {
            this.id = id;
            this.starttime = starttime;
            this.endtime = endtime;
        }

        public string ID
        {
            set { id = value; }
            get { return id; }
        }

        public string StartTime
        {
            set { starttime = value; }
            get { return starttime; }
        }

        public string EndTime
        {
            set { endtime = value; }
            get { return endtime; }
        }

        public int CompareTo(Object other)
        {
            Request r = (Request)other;
            return this.EndTime.CompareTo(r.EndTime);
        }

        public override string ToString()
        {
            return "| ID -  " + ID + " , " + "Start -  " + StartTime + " , " + "End - " + EndTime + " , |  \n\n";
        }
    }
}
