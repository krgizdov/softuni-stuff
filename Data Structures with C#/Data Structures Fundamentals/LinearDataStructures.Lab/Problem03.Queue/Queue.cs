namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;

        public Queue()
        {
            _head = null;
            Count = 0;
        }

        public Queue(Node<T> head)
        {
            _head = head;
            Count = 1;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentNode = _head;

            while (currentNode != null)
            {
                if (currentNode.Value.Equals(item))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            EnsureNotEmpty();

            T headNodeValue = _head.Value;

            var newHead = _head.Next;

            _head.Next = null;

            _head = newHead;
            Count--;

            return headNodeValue;
        }

        public void Enqueue(T item)
        {
            var currentNode = _head;
            var newNode = new Node<T>(item);

            if (currentNode == null)
            {
                _head = newNode;
            }
            else
            {
                while (currentNode.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                currentNode.Next = newNode;
            }

            Count++;
        }

        public T Peek()
        {
            EnsureNotEmpty();

            return _head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Invalid operation! Queue is empty!");
            }
        }
    }
}