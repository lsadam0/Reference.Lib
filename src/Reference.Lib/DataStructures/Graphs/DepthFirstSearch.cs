using System;
using System.Collections.Generic;
using System.Linq;
using Reference.Lib.Algorithms.Sorting;

namespace Reference.Lib.DataStructures.Graphs
{
    /// <summary>
    ///     Implements Depth-First searching of <see cref="IGraph{T}" /> objects
    /// </summary>
    public class DepthFirstSearch<T>
        where T : IComparable<T>
    {
        public DepthFirstSearch(IGraph<T> toSearch)
        {
            Graph = toSearch;
        }

        public IGraph<T> Graph { get; }

        public IEnumerable<T> Search(T root)
        {
            if (!Graph.HasVertex(root))
                throw new KeyNotFoundException();

            var visited = new HashSet<T>();
            var stack = new Collections.Stack<T>();

            visited.Add(root);
            stack.Push(root);

            while (!stack.IsEmpty)
            {
                var next = stack.Pop();
                visited.Add(next);
                yield return next;

                var children = Graph.GetOutgoingEdges(next).Select(x => x.Destination).ToArray();
                children.QuickSort();

                for (var i = children.Length - 1; i >= 0; --i)
                    if (!visited.Contains(children[i]))
                        stack.Push(children[i]);
            }
        }
    }
}