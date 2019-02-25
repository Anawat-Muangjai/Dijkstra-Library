using Dijkstra.Core.Engine;
using Dijkstra.Core.Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dijkstra.Tests.Engine
{
    [TestClass]
    public class PathEngineTests
    {
        private PathEngine<string> _pathEngine;
        private Node<string> _nodeA;
        private Node<string> _nodeB;
        private Node<string> _nodeC;
        private Node<string> _nodeD;
        private Node<string> _nodeE;

        [TestInitialize]
        public void TestInitialize()
        {
            _nodeA = new Node<string>("Chiang Mai");
            _nodeB = new Node<string>("Lampang");
            _nodeC = new Node<string>("Sukhothai");
            _nodeD = new Node<string>("Ayuthaya");
            _nodeE = new Node<string>("Bangkok");

            var graph = new Graph<string>();

            // Add node
            graph.AddNode(_nodeA);
            graph.AddNode(_nodeB);
            graph.AddNode(_nodeC);
            graph.AddNode(_nodeD);
            graph.AddNode(_nodeE);

            // Add edges
            graph.AddEdge(_nodeA, _nodeB, 3);
            graph.AddEdge(_nodeA, _nodeC, 5);
            graph.AddEdge(_nodeB, _nodeA, 3);
            graph.AddEdge(_nodeB, _nodeC, 1);
            graph.AddEdge(_nodeB, _nodeD, 2);
            graph.AddEdge(_nodeC, _nodeA, 5);
            graph.AddEdge(_nodeC, _nodeB, 1);
            graph.AddEdge(_nodeC, _nodeD, 3);
            graph.AddEdge(_nodeC, _nodeE, 6);
            graph.AddEdge(_nodeD, _nodeB, 2);
            graph.AddEdge(_nodeD, _nodeC, 3);
            graph.AddEdge(_nodeD, _nodeE, 4);
            graph.AddEdge(_nodeE, _nodeC, 6);
            graph.AddEdge(_nodeE, _nodeD, 4);

            _pathEngine = new PathEngine<string>(graph);
        }

        [TestMethod]
        public void FindShortestPath_FromNodeAToNodeE_TotalCostShould9()
        {
            var result = _pathEngine.FindShortestPath(_nodeA, _nodeE);

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(9, result.TotalCost);
        }

        [TestMethod]
        public void FindShortestPath_FromNodeAToNodeD_TotalCostShould5()
        {
            var result = _pathEngine.FindShortestPath(_nodeA, _nodeD);

            Assert.AreEqual(5, result.TotalCost);
        }

        [TestMethod]
        public void FindShortestPath_FromNodeAToNodeC_TotalCostShould4()
        {
            var result = _pathEngine.FindShortestPath(_nodeA, _nodeC);

            Assert.AreEqual(4, result.TotalCost);
        }

        [TestMethod]
        public void FindShortestPath_FromNodeEToNodeA_TotalCostShould9()
        {
            var result = _pathEngine.FindShortestPath(_nodeE, _nodeA);

            Assert.AreEqual(9, result.TotalCost);
        }

        [TestMethod]
        public void FindShortestPath_FromNodeBToNodeE_TotalCostShould6()
        {
            var result = _pathEngine.FindShortestPath(_nodeB, _nodeE);

            Assert.AreEqual(6, result.TotalCost);
        }
    }
}
