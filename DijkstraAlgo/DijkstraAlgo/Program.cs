using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C# program for Dijkstra's 
// single source shortest path 
// algorithm. The program is for 
// adjacency matrix representation 
// of the graph. 

namespace DijkstraAlgo
{
    public class ShortestPathAlgo
    {
        static int[,] graph =
{
                {0, 2, 0},
                {2, 0, 3 },
                {0, 2, 0}
            };

        static string[,] direction =
        {
                {"", "U", "" },
                {"D", "", "R" },
                {"", "R", "" }
        };

        private static void SourceToDestinationRoute(int[] path, int destination, List<int> nodes)
        {
            if(destination == -1)
            {
                return;
            }

            SourceToDestinationRoute(path, path[destination], nodes);
            nodes.Add(destination);
            return;

        }
        private static int FindMinIndex(int[] sp, bool[] visited)
        {
            int min = int.MaxValue;
            int minIndex = -1;
            int n = sp.Length;

            for (int i = 0; i < n; i++)
            {
                if (!visited[i] && sp[i] < min)
                {
                    minIndex = i;
                    min = sp[i];
                }
            }

            return minIndex;
        }
        public static string ShortestPath(int source, int destination)
        {
            int n = graph.GetLength(0);

            int[] sp = new int[n];
            bool[] visited = new bool[n];
            int[] path = new int[n];

            for (int k = 0; k < n; k++)
            {
                sp[k] = int.MaxValue;
                visited[k] = false;
            }

            path[source] = -1;
            sp[source] = 0;


            for (int i = 0; i < n-1; i++)
            {
                int u = FindMinIndex(sp, visited);
                visited[u] = true;

                for (int v = 0; v < n; v++)
                {
                    if (!visited[v] && graph[u, v] > 0 && sp[v] > (sp[u] + graph[u, v]))
                    {
                        path[v] = u;
                        sp[v] = sp[u] + graph[u, v];
                    }
                }
            }

            List<int> nodes = new List<int>();

            SourceToDestinationRoute(path, destination, nodes);

            string nextDir = string.Empty;

            int n1 = -1;
            int n2 = -1;


            if (nodes.Count() > 1)
            {
                n1 = nodes[0];
                n2 = nodes[1];

                nextDir = direction[n1, n2];
            }

            if(n2 >= 0 )
            {
                return n2.ToString() + nextDir;
            }

            return "";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ShortestPathAlgo.ShortestPath(0, 2);
            Console.ReadKey();
        }
    }
}
