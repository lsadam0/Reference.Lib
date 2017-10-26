using System.Collections.Generic;
using System.Linq;
using Xunit;
using Reference.Lib.DataStructures.Graphs;

namespace Reference.Lib.Tests.DataStructures.Graphs
{
    public class DirectedALGraphTests
    {
        [Fact]
        public void DirectedALGraph_DoesAddAndRemove_Edges()
        {
            var al = new DirectedAlGraph<int>();

            al.AddEdge(10, 20);
            al.AddVertex(30);
            al.AddEdge(20, 30);

            Assert.Equal(3, al.VerticesCount);
            Assert.Equal(2, al.EdgesCount);
            Assert.Equal(1, al.GetIncomingEdges(20).Count());
            Assert.Equal(1, al.GetOutgoingEdges(20).Count());
            al.RemoveEdge(20, 30);
            Assert.Equal(1, al.EdgesCount);
        }

        [Fact]
        public void DirectedALGraph_DoesAddAndRemove_Vertex()
        {
            var al = new DirectedAlGraph<int>();

            al.AddVertex(1);
            al.AddEdge(1, 2);
            al.AddEdge(1, 3);
            al.AddEdge(3, 1);
            al.AddEdge(2, 1);

            Assert.Equal(3, al.VerticesCount);
            Assert.Equal(4, al.EdgesCount);
            Assert.Equal(2, al.GetIncomingEdges(1).Count());
            Assert.Equal(2, al.GetOutgoingEdges(1).Count());

            al.RemoveVertex(1);
            Assert.Equal(2, al.VerticesCount);
            Assert.Equal(0, al.EdgesCount);
        }

        [Fact]
        public void DirectedALGraph_Edges_DoesReturnAll()
        {
            var al = new DirectedAlGraph<int>();
            al.AddEdge(1, 2);
            al.AddEdge(2, 3);

            var all = al.Edges.ToList();

            Assert.Equal(2, all.Count);
        }

        [Fact]
        public void DirectedALGraph_Vertices_DoReturnAll()
        {
            var al = new DirectedAlGraph<int>();

            al.AddEdge(10, 20);
            al.AddEdge(20, 30);

            var vertices = al.Vertices.ToList();
            Assert.Equal(3, vertices.Count);
            var expected = new List<int> {10, 20, 30};
            Assert.Equal(3, vertices.Intersect(expected).Count());
        }
    }
}