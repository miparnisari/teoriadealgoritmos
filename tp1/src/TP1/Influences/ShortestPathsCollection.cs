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

        /// <remarks>O(N)
        /// Source: http://msdn.microsoft.com/en-us/library/dw8e0z9z(v=vs.110).aspx
        /// </remarks>
        public ShortestPathsCollection(int initialCapacity)
        {
            this.Paths = new List<ShortestPath<TData, TId>>(initialCapacity);
        }

        /// <remarks>O(1)
        /// Source: http://msdn.microsoft.com/es-AR/library/27b47ht3(v=vs.110).aspx
        /// </remarks>
        public int Count
        {
            get { return this.Paths.Count; }
        }

        /// <remarks> Best case: O(N), worst case: O(N+M)
        /// N: size of "Paths"
        /// M: current size
        /// Source: http://msdn.microsoft.com/en-US/library/z883w3dc(v=vs.110).aspx
        /// </remarks>
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
