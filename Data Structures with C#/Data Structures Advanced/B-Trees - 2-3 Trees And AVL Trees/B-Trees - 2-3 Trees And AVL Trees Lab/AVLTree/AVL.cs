namespace AVLTree
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public Node<T> Root { get; private set; }

        public bool Contains(T item)
        {
            var node = Search(Root, item);

            return node != null;
        }

        public void Insert(T item)
        {
            Root = Insert(Root, item);
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(Root, action);
        }

        private Node<T> Insert(Node<T> node, T item)
        {
            if (node == null)
            {
                return new Node<T>(item);
            }

            int cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                node.Left = Insert(node.Left, item);
            }
            else if (cmp > 0)
            {
                node.Right = Insert(node.Right, item);
            }

            UpdateHeight(node);

            node = Balance(node);

            return node;
        }

        private Node<T> Search(Node<T> node, T item)
        {
            if (node == null)
            {
                return null;
            }

            int cmp = item.CompareTo(node.Value);
            if (cmp < 0)
            {
                return Search(node.Left, item);
            }
            else if (cmp > 0)
            {
                return Search(node.Right, item);
            }

            return node;
        }

        private void EachInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            EachInOrder(node.Left, action);
            action(node.Value);
            EachInOrder(node.Right, action);
        }

        private static int Height(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }

        private static void UpdateHeight(Node<T> node)
        {
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
        }

        private static Node<T> RotateLeft(Node<T> node)
        {
            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            UpdateHeight(node);
            UpdateHeight(right);

            return right;
        }

        private static Node<T> RotateRight(Node<T> node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            UpdateHeight(node);
            UpdateHeight(left);

            return left;
        }

        private static Node<T> Balance(Node<T> node)
        {
            int balance = Height(node.Left) - Height(node.Right);
            if (balance < -1)
            {
                balance = Height(node.Right.Left) - Height(node.Right.Right);

                if (balance > 0)
                {
                    node.Right = RotateRight(node.Right);
                }

                return RotateLeft(node);
            }
            else if (balance > 1)
            {
                balance = Height(node.Left.Left) - Height(node.Left.Right);

                if (balance < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }

                return RotateRight(node);
            }

            return node;
        }
    }
}
