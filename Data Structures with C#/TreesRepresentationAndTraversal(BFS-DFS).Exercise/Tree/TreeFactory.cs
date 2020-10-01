namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class TreeFactory
    {
        private readonly Dictionary<int, Tree<int>> _nodesBykeys;

        public TreeFactory()
        {
            _nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var pair in input)
            {
                var parentChild = pair.Split(' ');

                var parent = int.Parse(parentChild[0]);
                var child = int.Parse(parentChild[1]);

                AddEdge(parent, child);
            }

            var rootTree = GetRoot();

            return rootTree;
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!_nodesBykeys.ContainsKey(key))
            {
                _nodesBykeys.Add(key, new Tree<int>(key));
            }

            return _nodesBykeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            var parentNode = CreateNodeByKey(parent);
            var childNode = CreateNodeByKey(child);

            childNode.AddParent(parentNode);
            parentNode.AddChild(childNode);
        }

        private Tree<int> GetRoot()
        {
            foreach (var kvp in _nodesBykeys)
            {
                if (kvp.Value.Parent == null)
                {
                    return kvp.Value;
                }
            }

            return null;
        }
    }
}
