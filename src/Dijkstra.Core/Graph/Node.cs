using System;
using System.Collections.Generic;
using System.Text;

namespace Dijkstra.Core.Graph
{
    public class Node<T>
    {
        public T Value { get; private set; }

        public Node(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
