namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T value)
        {
            Value = value;
            Parent = null;
            _children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                _children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();
        public bool IsRootDeleted { get; private set; }

        public ICollection<T> OrderBfs()
        {
            var result = new List<T>();
            if (IsRootDeleted)
            {
                return result;
            }

            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> subTree = queue.Dequeue();

                result.Add(subTree.Value);

                foreach (Tree<T> child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            var result = new List<T>();
            if (IsRootDeleted)
            {
                return result;
            }

            Dfs(this, result);

            return result;
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            #region Dfs My Way
            //FindDfs(parentKey, this, child);

            //CheckEmptyNode(child.Parent);
            #endregion 
            #region Dfs Lecturer Way
            //var searchedNode = FindDfs(parentKey, this);

            //CheckEmptyNode(searchedNode);

            //searchedNode._children.Add(child);
            #endregion
            #region With Bfs
            var searchedNode = FindBfs(parentKey);

            CheckEmptyNode(searchedNode);

            searchedNode._children.Add(child);
            #endregion
        }

        public void RemoveNode(T nodeKey)
        {
            var searchedNode = FindBfs(nodeKey);
            CheckEmptyNode(searchedNode);

            foreach (var child in searchedNode.Children)
            {
                child.Parent = null;
            }

            searchedNode._children.Clear();

            var searchedParent = searchedNode.Parent;

            if (searchedParent == null)
            {
                IsRootDeleted = true;
            }
            else
            {
                searchedParent._children.Remove(searchedNode);
            }

            searchedNode.Value = default;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = FindBfs(firstKey);
            var secondNode = FindBfs(secondKey);

            CheckEmptyNode(firstNode);
            CheckEmptyNode(secondNode);

            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;

            if (firstParent == null)
            {
                ChangeNodeParentsIfRoot(firstNode, secondNode);
            }
            else if (secondParent == null)
            {
                ChangeNodeParentsIfRoot(secondNode, firstNode);
            }
            else
            {
                firstNode.Parent = secondParent;
                secondNode.Parent = firstParent;

                int indexOfFirst = firstParent._children.IndexOf(firstNode);
                int indexOfSecond = secondParent._children.IndexOf(secondNode);

                firstParent._children[indexOfFirst] = secondNode;
                secondParent._children[indexOfSecond] = firstNode;
            }
        }

        private void ChangeNodeParentsIfRoot(Tree<T> rootNode, Tree<T> newRootNode)
        {
            rootNode.Value = newRootNode.Value;
            rootNode._children.Clear();
            foreach (var child in newRootNode.Children)
            {
                rootNode._children.Add(child);
            }
        }

        private void Dfs(Tree<T> subTree, List<T> result)
        {
            foreach (var child in subTree.Children)
            {
                Dfs(child, result);
            }

            result.Add(subTree.Value);
        }

        #region Add With Bfs
        private Tree<T> FindBfs(T parentKey)
        {
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                Tree<T> subTree = queue.Dequeue();

                if (subTree.Value.Equals(parentKey))
                {
                    return subTree;
                }

                foreach (Tree<T> child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }
        #endregion

        #region FindDfs - My Way
        //We could add a check to see if the parent is sait in order to stop the recursion.

        //private void FindDfs(T value, Tree<T> subTree, Tree<T> childToAdd)
        //{
        //    if (subTree.Value.Equals(value))
        //    {
        //        subTree._children.Add(childToAdd);
        //        childToAdd.Parent = subTree;
        //    }

        //    foreach (var child in subTree.Children)
        //    {
        //        FindDfs(value, child, childToAdd);
        //    }
        //}
        #endregion

        #region FindDfs - Lecturer Way
        private Tree<T> FindDfs(T value, Tree<T> subTree)
        {
            foreach (var child in subTree.Children)
            {
                Tree<T> current = FindDfs(value, child);

                if (current != null && current.Value.Equals(value))
                {
                    return current;
                }
            }

            if (subTree.Value.Equals(value))
            {
                return subTree;
            }

            return null;
        }
        #endregion

        private void CheckEmptyNode(Tree<T> searchedNode)
        {
            if (searchedNode == null)
            {
                throw new ArgumentNullException("Searched Node not found!");
            }
        }

        #region OrderDfsWithStack
        //private ICollection<T> OrderDfsWithStack()
        //{
        //    var result = new Stack<T>();
        //    var toTraverse = new Stack<Tree<T>>();

        //    toTraverse.Push(this);

        //    while (toTraverse.Count != 0)
        //    {
        //        var subtree = toTraverse.Pop();

        //        foreach (var child in subtree.Children)
        //        {
        //            toTraverse.Push(child);
        //        }

        //        result.Push(subtree.Value);
        //    }

        //    return new List<T>(result);
        //}
        #endregion
    }
}
