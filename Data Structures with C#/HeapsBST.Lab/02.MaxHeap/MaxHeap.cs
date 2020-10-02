namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private readonly List<T> _elements;

        public MaxHeap()
        {
            _elements = new List<T>();
        }

        public int Size => _elements.Count;

        public void Add(T element)
        {
            _elements.Add(element);

            HeapifyUp();
        }

        public T Peek()
        {
            EnsureNotEmpty();

            return _elements[0];
        }

        private void HeapifyUp()
        {
            int currentindex = Size - 1;
            int parentIndex = GetParentIndex(currentindex);

            while (IndexIsValid(currentindex) && IsGreater(currentindex, parentIndex))
            {
                Swap(currentindex, parentIndex);
                currentindex = parentIndex;
                parentIndex = GetParentIndex(currentindex);
            }
        }

        private void Swap(int currentindex, int parentIndex)
        {
            var childElement = _elements[currentindex];

            _elements[currentindex] = _elements[parentIndex];
            _elements[parentIndex] = childElement;
        }

        private int GetParentIndex(int currentindex)
        {
            return (currentindex - 1) / 2;
        }

        private bool IndexIsValid(int index)
        {
            return index > 0;
        }

        private bool IsGreater(int currentindex, int parentIndex)
        {
            return _elements[currentindex].CompareTo(_elements[parentIndex]) > 0;
        }

        private void EnsureNotEmpty()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException("Max heap is empty!");
            }
        }
    }
}
