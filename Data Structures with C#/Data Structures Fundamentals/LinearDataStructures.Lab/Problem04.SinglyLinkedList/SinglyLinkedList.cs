namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;

        public SinglyLinkedList()
        {
            _head = null;
            Count = 0;
        }

        public SinglyLinkedList(Node<T> head)
        {
            _head = head;
            Count = 1;
        }

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item, _head);
            _head = newNode;
            Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);
            var currentNode = _head;

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

        public T GetFirst()
        {
            EnsureNotEmpty();

            return _head.Value;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            var currentNode = _head;

            while (currentNode.Next != null)
            {
                currentNode = currentNode.Next;
            }

            return currentNode.Value;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            T headNodeValue = _head.Value;

            var newHead = _head.Next;

            _head.Next = null;

            _head = newHead;
            Count--;

            return headNodeValue;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            var currentNode = _head;
            T valueToReturn;

            if (currentNode.Next == null)
            {
                valueToReturn = currentNode.Value;
                _head = null;
            }
            else
            {
                while (currentNode.Next.Next != null)
                {
                    currentNode = currentNode.Next;
                }

                valueToReturn = currentNode.Next.Value;

                currentNode.Next = null;
            }

            #region Another way
            //var previousNode = _head;

            //while (currentNode.Next != null)
            //{
            //    previousNode = currentNode;
            //    currentNode = currentNode.Next;
            //}

            //var valueToReturn = currentNode.Value;

            //previousNode.Next = null;
            #endregion

            Count--;

            return valueToReturn;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;

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
                throw new InvalidOperationException("Invalid operation! Linked List is empty!");
            }
        }
    }
}