﻿namespace AVLTree
{
    using System;

    public class Node<T> where T : IComparable<T>
    {
        public Node(T value)
        {
            Value = value;
            Height = 1;
        }

        public T Value { get; set; }

        public Node<T> Left { get; set; }

        public Node<T> Right { get; set; }

        public int Height { get; set; }
    }
}
