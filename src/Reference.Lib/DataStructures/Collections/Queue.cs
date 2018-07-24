using System;
using System.Collections;
using System.Collections.Generic;

namespace Reference.Lib.DataStructures.Collections
{
    /// <summary>
    /// Standard First-In-First-Out Queue
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T> : IEnumerable<T>
    {
        private readonly LinkedList<T> _items = new LinkedList<T>();

        public Queue()
        {
        }

        public Queue(T[] items) : this() {
            this.Push(items);
        }

        public bool IsEmpty => !_items.HasNodes;

        public int Count => _items.Count;

        public void Push(params T[] items)
        {
            foreach (var item in items)
                Push(item);
        }

        public void Push(T item)
        {
            _items.AddLast(item);
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new Exception("Empty");

            var res = _items.Head;
            _items.Remove(res);
            return res.Value;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new Exception("Empty");

            return _items.Head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            while (!this.IsEmpty)
                yield return this.Pop();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}