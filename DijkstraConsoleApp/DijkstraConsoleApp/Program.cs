using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph g = new Graph();
            List<Vertex> vert = new List<Vertex>();
            
            vert.Add(new Vertex("0"));
            vert.Add(new Vertex("1"));
            vert.Add(new Vertex("2"));
            vert.Add(new Vertex("3"));
            vert.Add(new Vertex("4"));
            vert.Add(new Vertex("5"));
            g.addEdge(new Edge(vert[0], vert[1], 7));
            g.addEdge(new Edge(vert[0], vert[2], 9));
            g.addEdge(new Edge(vert[0], vert[5], 14));
            g.addEdge(new Edge(vert[1], vert[2], 10));
            g.addEdge(new Edge(vert[1], vert[3], 15));
            g.addEdge(new Edge(vert[2], vert[3], 11));
            g.addEdge(new Edge(vert[2], vert[5], 2));
            g.addEdge(new Edge(vert[3], vert[4], 6));
            g.addEdge(new Edge(vert[4], vert[5], 9));

            g.setSource(vert[0]);

            Dijkstra d = new Dijkstra(g);
            d.find();

            foreach (Vertex x in g.vertices)
            {
                System.Console.Out.WriteLine(x.ToString());
            }

            System.Console.ReadKey();
        }
    }
}
