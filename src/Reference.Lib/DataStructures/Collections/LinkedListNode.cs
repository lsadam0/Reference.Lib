using System;

namespace Reference.Lib.DataStructures.Collections
{
    public class LinkedListNode<T>
    {
        public T Value { get; }

        public LinkedListNode<T> Next { get; internal set; }

        public LinkedListNode(T value, LinkedListNode<T> next)
        {
            Value = value;
            Next = next;
        }
    }
}