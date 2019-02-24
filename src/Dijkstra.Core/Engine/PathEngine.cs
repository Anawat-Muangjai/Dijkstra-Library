using Dijkstra.Core.Graph;
using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra.Core.Engine
{
    public class PathEngine<T>
    {
        private readonly Graph<T> _graph;

        public PathEngine(Graph<T> graph)
        {
            _graph = graph;
        }

        public PathResult<T> FindShortestPath(Node<T> source, Node<T> destination)
        {
            var pathResult = new PathResult<T>();
            var totalCost = new Dictionary<Node<T>, int>();
            var previousNodes = new Dictionary<Node<T>, Edge<T>>();
            var priorityQueue = new SimplePriorityQueue<Node<T>>();

            foreach (var node in _graph.Nodes)
            {
                if (node.Value.Equals(source.Value))
                    totalCost[node] = 0;
                else
                    totalCost[node] = int.MaxValue;

                priorityQueue.Enqueue(node, totalCost[node]);
            }

            while (priorityQueue.Count != 0)
            {
                var minNode = priorityQueue.Dequeue();

                if (minNode.Value.Equals(destination.Value))
                {
                    while (previousNodes.ContainsKey(minNode))
                    {
                        pathResult.Insert(previousNodes[minNode], 0);
                        minNode = pathResult.From;
                    }

                    break;
                }

                var neighborEdges = _graph.Edges.FindAll(x => x.From.Equals(minNode));

                foreach (var neighbor in neighborEdges)
                {
                    Node<T> neighborNode;

                    if (neighbor.From.Equals(minNode))
                        neighborNode = neighbor.To;
                    else
                        neighborNode = neighbor.From;

                    var smallestCost = totalCost[minNode];
                    var neighborCost = neighbor.Cost;
                    var sumCost = smallestCost + neighborCost;

                    if (sumCost < totalCost[neighborNode])
                    {
                        totalCost[neighborNode] = sumCost;
                        previousNodes[neighborNode] = neighbor;

                        priorityQueue.UpdatePriority(neighborNode, sumCost);
                    }
                }
            }

            return pathResult;
        }
    }
}
