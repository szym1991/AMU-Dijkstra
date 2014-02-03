using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraConsoleApp
{
    // Klasa implementujaca algorytm Dijkstry
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
            // dodanie do kolejki wierzcholka oznaczonego jako zrodlo
            q.Enqueue(g.getSource());
            while (q.Count() > 0)
            {
                Vertex u = q.Dequeue();
                // pobranie sasiadow aktualnie badanego wierzcholka
                List<Vertex> nb = g.getNeightbours(u);
                foreach (Vertex v in nb)
                { 
                    int dist = g.getWeight(u, v);
                    // jesli aktualnie badana odleglosc sciezki jest mniejsza od istaniejacej 
                    // to nalezy ja uaktualnic i dodac wierzcholek do kolejki
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
