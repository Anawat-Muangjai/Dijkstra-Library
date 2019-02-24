using Dijkstra.Core.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dijkstra.Core.Engine
{
    public class PathResult<T>
    {
        public List<Edge<T>> Paths { get; private set; }

        public int Count
        {
            get
            {
                return Paths.Count();
            }
        }

        public int TotalCost
        {
            get
            {
                return Paths.Sum(x => x.Cost);
            }
        }

        public Node<T> From
        {
            get
            {
                return Paths[0].From;
            }
        }

        public Node<T> To
        {
            get
            {
                return Paths[Count - 1].To;
            }
        }

        public PathResult(List<Edge<T>> edges = null)
        {
            Paths = edges ?? new List<Edge<T>>();
        }

        public void Insert(Edge<T> edge, int index)
        {
            Paths.Insert(index, edge);
        }

        public override string ToString()
        {
            return $"From: {From} To: {To} Cost: {TotalCost}";
        }
    }
}
