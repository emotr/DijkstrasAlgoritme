﻿namespace DijkstrasAlgoritme
{
    public class Program
    {
        static readonly int V = 5; // Antall noder. Må endres basert på hvilken graph som brukes
        public static void Main(string[] args)
        {
            int[,] graph = new int[,] { {0, 4, 7, 0},
                                        {4, 0, 0, 8},
                                        {7, 0, 0, 2},
                                        {0, 8, 2, 0} }; // Avstand/vekt mellom noder

            int[,] graph2 = new int[,] { {0, 4, 5, 0, 0},
                                         {4, 0, 0, 3, 0},
                                         {5, 0, 0, 0, 1},
                                         {0, 3, 0, 0, 3},
                                         {0, 0, 1, 3, 0} };

            int[,] graph3 = new int[,] { {0, 3, 2, 0, 0},
                                         {3, 0, 0, 3, 0},
                                         {2, 0, 0, 2, 6},
                                         {0, 3, 2, 0, 7},
                                         {0, 0, 6, 7, 0} };
            //Dijkstra(graph, 0);
            //Dijkstra(graph2, 0);
            Dijkstra(graph3, 0);
        }

        /** Finn korteste vei mellom V noder */
        private static void Dijkstra(int[,] graph, int source)
        {
            int v = graph.Length;
            bool[] visited = new bool[v];
            int[] distance = new int[v];
             
            for (int i = 0; i < v; i++) // For hver node i graph
            {
                distance[i] = int.MaxValue; // Sett distanse til høyest mulig verdi 
            }

            distance[source] = 0; // Første node har avstand 0

            for (int i = 0; i < V - 1; i++)
            {
               int minIndex = FindMinIndex(distance, visited); // Finn vertex med minst distanse

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
            for (int i = 0; i < V; i++)
            {
                Console.WriteLine(i + " " + distance[i]);
            }
        }

        /** Finn minste avstandsindeks */
        private static int FindMinIndex(int[] distance, bool[] visited)
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