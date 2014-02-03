using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraConsoleApp
{
    // Klasa implementujaca Graf
    class Graph
    {
        public List<Vertex> vertices { get; set; }
        public List<Edge> edges { get; set; }

        public Graph()
        {
            vertices = new List<Vertex>();
            edges = new List<Edge>();
        }

        // dodawanie krawedzi do grafu
        // jeśli wierzcholki nie wystepuja w grafie to rowniez zostaja dodane do listy wierzcholkow
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

        // dodawanie wierzcholka
        public void addVertex(Vertex v)
        {
            vertices.Add(v);
        }

        // wskazanie wierzcholka jako zrodla (od niego liczone beda sciezki w Algorytmie Dijkstry)
        public void setSource(Vertex n)
        {
            Vertex s = vertices.Find(x => x == n);
            s.distFromSrc = 0;
        }

        // zwracanie wierzcholka-zrodla
        public Vertex getSource()
        {
            return vertices.Find(x => x.distFromSrc == 0);
        }

        // zwrocenie listy wierzchokow, ktore sa polaczone krawedzia z wierzcholkiem podanym w parametrze
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

        // zwrocenie wagi krawedzi miedzy ktora sa polaczone wierzcholki
        public int getWeight(Vertex v, Vertex u)
        {
            Edge w = edges.Find(e => e.v_start == v && e.v_end == u ||
                            e.v_end == v && e.v_start == u);
            return w.weight;

        }
    }
}
