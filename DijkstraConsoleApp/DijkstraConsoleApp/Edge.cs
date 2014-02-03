using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraConsoleApp
{
    class Edge
    {
        public Vertex v_start { get; set; }
        public Vertex v_end { get; set; }
        public int weight { get; set; }

        public Edge(Vertex s, Vertex e, int w)
        {
            v_start = s;
            v_end = e;
            weight = w;
        }

        public override string ToString()
        {
            return v_start.name + "=>" + v_end.name;
        }
    }
}
