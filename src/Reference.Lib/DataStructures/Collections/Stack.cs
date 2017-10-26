using System;

namespace Reference.Lib.DataStructures.Collections
{
    /// <summary>
    ///     Last-In-First-Out
    /// </summary>
    public class Stack<T>
    {
        private readonly DoublyLinkedList<T> _items = new DoublyLinkedList<T>();
        public bool IsEmpty => Count < 1;
        public int Count => _items.Count;

        public void Push(T item)
        {
            _items.AddLast(item);
        }

        public void Push(params T[] items)
        {
            foreach (var item in items)
                Push(item);
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new Exception("Empty");

            return _items.RemoveLast().Value;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new Exception("Empty");

            return _items.Tail.Value;
        }
    }
}