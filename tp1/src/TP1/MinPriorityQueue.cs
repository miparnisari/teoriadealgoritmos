using System;

namespace TP1
{
    public class MinPriorityQueue<TData, TPriority>
        where TData : IComparable
        where TPriority : IComparable
    {
        private readonly MinHeap<TData, TPriority> heap;

        /// <remarks>O(1)
        /// </remarks>
        public MinPriorityQueue(int size)
        {
            this.heap = new MinHeap<TData, TPriority>(size);
        }

        /// <remarks>O(log N)
        /// </remarks>
        public void InsertWithPriority(TData data, TPriority priority)
        {
            MinHeap<TData, TPriority>.Node node = new MinHeap<TData, TPriority>.Node
            {
                priority = priority,
                data = data
            };

            this.heap.Insert(node);
        }

        /// <remarks>O(log N)
        /// </remarks>
        public MinHeap<TData, TPriority>.Node Remove()
        {
            return this.heap.Remove();
        }

        /// <remarks>O(N log N)
        /// </remarks>
        public void IncreasePriority(TData data, TPriority newPriority)
        {
            this.heap.IncreasePriority(data, newPriority);
        }

        /// <remarks>O(1)
        /// </remarks>
        public bool ContainsElements()
        {
            return this.heap.Size > 0;
        }
    }
}
