namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private readonly List<T> _elements;

        public PriorityQueue()
        {
            _elements = new List<T>();
        }

        public int Size => _elements.Count;

        public T Dequeue()
        {
            var firstElement = Peek();

            Swap(0, Size - 1);

            _elements.RemoveAt(Size - 1);

            HeapifyDown();

            return firstElement;
        }
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

        private void HeapifyDown()
        {
            int index = 0;
            int leftChildIndex = GetLeftChildIndex(0);

            while (IndexIsValidDown(leftChildIndex) && IsLesser(index, leftChildIndex))
            {
                int toSwapWith = leftChildIndex;
                int rightChildIndex = GetRightChildIndex(index);

                if (IndexIsValidDown(rightChildIndex) && IsLesser(toSwapWith, rightChildIndex))
                {
                    toSwapWith = rightChildIndex;
                }

                Swap(toSwapWith, index);

                index = toSwapWith;
                leftChildIndex = GetLeftChildIndex(index);
            }
        }

        private void HeapifyUp()
        {
            int currentindex = Size - 1;
            int parentIndex = GetParentIndex(currentindex);

            while (IndexIsValidUp(currentindex) && IsGreater(currentindex, parentIndex))
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

        private int GetLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        private int GetRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        private bool IndexIsValidDown(int index)
        {
            return index < Size;
        }

        private bool IndexIsValidUp(int index)
        {
            return index > 0;
        }

        private bool IsGreater(int currentindex, int parentIndex)
        {
            return _elements[currentindex].CompareTo(_elements[parentIndex]) > 0;
        }

        private bool IsLesser(int currentindex, int parentIndex)
        {
            return _elements[currentindex].CompareTo(_elements[parentIndex]) < 0;
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
