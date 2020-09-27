namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public Stack()
        {
            _top = null;
            Count = 0;
        }

        public Stack(Node<T> top)
        {
            _top = top;
            Count = 1;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currentNode = _top;

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

        public T Peek()
        {
            EnsureNotEmpty();

            return _top.Value;
        }

        public T Pop()
        {
            EnsureNotEmpty();

            T topNodeValue = _top.Value;

            //var newTop = _top.Next;

            //_top.Next = null;

            //_top = newTop;

            _top = _top.Next;
            Count--;

            return topNodeValue;
        }

        public void Push(T item)
        {
            var newNode = new Node<T>(item, _top);

            _top = newNode;

            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _top;

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
                throw new InvalidOperationException("Invalid operation! Stack is empty!");
            }
        }
    }
}