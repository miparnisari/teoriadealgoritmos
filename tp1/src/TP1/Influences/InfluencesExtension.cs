using System;
using System.Collections.Generic;
using System.Linq;
using TP1.Graph;

namespace TP1.Influences
{
    public static class InfluencesExtension
    {
        const long infinity = long.MaxValue - 1;

        /// <remarks>Source: http://www.inf.uni-konstanz.de/algo/publications/b-vspbc-08.pdf </remarks>
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <typeparam name="TId"></typeparam>
        /// <param name="graph"></param>
        /// <returns></returns>
        public static InfluencesCollection<TData, TId> GetInfluences<TData, TId>(this Graph<TData, TId> graph)
            where TData : IIdentifiable<TId>
            where TId : IComparable
        {
            #region initialize data structures and variables

            // distance from source
            var dist = new Dictionary<TId, long>(graph.NodeCount);

            // list of predecessors on shortest paths from source
            var pred = new Dictionary<TId, List<Node<TData, TId>>>(graph.NodeCount); // O(1)

            // number of shortest paths from source to v ∈ V
            var number = new Dictionary<TId, int>(graph.EdgeCount);

            // dependency of source on v ∈ V
            var dependency = new Dictionary<TId, double>(graph.NodeCount);

            var betweenness = new Dictionary<TId, double>(graph.NodeCount);

            #endregion

            foreach (var source in graph.Nodes)
            {
                var queue = new Queue<Node<TData, TId>>(graph.NodeCount);

                var stack = new Stack<Node<TData, TId>>(graph.NodeCount);

                #region single-source shortest-paths problem

                foreach (var node in graph.Nodes)
                {
                    pred[node.Id] = new List<Node<TData, TId>>();
                    dist[node.Id] = infinity;
                    number[node.Id] = 0;
                    betweenness[node.Id] = 0.0;
                }

                dist[source.Id] = 0;
                number[source.Id] = 1;
                queue.Enqueue(source);

                while (queue.Any())
                {
                    var visitedNode = queue.Dequeue();
                    stack.Push(visitedNode);

                    foreach (var adjacent in visitedNode.Adjacents)
                    {
                        if (dist[adjacent.Key] == infinity)
                        {
                            dist[adjacent.Key] = dist[visitedNode.Id] + 1;
                            queue.Enqueue(adjacent.Value);
                        }

                        if (dist[adjacent.Key] == (dist[visitedNode.Id] + 1))
                        {
                            number[adjacent.Key] += number[visitedNode.Id];
                            pred[adjacent.Key].Add(visitedNode);
                        }
                    }
                }

                #endregion

                #region accumulation

                foreach (var node in graph.Nodes)
                {
                    dependency[node.Id] = 0.0;
                }
                
                while (stack.Any())
                {
                    var element = stack.Pop();
                    foreach (var node in pred[element.Id])
                    {
                        double division = number[node.Id]/(double) number[element.Id];
                        dependency[node.Id] = dependency[node.Id] + division * (1.0 + dependency[element.Id]);
                    }
                    if (!element.Equals(source))
                    {
                        betweenness[element.Id] = betweenness[element.Id] + dependency[element.Id];
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
