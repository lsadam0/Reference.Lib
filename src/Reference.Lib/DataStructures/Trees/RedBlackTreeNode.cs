namespace Reference.Lib.DataStructures.Trees
{
    /*
    * Each node is either red or black.
    * The root is black. This rule is sometimes omitted. Since the 
    * root can always be changed from red to black, but not 
    * necessarily vice versa, this rule has little effect on analysis.
    * 
    * All leaves (NIL) are black.
    * 
    * If a node is red, then both its children are black.
    * 
    * Every path from a given node to any of its descendant NIL 
    * nodes contains the same number of black nodes. 
    * 
    *
    * Some definitions: the number of black nodes from the root to a 
    * node is the node's black depth; the uniform number of black nodes 
    * in all paths from root to the leaves is called the black-height 
    * of the red–black tree.[17]
     */
    public class RedBlackTreeNode<T> : BinaryTreeNode<T>
    {
        public RedBlackTreeNode(T value) : base(value)
        {
        }

        public bool IsRed { get; private set; }

        public bool IsBlack => !IsRed;
    }
}