using System;
using System.Diagnostics;

namespace tp1
{
    public class MinPriorityQueue<TData, TPriority>
        where TData : IComparable
        where TPriority : IComparable
    {
        private MinHeap<TData, TPriority> heap;

        public MinPriorityQueue(int size)
        {
            this.heap = new MinHeap<TData, TPriority>(size);
        }

        public void InsertWithPriority(TData data, TPriority priority)
        {
            MinHeap<TData, TPriority>.Node node = new MinHeap<TData, TPriority>.Node
            {
                priority = priority,
                data = data
            };

            heap.Insert(node);
        }

        public MinHeap<TData, TPriority>.Node Remove()
        {
            return this.heap.Remove();
        }

        public void DecreasePriority(TData data, TPriority newPriority)
        {
            this.heap.DecreasePriority(data, newPriority);
        }

        public bool ContainsElements()
        {
            return this.heap.Size > 0;
        }

    }
}
