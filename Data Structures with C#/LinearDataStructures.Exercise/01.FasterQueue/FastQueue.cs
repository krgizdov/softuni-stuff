﻿namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public FastQueue()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = _head;

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            EnsureNotEmpty();

            var current = _head;

            if (Count == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                var newHead = _head.Next;
                _head.Next = null;
                _head = newHead;
            }

            Count--;
            return current.Item;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T> { Item = item };

            if (Count == 0)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                _tail = newNode;
            }

            Count++;
        }

        public T Peek()
        {
            EnsureNotEmpty();

            return _head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }
        }
    }
}