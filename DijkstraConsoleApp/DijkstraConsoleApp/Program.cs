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
            Graph g;
            Console.WriteLine("Algorytm Dijkstry");
            if (args.Length > 0)
            {
                g = readFromFile(args[0]);
            }
            else
            {
                g = readFromKeyboard();
            } 


            Dijkstra d = new Dijkstra(g);
            d.find();

            foreach (Vertex x in g.vertices)
            {
                System.Console.Out.WriteLine(x.ToString());
            }

            System.Console.ReadKey();
        }

        static Graph readFromKeyboard()
        {
            Graph g = new Graph();
            List<Vertex> vert = new List<Vertex>();

            System.Console.Out.WriteLine("Podaj nazwy wierzchołków.");
            bool stop = false;
            while (stop == false)
            {
                string line = Console.ReadLine();
                if (line == "koniec")
                {
                    stop = true;
                }
                else
                {
                    vert.Add(new Vertex(line));
                }
            }

            System.Console.Out.WriteLine("Podaj krawędzi w grafie. Najpierw podaj nazwy dwóch wierzchołków połączonych krawędzią, następnie wage krawędzi.");
            System.Console.Out.WriteLine("Przykład: start koniec 5");
            stop = false;
            while (stop == false)
            {
                string line = Console.ReadLine();
                if (line == "koniec")
                {
                    stop = true;
                }
                else
                {
                    string[] input = readLine(line);
                    Vertex v = vert.Find(x => x.name == input[0]);
                    Vertex u = vert.Find(x => x.name == input[1]);
                    g.addEdge(new Edge(v, u, Int32.Parse(input[2])));
                }
            }

            System.Console.Out.WriteLine("Podaj nazwę wierzchołka, który będzie źródłem");
            string source = Console.ReadLine();
            Vertex w = vert.Find(x => x.name == source);
            g.setSource(w);

            return g;
        }

        static Graph readFromFile(string filename)
        {
            Graph g = new Graph();
            List<Vertex> vert = new List<Vertex>();

            string[] lines = System.IO.File.ReadAllLines(filename);
            int i = 0;
            bool stop = false;
            while (stop == false)
            {
                string line = lines[i++];
                if (line == "koniec")
                {
                    stop = true;
                }
                else
                {
                    vert.Add(new Vertex(line));
                }
            }

            stop = false;
            while (stop == false)
            {
                string line = lines[i++];
                if (line == "koniec")
                {
                    stop = true;
                }
                else
                {
                    string[] input = readLine(line);
                    Vertex v = vert.Find(x => x.name == input[0]);
                    Vertex u = vert.Find(x => x.name == input[1]);
                    g.addEdge(new Edge(v, u, Int32.Parse(input[2])));
                }
            }

            Vertex w = vert.Find(x => x.name == lines[i]);
            g.setSource(w);
            return g;
        }

        static string[] readLine(string line)
        {
            string[] stringSeparators = new string[] { " " };
            string[] result = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            return result;
        }
    }
}
