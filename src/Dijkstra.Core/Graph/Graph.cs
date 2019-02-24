using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra.Core.Graph
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes { get; private set; }

        public List<Edge<T>> Edges { get; private set; }

        public Graph(List<Node<T>> nodes = null, List<Edge<T>> edges = null)
        {
            Nodes = nodes ?? new List<Node<T>>();
            Edges = edges ?? new List<Edge<T>>();
        }

        public void AddNode(Node<T> vertex)
        {
            Nodes.Add(vertex);
        }

        public void AddEdge(Edge<T> edge)
        {
            Edges.Add(edge);
        }

        public void AddEdge(Node<T> from, Node<T> to, int cost)
        {
            Edges.Add(new Edge<T>(from, to, cost));
        }
    }
}
