using Reference.Lib.DataStructures.Graphs;

namespace Reference.Lib.Tests.DataStructures.Graphs
{
    public class ALGraphTests : UndirectedGraphTests
    {
        protected override IGraph<int> GetGraph()
        {
            return new AlGraph<int>();
        }

        /*
        [Fact]
        public void ALGraph_DoesAddAndRemove_Vertex()
        {
            var al = new ALGraph<int>();

            al.AddVertex(1);
            al.AddEdge(1, 2);
            al.AddEdge(1, 3);
            al.AddEdge(3, 1);
            al.AddEdge(2, 1);

            Assert.Equal(3, al.VerticesCount);
            Assert.Equal(2, al.EdgesCount);
            Assert.Equal(2, al.GetIncomingEdges(1).Count());
            Assert.Equal(2, al.GetOutgoingEdges(1).Count());

            al.RemoveVertex(1);
            Assert.Equal(2, al.VerticesCount);
            Assert.Equal(0, al.EdgesCount);


        }

        [Fact]
        public void ALGraph_DoesAddAndRemove_Edges()
        {
            var al = new ALGraph<int>();

            al.AddEdge(10, 20);
            al.AddVertex(30);
            al.AddEdge(20, 30);

            Assert.Equal(3, al.VerticesCount);
            Assert.Equal(2, al.EdgesCount);
            al.RemoveEdge(20, 30);
            Assert.Equal(1, al.EdgesCount);
        }

        [Fact]
        public void ALGraph_Vertices_DoReturnAll()
        {
            var al = new ALGraph<int>();

            al.AddEdge(10, 20);
            al.AddEdge(20, 30);

            var vertices = al.Vertices.ToList();
            Assert.Equal(3, vertices.Count);
            var expected = new List<int>() { 10, 20, 30 };

            Assert.Equal(3, vertices.Intersect(expected).Count());
        }

        [Fact]
        public void ALGraph_Edges_DoesReturnAll()
        {
            var al = new ALGraph<int>();
            al.AddEdge(1, 2);
            al.AddEdge(2, 3);

            var all = al.Edges.ToList();

            Assert.Equal(4, all.Count);
        }*/
    }
}