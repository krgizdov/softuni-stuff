namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            Key = key;
            _children = new List<Tree<T>>();

            foreach (var child in children)
            {
                AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => _children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            _children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            Parent = parent;
        }

        public string GetAsString()
        {
            var treeAsString = new StringBuilder();

            DfsDrawTreeAsString(this, treeAsString, 0);

            return treeAsString.ToString().Trim();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            #region OneWayWithDfs
            //var result = new Dictionary<Tree<T>, int>();

            //DfsGetDeepestElement(this, result, 0);

            //var leftmostDeepestNode = result.OrderByDescending(kvp => kvp.Value).FirstOrDefault().Key;

            //return leftmostDeepestNode;
            #endregion

            #region A way with Bfs
            var leafNodes = OrderBfs(IsLeafNode);
            int deepestNodePath = 0;
            Tree<T> deepestNode = null;

            foreach (var node in leafNodes)
            {
                int currentDepth = GetDepthFromLeafToRoot(node);

                if (currentDepth > deepestNodePath)
                {
                    deepestNodePath = currentDepth;
                    deepestNode = node;
                }
            }

            return deepestNode;
            #endregion
        }

        public List<T> GetLeafKeys()
        {
            var leafNodes = BfsGetRequiredNodes(IsLeafNode);

            return leafNodes;
        }

        public List<T> GetMiddleKeys()
        {
            var middleNodes = BfsGetRequiredNodes(IsMiddleNode);

            return middleNodes;
        }

        public List<T> GetLongestPath()
        {
            var deepestNode = GetDeepestLeftomostNode();
            var longestPathNodes = new Stack<T>();

            var current = deepestNode;

            while (current != null)
            {
                longestPathNodes.Push(current.Key);
                current = current.Parent;
            }

            return new List<T>(longestPathNodes);
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var result = new List<List<T>>();
            var currentPath = new List<T>();
            currentPath.Add(Key);
            int currentSum = Convert.ToInt32(Key);

            GetPathWithSumDfs(this, result, currentPath, ref currentSum, sum);

            return result;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            Func<Tree<T>, int, bool> subTreeSumPredicate =
                (currentNode, wantedSum) => HasGivenSum(currentNode, wantedSum);

            return OrderBfs(subTreeSumPredicate, sum);
        }

        private void DfsDrawTreeAsString(Tree<T> subTree, StringBuilder treeAsString, int depth)
        {
            treeAsString.AppendLine($"{new string(' ', depth)}{subTree.Key}");

            foreach (var child in subTree.Children)
            {
                //depth += 2;
                DfsDrawTreeAsString(child, treeAsString, depth + 2);
                //depth -= 2;
            }
        }

        #region GetDeepestElementWithDfs
        //private void DfsGetDeepestElement(Tree<T> subTree, Dictionary<Tree<T>, int> result, int depth)
        //{
        //    result.Add(subTree, depth);

        //    foreach (var child in subTree.Children)
        //    {
        //        DfsGetDeepestElement(child, result, depth + 2);
        //    }
        //}
        #endregion

        private List<T> BfsGetRequiredNodes(Func<Tree<T>, bool> toCheck)
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();

                if (toCheck(current))
                {
                    result.Add(current.Key);
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private List<Tree<T>> OrderBfs(Func<Tree<T>, bool> toCheck)
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();

                if (toCheck(current))
                {
                    result.Add(current);
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private List<Tree<T>> OrderBfs(Func<Tree<T>, int, bool> toCheck, int sum)
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var current = queue.Dequeue();

                if (toCheck(current, sum))
                {
                    result.Add(current);
                }

                foreach (var child in current.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        private bool HasGivenSum(Tree<T> currentNode, int sum)
        {
            int actualSum = GetSubtreeSumDfs(currentNode);

            return actualSum == sum;
        }

        private int GetDepthFromLeafToRoot(Tree<T> node)
        {
            int depth = 0;
            var current = node;
            while (current.Parent != null)
            {
                depth++;
                current = current.Parent;
            }

            return depth;
        }

        private void GetPathWithSumDfs(Tree<T> tree, List<List<T>> wantedPaths,
            List<T> currentPath, ref int currentSum, int wantedSum)
        {
            foreach (var child in tree.Children)
            {
                currentPath.Add(child.Key);
                currentSum += Convert.ToInt32(child.Key);
                GetPathWithSumDfs(child, wantedPaths, currentPath, ref currentSum, wantedSum);
            }

            if (currentSum == wantedSum)
            {
                wantedPaths.Add(new List<T>(currentPath));
            }

            currentSum -= Convert.ToInt32(tree.Key);
            currentPath.RemoveAt(currentPath.Count - 1);
        }

        private int GetSubtreeSumDfs(Tree<T> currentNode)
        {
            int currentSum = Convert.ToInt32(currentNode.Key);
            int childSum = 0;
            foreach (var childNode in currentNode.Children)
            {
                childSum += GetSubtreeSumDfs(childNode);
            }

            return currentSum + childSum;
        }

        private bool IsLeafNode(Tree<T> treeNode)
        {
            return treeNode.Children.Count == 0;
        }

        private bool IsMiddleNode(Tree<T> treeNode)
        {
            return treeNode.Children.Count != 0 && treeNode.Parent != null;
        }
    }
}
