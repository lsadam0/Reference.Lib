using System;
using Reference.Lib.DataStructures.Graphs;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Reference.Lib.Tests.DataStructures.Graphs
{

    public class ALGraphTests
    {
        [Fact]
        public void ALGraph_DoesAddAndRemove_Vertex()
        {
            var al = new ALGraph<int>();

            al.AddVertex(1);

            Assert.Equal(1, al.VerticesCount);
            Assert.Equal(0, al.EdgesCount);

            al.RemoveVertex(1);
            Assert.Equal(0, al.VerticesCount);
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
        }
    }
}
