using System;
using System.Collections;
using System.Collections.Generic;

namespace Reference.Lib.DataStructures.Graphs
{

    public interface IGraph<T>
        where T : IComparable<T>
    {
        bool IsDirected { get; }

        bool IsWeighted { get; }

        int EdgesCount { get; }

        int VerticesCount { get; }

        IEnumerable<T> Vertices { get; }


        IEnumerable<IEdge<T>> Edges { get; }

        bool AddEdge(T origin, T destination);

        bool AddVertex(T vertex);


        void AddVertices(IEnumerable<T> vertices);

        IEnumerable<IEdge<T>> GetIncomingEdges(T vertex);

        IEnumerable<IEdge<T>> GetOutgoingEdges(T vertex);


        bool HasEdge(T origin, T destination);

        bool HasVertex(T vertex);

        bool RemoveEdge(T origin, T destination);

        bool RemoveVertex(T vertex);

        /// <summary>
        /// Returns the degree of the given vertex.
        /// </summary>
        /// <param name="vertex">The vertex to calculate its degeree.</param>
        /// <returns>Returns the degree of the given vertex.</returns>
        int Degree(T vertex);

        /// <summary>
        /// Removes all edges and vertices from the graph.
        /// </summary>
        void Clear();

        IEnumerable<T> BreadthFirstSearch(T root);
        
        IEnumerable<T> DepthFirstSearch(T root);
        
        /*    
        IEnumerable<IEdge<T>> BreadthFirstSearchEdges(T vertex);

        IEnumerable<IEdge<T>> DepthFirstSearchEdges(T vertex);
        */
    }
}