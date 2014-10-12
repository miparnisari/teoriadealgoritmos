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

        public MinHeap(int size)
        {
            this.Array = new Node[size];
            this.Size = 0;
        }

        public void Insert(Node item)
        {
            // store the element at the last position
            this.Array[this.Size] = item;

            // move it up until the heap invariant is satisfied
            this.UpHeap(this.Size);

            this.Size++;
        }

        public void IncreasePriority(TData data, TPriority newPriority)
        {
            // look for the element
            for (int i = 0; i < this.Size; i++)
            {
                if (this.Array[i].data.Equals(data))
                {
                    // set its new priority
                    this.Array[i].priority = newPriority;

                    // move it up the heap
                    this.UpHeap(i);

                    return;
                }
            }
        }

        public Node Remove()
        {
            // return the top of the array
            var removedNode = this.Peek();

            // swap it with the last element
            this.Swap(0, this.Size  - 1);

            // remove the last element
            this.Array[this.Size - 1] = null;
            this.Size--;

            // move the new root downwards to maintain the heap invariant
            this.DownHeap(0);

            return removedNode;
        }

        public Node Peek()
        {
            if (this.Size == 0)
            {
                throw new Exception("No elements");
            }
            return this.Array[0];
        }

        private void DownHeap(int pos)
        {
            int left = 2 * pos + 1;
            int right = 2 * pos + 2;
            int smallest = pos;

            if (left < this.Size && (this.Array[left].priority.CompareTo(this.Array[smallest].priority) == -1))
            {
                smallest = left;
            }

            if (right < this.Size && (this.Array[right].priority.CompareTo(this.Array[smallest].priority) == -1))
            {
                smallest = right;
            }

            if (smallest != pos)
            {
                this.Swap(pos, smallest);
                this.DownHeap(smallest);
            }
        }

        private void UpHeap(int pos)
        {
            int parent = (pos - 1) / 2;

            // if the parent is higher than the child
            if (parent >= 0 && this.Array[pos].priority.CompareTo(this.Array[parent].priority) == -1)
            {
                // move the child up and the parent down
                this.Swap(parent, pos);

                // now do the same for the new parent
                UpHeap(parent);
            }
        }

        private void Swap(int a, int b)
        {
            var temp = this.Array[a];
            this.Array[a] = this.Array[b];
            this.Array[b] = temp;
        }
    }
}
