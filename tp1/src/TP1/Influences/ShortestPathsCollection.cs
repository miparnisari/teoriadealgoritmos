using System;
using System.Collections;
using System.Collections.Generic;
using TP1.Graph;

namespace TP1.Influences
{
    public class ShortestPathsCollection<TData, TId> : IEnumerable
        where TData : IIdentifiable<TId>
        where TId : IComparable
    {
        public List<ShortestPath<TData, TId>> Paths { get; set; }

        public ShortestPathsCollection()
        {
            this.Paths = new List<ShortestPath<TData, TId>>();
        }

        public ShortestPath<TData, TId> this[int index]
        {
            get { return this.Paths[index]; }
        }

        public int Count
        {
            get { return this.Paths.Count; }
        }

        public void AddPaths(IEnumerable<ShortestPath<TData, TId>> paths)
        {
            this.Paths.AddRange(paths);
        }

        public void AddPaths(ShortestPathsCollection<TData, TId> paths)
        {
            this.Paths.AddRange(paths.Paths);
        }

        public IEnumerator GetEnumerator()
        {
            return this.Paths.GetEnumerator();
        }
    }
}
