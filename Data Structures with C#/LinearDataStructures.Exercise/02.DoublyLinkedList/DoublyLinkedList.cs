namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T> { Item = item };

            if (Count == 0)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _head.Previous = newNode;
                newNode.Next = _head;
                _head = newNode;
            }

            Count++;
        }

        public void AddLast(T item)
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
                newNode.Previous = _tail;
                _tail = newNode;
            }

            Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();

            return _head.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            return _tail.Item;
        }

        public T RemoveFirst()
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
                newHead.Previous = null;
                _head.Next = null;
                _head = newHead;
            }

            Count--;

            return current.Item;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            var current = _tail;

            if (Count == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                var newTail = _tail.Previous;
                newTail.Next = null;
                _tail.Previous = null;
                _tail = newTail;
            }

            Count--;

            return current.Item;
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
                throw new InvalidOperationException("Doubly Linked List is empty!");
            }
        }
    }
}