using Reference.Lib.DataStructures.Graphs;
using Xunit;


namespace Reference.Lib.Tests.DataStructures.Graphs
{
    public class BreadthFirstSearchTests
    {
        private void Populate(IGraph<int> graph)
        {
            graph.AddVertex(1);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 6);
            graph.AddEdge(2, 7);
            graph.AddEdge(2, 8);
            graph.AddEdge(3, 9);
            Assert.Equal(9, graph.VerticesCount);
            Assert.Equal(8, graph.EdgesCount);
        }


        private void DoesSearch(IGraph<int> graph)
        {
            Populate(graph);

            var search = new BreadthFirstSearch<int>(graph);

            var i = 0;
            foreach (var v in search.Search(1))
            {
                ++i;
                Assert.Equal(i, v);
            }
            Assert.Equal(9, i);
        }


        [Fact]
        public void BFS_DoesSearch_ALGraph()
        {
            DoesSearch(new AlGraph<int>());
        }

        [Fact]
        public void BFS_DoesSearch_DirectedALGraph()
        {
            DoesSearch(new DirectedAlGraph<int>());
        }

        [Fact]
        public void BFS_DoesSearch_WeightedALGraph()
        {
            DoesSearch(new WeightedAlGraph<int, int>());
        }
    }
}