using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraConsoleApp
{
    class Graph
    {
        public List<Vertex> vertices { get; set; }
        public List<Edge> edges { get; set; }

        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }

        public void addEdge(Edge e)
        {
            edges.Add(e);

            bool existsStart = false;
            bool existsEnd = false;
            foreach (Vertex z in vertices)
            {
                if (z.name == e.v_start.name)
                    existsStart = true;
                if (z.name == e.v_end.name)
                    existsEnd = true;
            }
            if (existsStart == false)
                vertices.Add(e.v_start);

            if (existsEnd == false)
                vertices.Add(e.v_end);
        }

        public void addVertex(Vertex v)
        {
            vertices.Add(v);
        }

        public void setSource(Vertex n)
        {
            Vertex s = vertices.Find(x => x == n);
            s.distFromSrc = 0;
        }

        public Vertex getSource()
        {
            return vertices.Find(x => x.distFromSrc == 0);
        }

        public List<Vertex> getNeightbours(Vertex x)
        {
            List<Vertex> result = new List<Vertex>();
            foreach (Edge w in edges)
            {
                if (w.v_start == x)
                    result.Add(w.v_end);
                else if (w.v_end == x)
                    result.Add(w.v_start);
            }
            return result;
        }

        public int getWeight(Vertex v, Vertex u)
        {
            Edge w = edges.Find(e => e.v_start == v && e.v_end == u ||
                            e.v_end == v && e.v_start == u);
            return w.weight;

        }
    }
}
