﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace KruskalSAlgorithm
{
    class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var e = int.Parse(Console.ReadLine());

            var edges = ReadEdges(e);

            var sortedEdges = edges.OrderBy(e => e.Weight).ToList();

            var nodes = new HashSet<int>();
            foreach (var edge in sortedEdges)
            {
                nodes.Add(edge.First);
                nodes.Add(edge.Second);
            }
            //var nodes = edges.Select(e => e.First).Union(edges.Select(e => e.Second)).ToHashSet();

            var parents = Enumerable.Repeat(-1, nodes.Max() + 1).ToArray();
            foreach (var node in nodes)
            {
                parents[node] = node;
            }

            foreach (var edge in sortedEdges)
            {
                var firstNodeRoot = GetRoot(parents, edge.First);
                var secondNodeRoot = GetRoot(parents, edge.Second);

                if (firstNodeRoot != secondNodeRoot)
                {
                    Console.WriteLine($"{edge.First} - {edge.Second}");
                    parents[firstNodeRoot] = secondNodeRoot;
                }
            }
        }

        private static int GetRoot(int[] parents, int node)
        {
            while (node != parents[node])
            {
                node = parents[node];
            }

            return node;
        }

        private static List<Edge> ReadEdges(int e)
        {
            var edges = new List<Edge>();

            for (int i = 0; i < e; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];
                var weight = edgeData[2];

                edges.Add(new Edge
                {
                    First = firstNode,
                    Second = secondNode,
                    Weight = weight
                });
            }

            return edges;
        }
    }
}
