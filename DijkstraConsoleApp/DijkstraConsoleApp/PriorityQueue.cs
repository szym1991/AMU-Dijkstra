using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraConsoleApp
{
    class PriorityQueue<T> where T : IComparable<T>
    {
        public List<T> data;

        public PriorityQueue()
        {
            this.data = new List<T>();
        }

        public void Enqueue(T item)
        {
            data.Add(item);
            int ci = data.Count - 1;
            while (ci > 0)
            {
                int pi = (ci - 1) / 2;
                if (data[ci].CompareTo(data[pi]) >= 0) break;
                T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
                ci = pi;
            }
        }

        public T Dequeue()
        {
            int li = data.Count - 1;
            T frontItem = data[0];
            data[0] = data[li];
            data.RemoveAt(li);

            --li; 
            int pi = 0; 
            while (true)
            {
                int ci = pi * 2 + 1;
                if (ci > li) break; 
                int rc = ci + 1;
                if (rc <= li && data[rc].CompareTo(data[ci]) < 0) 
                    ci = rc;
                if (data[pi].CompareTo(data[ci]) <= 0) break;
                T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp;
                pi = ci;
            }
            return frontItem;
        }

        public T Peek()
        {
            T frontItem = data[0];
            return frontItem;
        }

        public int Count()
        {
            return data.Count;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < data.Count; ++i)
                s += data[i].ToString() + " ";
            s += "count = " + data.Count;
            return s;
        }

        public bool IsConsistent()
        {
            if (data.Count == 0) return true;
            int li = data.Count - 1; 
            for (int pi = 0; pi < data.Count; ++pi)
            {
                int lci = 2 * pi + 1;
                int rci = 2 * pi + 2;

                if (lci <= li && data[pi].CompareTo(data[lci]) > 0) return false; 
                if (rci <= li && data[pi].CompareTo(data[rci]) > 0) return false; 
            }
            return true;
        }
    }
}
