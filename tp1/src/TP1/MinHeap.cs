using System;
using System.Diagnostics;

namespace TP1
{
    /// <summary>
    /// Heap in which the root priority is smaller than all of its children.
    /// </summary>
    public class MinHeap<TData, TPriority>
        where TPriority : IComparable
        where TData : IComparable
    {
        [DebuggerDisplay("Data: {data}, Priority: {priority}")]
        public class Node
        {
            public TData data;
            public TPriority priority;
        }

        private readonly Node[] Array;

        public int Size { get; private set; }

        /// <remarks>O(1)
        /// </remarks>
        public MinHeap(int size)
        {
            this.Array = new Node[size];
            this.Size = 0;
        }

        /// <remarks> O(log N)
        /// </remarks>
        public void Insert(Node item)
        {
            // store the element at the last position
            this.Array[this.Size] = item; // O(1)

            // move it up until the heap invariant is satisfied
            this.UpHeap(this.Size); // O(log N)

            this.Size++; // O(1)
        }

        /// <remarks>O(N log N)
        /// </remarks>
        public void IncreasePriority(TData data, TPriority newPriority)
        {
            // look for the element by its data
            // (because the elements are sorted by priority, it's a linear search)
            for (int i = 0; i < this.Size; i++) // O(N) worst case, O(1) best case, O(N/2) average case
            {
                if (this.Array[i].data.Equals(data)) // O(log N)
                {
                    // set its new priority
                    this.Array[i].priority = newPriority; // O(1)

                    // move it up the heap
                    this.UpHeap(i); //O(log N)

                    return;
                }
            }
        }

        /// <remarks>O(log N)
        /// </remarks>
        public Node Remove()
        {
            // return the top of the array
            var removedNode = this.Peek(); // O(1)

            // swap it with the last element
            this.Swap(0, this.Size  - 1); // O(1)

            // remove the last element
            this.Array[this.Size - 1] = null; // O(1)
            this.Size--; // O(1)

            // move the new root downwards to maintain the heap invariant
            this.DownHeap(0); // O(log N)

            return removedNode;
        }

        /// <remarks>O(1)
        /// </remarks>
        public Node Peek()
        {
            if (this.Size == 0) // O(1)
            {
                throw new Exception("No elements");
            }
            return this.Array[0]; // O(1)
        }

        /// <remarks>O(log N)
        /// </remarks>
        private void DownHeap(int pos)
        {
            int left = 2 * pos + 1; // O(1)
            int right = 2 * pos + 2; // O(1)
            int smallest = pos; // O(1)

            if (left < this.Size && (this.Array[left].priority.CompareTo(this.Array[smallest].priority) == -1)) // O(1)
            {
                smallest = left; // O(1)
            }

            if (right < this.Size && (this.Array[right].priority.CompareTo(this.Array[smallest].priority) == -1)) // O(1)
            {
                smallest = right; // O(1)
            }

            if (smallest != pos) // O(log N)
            {
                this.Swap(pos, smallest); // O(1)
                this.DownHeap(smallest); // O(log N), the height of the tree
            }
        }

        /// <remarks>O(log N)
        /// </remarks>
        private void UpHeap(int pos)
        {
            int parent = (pos - 1) / 2; // O(1)

            // if the parent is higher than the child
            if (parent >= 0 && this.Array[pos].priority.CompareTo(this.Array[parent].priority) == -1) // O(log N)
            {
                // move the child up and the parent down
                this.Swap(parent, pos); // O(1)

                // now do the same for the new parent
                UpHeap(parent); // Worst case: O(log N), the height of the tree
            }
        }

        /// <remarks>O(1)
        /// </remarks>
        private void Swap(int a, int b)
        {
            var temp = this.Array[a]; // O(1)
            this.Array[a] = this.Array[b]; // O(1)
            this.Array[b] = temp; // O(1)
        }
    }
}
