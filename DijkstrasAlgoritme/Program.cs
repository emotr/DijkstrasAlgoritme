using System;
using System.Diagnostics;

namespace DijkstrasAlgoritme
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[,] graph1 = new int[,] { {0, 4, 7, 0},
                                         {4, 0, 0, 8},
                                         {7, 0, 0, 2},
                                         {0, 8, 2, 0} }; // Avstand/vekt mellom noder. V = 4

            int[,] graph2 = new int[,] { {0, 4, 5, 0, 0},
                                         {4, 0, 0, 3, 0},
                                         {5, 0, 0, 0, 1},
                                         {0, 3, 0, 0, 3},
                                         {0, 0, 1, 3, 0} }; // V = 5

            int[,] graph3 = new int[,] { {0, 3, 2, 0, 0},
                                         {3, 0, 0, 3, 0},
                                         {2, 0, 0, 2, 6},
                                         {0, 3, 2, 0, 7},
                                         {0, 0, 6, 7, 0} }; // V = 5

            int[,] graph4 = new int[,] { {0, 3, 0, 4, 0, 0, 0, 0, 0, 0},
                                         {3, 0, 2, 0, 3, 7, 0, 0, 0, 0},
                                         {0, 2, 3, 0, 0, 0, 0, 0, 0, 0},
                                         {4, 0, 3, 0, 0, 5, 0, 6, 0, 0},
                                         {0, 3, 0, 0, 0, 5, 2, 0, 0, 0},
                                         {0, 7, 0, 5, 4, 0, 0, 2, 0, 0},
                                         {0, 0, 0, 0, 2, 0, 0, 0, 2, 0},
                                         {0, 0, 0, 6, 0, 2, 0, 0, 0, 4},
                                         {0, 0, 0, 0, 0, 5, 2, 0, 0, 3},
                                         {0, 0, 0, 0, 0, 0, 0, 4, 3, 0} }; // V = 10

            int[,] graph5 = new int[,] { {0, 3, 0, 4, 0, 0, 0, 0, 0, 0, 0},
                                         {3, 0, 2, 0, 3, 7, 0, 0, 0, 0, 0},
                                         {0, 2, 3, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {4, 0, 3, 0, 0, 5, 0, 6, 0, 0, 0},
                                         {0, 3, 0, 0, 0, 5, 2, 0, 0, 0, 8},
                                         {0, 7, 0, 5, 4, 0, 0, 2, 5, 0, 0},
                                         {0, 0, 0, 0, 2, 0, 0, 0, 2, 7, 0},
                                         {0, 0, 0, 6, 0, 2, 0, 0, 0, 4, 0},
                                         {0, 0, 0, 0, 0, 5, 2, 0, 0, 0, 3},
                                         {0, 0, 0, 0, 0, 0, 0, 4, 3, 0, 2},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 2} }; // V = 11

            int[,] graph6 = new int[,] { {0, 3, 2, 4, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {3, 0, 1, 0, 2, 0, 0, 0, 0, 0, 0, 0},
                                         {2, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                                         {4, 0, 1, 0, 0, 5, 0, 0, 0, 0, 0, 0},
                                         {0, 2, 0, 0, 0, 2, 0, 3, 0, 0, 0, 0},
                                         {0, 0, 0, 5, 2, 0, 4, 4, 0, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 4, 0, 6, 0, 4, 0, 0},
                                         {0, 0, 0, 0, 3, 4, 6, 0, 2, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 2, 0, 2, 3, 4},
                                         {0, 0, 0, 0, 0, 0, 4, 0, 2, 0, 0, 0},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2},
                                         {0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 2, 0} }; // V = 12

            Stopwatch timer = new();
            timer.Start();
            // Første parameter er grafen, andre er start noden og tredje er antall noder i grafen
            Console.WriteLine("Graf 1: fire noder");
            Dijkstra(graph1, 0, 4);
            Console.WriteLine("\nGraf 2: fem noder");
            Dijkstra(graph2, 0, 5);
            Console.WriteLine("\nGraf 3: fem noder");
            Dijkstra(graph3, 0, 5);
            Console.WriteLine("\nGraf 4: 10 noder");
            Dijkstra(graph4, 0, 10);
            Console.WriteLine("\nGraf 5: 11 noder");
            Dijkstra(graph5, 0, 11);
            Console.WriteLine("\nGraf 5: 11 noder, start node er 4");
            Dijkstra(graph5, 4, 11);
            Console.WriteLine("\nGraf 6: 12 noder");
            Dijkstra(graph6, 0, 12);
            timer.Stop();
            Console.WriteLine("Tid: {0} ms", timer.ElapsedMilliseconds);
        }

        /** Finn korteste vei mellom V noder */
        private static void Dijkstra(int[,] graph, int source, int V)
        {
            int v = graph.Length;
            bool[] visited = new bool[v];
            int[] distance = new int[v];
             
            for (int i = 0; i < v; i++) // For hver node i graph
            {
                distance[i] = int.MaxValue; // Sett distanse til alle noder til høyest mulig verdi 
            }

            distance[source] = 0; // Start node har avstand 0

            for (int i = 0; i < V - 1; i++)
            {
               int minIndex = FindMinIndex(distance, visited, V); // Finn vertex med minst distanse

                visited[minIndex] = true;

                for (int j = 0; j < V; j++)
                {
                    if (!visited[j] && graph[minIndex, j] != 0 && distance[minIndex] != int.MaxValue && distance[minIndex] + graph[minIndex, j] < distance[j])
                    {
                        distance[j] = distance[minIndex] + graph[minIndex, j];
                    }
                }
            }

            // Print løsning
            Console.WriteLine("Node nr\t     Avstand");
            for (int i = 0; i < V; i++)
            {
                Console.WriteLine("   " + i + " \t\t" + distance[i]);
            }
        }

        /** Finn minste avstandsindeks */
        private static int FindMinIndex(int[] distance, bool[] visited, int V)
        {
            int minVertex = -1;
            for (int i = 0; i < V; i++)
            {
                if (!visited[i] && (minVertex == -1 || distance[i] < distance[minVertex]))
                {
                    minVertex = i;
                }
            }

            return minVertex;
        }
    }
}