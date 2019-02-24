namespace Dijkstra.Core.Graph
{
    public class Edge<T>
    {
        public Node<T> From { get; set; }

        public Node<T> To { get; set; }

        public int Cost { get; set; }

        public Edge(Node<T> from, Node<T> to, int cost)
        {
            From = from;
            To = to;
            Cost = cost;
        }

        public override string ToString()
        {
            return $"From: {From} To: {To} Cost: {Cost}";
        }
    }
}