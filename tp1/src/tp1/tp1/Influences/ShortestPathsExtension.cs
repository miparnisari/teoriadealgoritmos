using System;
using System.Collections.Generic;
using System.Linq;
using TP1.Graph;

namespace tp1.Influences
{
    public static class ShortestPathsExtension
    {
        public static List<List<Node<TData, TId>>> GetShortestPathsWithDijkstra<TData, TId>
            (this Graph<TData, TId> graph,
                Node<TData, TId> source,
                Node<TData, TId> target)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        { 
            var distanceTo = new Dictionary<Node<TData, TId>, long>();
            var subsetGraph = new Graph<TData, TId>();
            var unvisitedNodes = new HashSet<Node<TData, TId>>(); //TODO improve with min-priority queue

            distanceTo[source] = 0;

            var nodeInSubset = new Node<TData, TId>(source.Data);

            subsetGraph.AddNode(nodeInSubset.Data);

            foreach (var node in graph.Nodes)
            {
                if (!node.Equals(source))
                {
                    distanceTo[node] = Int64.MaxValue;
                }
                unvisitedNodes.Add(node);
            }

            while (unvisitedNodes.Any())
            {
                // Select node with minimum distance from source
                var visitedNode = distanceTo
                    .OrderBy(i => i.Value)
                    .First(n => unvisitedNodes.Contains(n.Key))
                    .Key;

                nodeInSubset = new Node<TData, TId>(visitedNode.Data);

                unvisitedNodes.Remove(visitedNode);

                foreach (var adjacent in visitedNode.Adjacents)
                {
                    var currentDistance = distanceTo[visitedNode] + 1;

                    if (currentDistance <= distanceTo[adjacent.Value])
                    {
                        // A shorter (or equally short) path has been found!
                        distanceTo[adjacent.Value] = currentDistance;
                        nodeInSubset.AddAdjacentNode(adjacent.Value);
                    }
                }

                subsetGraph.AddNode(nodeInSubset.Data);
            }

            return BreadthFirstSearch(subsetGraph, source, target);
        }

        public static List<List<Node<TData, TId>>> BreadthFirstSearch<TData, TId>(this Graph<TData, TId> graph, Node<TData, TId> source, Node<TData, TId> target)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var queue = new Queue<Node<TData, TId>>();
            var parent = new Dictionary<Node<TData, TId>, List<Node<TData, TId>>>();
            queue.Enqueue(source);

            while (queue.Any())
            {
                var node = queue.Dequeue();
                if (!node.Visited)
                {
                    node.Visited = true;
                    foreach (var child in node.Adjacents.Values.Where(n => graph.Nodes.Contains(n)))
                    {
                        queue.Enqueue(child);
                        if (!parent.ContainsKey(child) && !child.Visited)
                        {
                            parent.Add(child, new List<Node<TData, TId>>());
                        }
                        if (!child.Visited)
                        {
                            parent[child].Add(node);
                        }
                    }
                }
            }

            return GetResult(parent, target);
        }

        public static List<List<Node<TData, TId>>> GetResult<TData, TId>
            (Dictionary<Node<TData, TId>,
            List<Node<TData, TId>>> parent,
            Node<TData, TId> index)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            List<Node<TData, TId>> prefix = new List<Node<TData, TId>>();
            List<List<Node<TData, TId>>> results = new List<List<Node<TData, TId>>>();
            FindParentsInternal(parent, index, prefix, results);
            return results;
        }

        private static void FindParentsInternal<TData, TId>
            (Dictionary<Node<TData, TId>, List<Node<TData, TId>>> parent, 
            Node<TData, TId> index, 
            List<Node<TData, TId>> prefix,
            List<List<Node<TData, TId>>> results)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            var newPrefix = new List<Node<TData, TId>>(prefix) {index};
            if (!parent.ContainsKey(index))
            {
                newPrefix.Reverse();
                results.Add(newPrefix);
                return;
            }
            parent[index].ForEach(i => FindParentsInternal(parent, i, newPrefix, results));
        }
    }
}
