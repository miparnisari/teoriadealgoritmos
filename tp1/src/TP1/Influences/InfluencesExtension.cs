using System;
using System.Collections.Generic;
using System.Linq;
using TP1.Graph;

namespace TP1.Influences
{
    public static class InfluencesExtension
    {
        const long Infinity = long.MaxValue - 1;

        /// <remarks>Reference: http://www.inf.uni-konstanz.de/algo/publications/b-vspbc-08.pdf </remarks>
        /// <summary>
        /// Calculates the betweenness centrality of all the nodes in a graph using the Brandes algorithm
        /// </summary>
        /// <returns></returns>
        public static InfluencesCollection<TData, TId> GetInfluences<TData, TId>(this Graph<TData, TId> graph)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            #region initialize data structures and variables

            // distance from source to to v ∈ V
            var distanceTo = new Dictionary<TId, long>(graph.NodeCount);

            // list of predecessors on shortest paths from source
            var previous = new Dictionary<TId, HashSet<Node<TData, TId>>>(graph.NodeCount); // O(1)

            // number of shortest paths from source to v ∈ V
            var numberOfShortestPathsTo = new Dictionary<TId, double>(graph.EdgeCount);

            // dependency of source on v ∈ V
            var dependency = new Dictionary<TId, double>(graph.NodeCount);

            // used in BFS
            var queue = new Queue<Node<TData, TId>>(graph.NodeCount);

            // nodes reachable from a source
            var stack = new Stack<Node<TData, TId>>(graph.NodeCount);

            var betweenness = new Dictionary<TId, double>(graph.NodeCount);

            foreach (var node in graph.Nodes)
            {
                betweenness[node.Id] = 0;
            }

            #endregion

            foreach (var source in graph.Nodes) // O(|V|) * O(|V| + |E|) = O(|V|^2 + |V||E|)
            {
                #region single-source shortest-paths problem with BFS O(|V| + |E|)

                foreach (var node in graph.Nodes)
                {
                    previous[node.Id] = new HashSet<Node<TData, TId>>();
                    distanceTo[node.Id] = Infinity;
                    numberOfShortestPathsTo[node.Id] = 0;
                    dependency[node.Id] = 0;
                }

                numberOfShortestPathsTo[source.Id] = 1;
                distanceTo[source.Id] = 0;
                queue.Enqueue(source);

                #region breadth first search O(|V| + |E|)
                while (queue.Any()) 
                {
                    var visitedNode = queue.Dequeue();
                    stack.Push(visitedNode);

                    foreach (var adjacent in visitedNode.Adjacents)
                    {
                        // a short path has been found! update the min dist and add the vertex to the queue
                        if (distanceTo[adjacent.Key] == Infinity)
                        {
                            distanceTo[adjacent.Key] = distanceTo[visitedNode.Id] + 1;
                            queue.Enqueue(adjacent.Value);
                        }

                        if (distanceTo[adjacent.Key] == (distanceTo[visitedNode.Id] + 1))
                        {
                            numberOfShortestPathsTo[adjacent.Key] += numberOfShortestPathsTo[visitedNode.Id];
                            previous[adjacent.Key].Add(visitedNode);
                        }
                    }
                }
                #endregion

                #endregion

                #region accumulation O(|E|)

                while (stack.Any())
                {
                    var element = stack.Pop();
                    foreach (var node in previous[element.Id])
                    {
                        dependency[node.Id] += (numberOfShortestPathsTo[node.Id] / numberOfShortestPathsTo[element.Id]) * (1 + dependency[element.Id]);
                    }
                    if (!element.Equals(source))
                    {
                        betweenness[element.Id] += dependency[element.Id];
                    }
                }
                #endregion
            }

            var result = new InfluencesCollection<TData, TId>(graph.NodeCount);
            foreach (var influence in betweenness)
            {
                result.Add(new Influence<TData, TId>(graph[influence.Key], influence.Value));
            }

            return result;
        }
    }
}
