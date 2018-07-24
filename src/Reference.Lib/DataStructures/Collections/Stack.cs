using System;
using System.Collections;
using System.Collections.Generic;


namespace Reference.Lib.DataStructures.Collections
{
    /// <summary>
    /// Standard Last-In-First-Out Stack
    /// </summary>
    public class Stack<T> : IEnumerable<T>
    {
        private readonly DoublyLinkedList<T> _items = new DoublyLinkedList<T>();

        public Stack()
        {

        }

        public Stack(T[] items) : this()
        {
            this.Push(items);
        }

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

        public IEnumerator<T> GetEnumerator()
        {
            while (!this.IsEmpty)
                yield return this.Pop();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}