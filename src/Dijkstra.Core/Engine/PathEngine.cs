using Dijkstra.Core.Graph;
using Priority_Queue;
using System.Collections.Generic;

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
            var totalCosts = new Dictionary<Node<T>, int>();
            var previous = new Dictionary<Node<T>, Edge<T>>();
            var priorityQueue = new SimplePriorityQueue<Node<T>>();

            foreach (var node in _graph.Nodes)
            {
                if (node.Value.Equals(source.Value))
                    totalCosts[node] = 0;
                else
                    totalCosts[node] = int.MaxValue;

                priorityQueue.Enqueue(node, totalCosts[node]);
            }

            while (priorityQueue.Count != 0)
            {
                var minimumNode = priorityQueue.Dequeue();

                if (minimumNode.Value.Equals(destination.Value))
                {
                    while (previous.ContainsKey(minimumNode))
                    {
                        pathResult.Insert(previous[minimumNode], 0);
                        minimumNode = pathResult.From;
                    }

                    break;
                }

                var neighborEdges = _graph.Edges.FindAll(x => x.From.Equals(minimumNode));

                foreach (var neighbor in neighborEdges)
                {
                    Node<T> neighborNode;

                    if (neighbor.From.Equals(minimumNode))
                        neighborNode = neighbor.To;
                    else
                        neighborNode = neighbor.From;

                    var smallestCost = totalCosts[minimumNode];
                    var neighborCost = neighbor.Cost;
                    var sumCost = smallestCost + neighborCost;

                    if (sumCost < totalCosts[neighborNode])
                    {
                        totalCosts[neighborNode] = sumCost;
                        previous[neighborNode] = neighbor;

                        priorityQueue.UpdatePriority(neighborNode, sumCost);
                    }
                }
            }

            return pathResult;
        }
    }
}