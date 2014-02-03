using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraConsoleApp
{
    class Dijkstra
    {
        public PriorityQueue<Vertex> q;
        public Graph g;
        public Dijkstra(Graph g)
        {
            this.g = g;
            q = new PriorityQueue<Vertex>();
        }

        public void find()
        {
            q.Enqueue(g.getSource());
            while (q.Count() > 0)
            {
                Vertex u = q.Dequeue();
                List<Vertex> nb = g.getNeightbours(u);
                foreach (Vertex v in nb)
                {
                    int dist = g.getWeight(u, v);
                    if (v.distFromSrc > (u.distFromSrc + dist))
                    {
                        v.distFromSrc = u.distFromSrc + dist;
                        q.Enqueue(v);
                    }
                }
            }
        }
    }
}
