using System;

namespace Reference.Lib.DataStructures.Trees
{

    /// <summary>
    /// Example output is given using a Binary Search Tree
    /// </summary>
    public enum TreeTraversalMethod
    {
        /// <summary>
        /// (Left, Root, Right): 4,2,5,1,3
        /// </summary>
        InOrder,
        /// <summary>
        /// (Root, Left, Right): 1,2,4,5,3
        /// </summary>
        PreOrder,
        /// <summary>
        /// (Left, Right, Root): 4,5,2,3,1
        /// </summary>
        PostOrder,

        /// <summary>
        /// 1,2,3,4,5
        /// </summary>
        BreadthFirst,

        /// <summary>
        /// 1,2,4,5,3
        /// </summary>
        DepthFirst
    }


}