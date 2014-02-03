using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraConsoleApp
{
    class Vertex : IComparable<Vertex>
    {
        public string name { get; set; }
        public int distFromSrc { get; set; }
        public Vertex(string n)
        {
            name = n;
            distFromSrc = Int32.MaxValue;
        }

        public int CompareTo(Vertex other)
        {
            if (this.distFromSrc < other.distFromSrc) return -1;
            else if (this.distFromSrc > other.distFromSrc) return 1;
            else return 0;
        }

        public override string ToString()
        {
            return name + " distance from source:: " + distFromSrc;
        }
    }
}
