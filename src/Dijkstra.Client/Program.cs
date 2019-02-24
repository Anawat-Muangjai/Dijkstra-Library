using Dijkstra.Core.Engine;
using Dijkstra.Core.Graph;
using System;

namespace Dijkstra.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            FindShortestPath();
        }

        static void FindShortestPath()
        {
            // Step 1: Create node
            var nodeA = new Node<string>("Chiang Mai");
            var nodeB = new Node<string>("Lampang");
            var nodeC = new Node<string>("Sukhothai");
            var nodeD = new Node<string>("Ayuthaya");
            var nodeE = new Node<string>("Bangkok");

            // Step 2: Create graph data
            var graph = new Graph<string>();

            // Step 3: Add node
            graph.AddNode(nodeA);
            graph.AddNode(nodeB);
            graph.AddNode(nodeC);
            graph.AddNode(nodeD);
            graph.AddNode(nodeE);

            // Step 4: Add edges
            graph.AddEdge(nodeA, nodeB, 3);
            graph.AddEdge(nodeA, nodeC, 5);
            graph.AddEdge(nodeB, nodeA, 3);
            graph.AddEdge(nodeB, nodeC, 1);
            graph.AddEdge(nodeB, nodeD, 2);
            graph.AddEdge(nodeC, nodeA, 5);
            graph.AddEdge(nodeC, nodeB, 1);
            graph.AddEdge(nodeC, nodeD, 3);
            graph.AddEdge(nodeC, nodeE, 6);
            graph.AddEdge(nodeD, nodeB, 2);
            graph.AddEdge(nodeD, nodeC, 3);
            graph.AddEdge(nodeD, nodeE, 4);
            graph.AddEdge(nodeE, nodeC, 6);
            graph.AddEdge(nodeE, nodeD, 4);

            // Step 5: Create path engine and call function
            var pathEngine = new PathEngine<string>(graph);
            var pathResult = pathEngine.FindShortestPath(nodeA, nodeE);

            // Display path result
            Console.WriteLine($"Total cost from {pathResult.From} to {pathResult.To} is {pathResult.TotalCost}");
            Console.WriteLine("============================================");

            foreach (var path in pathResult.Paths)
            {
                Console.WriteLine(path.ToString());
            }

            Console.WriteLine("============================================");
            Console.ReadKey();
        }
    }
}
