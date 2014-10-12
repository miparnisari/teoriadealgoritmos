using System;
using NUnit.Framework;
using TP1;

namespace TP1.Test
{
    [TestFixture()]
    public class HeapTest
    {
        private const int size = 10;

        [Test()]
        public void ShouldReturnEmpty_WhenHeapIsEmpty()
        {
            var heap = new MinHeap<int, int>(size);

            Assert.IsTrue(heap.Size == 0);
        }

        [Test()]
        public void ShouldThrowException_WhenHeapIsEmptyAndTryToPeek()
        {
            var heap = new MinHeap<int, int>(size);

            try
            {
                heap.Peek();
            }
            catch (Exception)
            {
            }
        }

        [Test()]
        public void ShouldThrowException_WhenHeapIsEmptyAndTryToRemove()
        {
            var heap = new MinHeap<int, int>(size);

            try
            {
                heap.Remove();
            }
            catch (Exception)
            {
            }
        }

        [Test()]
        public void ShouldInsertOneElementToHeap()
        {
            var heap = new MinHeap<int, int>(size);
            var node = new MinHeap<int, int>.Node {data = 1, priority = 1};

            heap.Insert(node);

            Assert.AreEqual(node, heap.Peek());
            Assert.AreEqual(1, heap.Size);
        }

        [Test()]
        public void ShouldInsertAndRemoveThreeElementsInOrderToHeap()
        {
            var heap = new MinHeap<int, int>(size);
            var nodeOne = new MinHeap<int, int>.Node { data = 1, priority = 1 };
            var nodeTwo = new MinHeap<int, int>.Node { data = 1, priority = 2 };
            var nodeThree = new MinHeap<int, int>.Node { data = 1, priority = 3 };

            heap.Insert(nodeOne);
            heap.Insert(nodeTwo);
            heap.Insert(nodeThree);

            Assert.AreEqual(3, heap.Size);
            Assert.AreEqual(nodeOne, heap.Remove());
            Assert.AreEqual(2, heap.Size);
            Assert.AreEqual(nodeTwo, heap.Remove());
            Assert.AreEqual(1, heap.Size);
            Assert.AreEqual(nodeThree, heap.Remove());
            Assert.AreEqual(0, heap.Size);
        }

        [Test()]
        public void ShouldInsertAndRemoveThreeElementsNotInOrderToHeap()
        {
            var heap = new MinHeap<int, int>(size);
            var nodeOne = new MinHeap<int, int>.Node { data = 1, priority = 3 };
            var nodeTwo = new MinHeap<int, int>.Node { data = 1, priority = 2 };
            var nodeThree = new MinHeap<int, int>.Node { data = 1, priority = 1 };

            heap.Insert(nodeOne);
            heap.Insert(nodeTwo);
            heap.Insert(nodeThree);

            Assert.AreEqual(3, heap.Size);
            Assert.AreEqual(nodeThree, heap.Remove());
            Assert.AreEqual(2, heap.Size);
            Assert.AreEqual(nodeTwo, heap.Remove());
            Assert.AreEqual(1, heap.Size);
            Assert.AreEqual(nodeOne, heap.Remove());
            Assert.AreEqual(0, heap.Size);
        }

        [Test()]
        public void ShouldDecreasePriorityOfOneElement_WithoutChangingTheHeap()
        {
            var heap = new MinHeap<int, int>(size);
            var nodeOne = new MinHeap<int, int>.Node { data = 3, priority = 3 };
            var nodeTwo = new MinHeap<int, int>.Node { data = 2, priority = 2 };
            var nodeThree = new MinHeap<int, int>.Node { data = 1, priority = 1 };

            heap.Insert(nodeOne);
            heap.Insert(nodeTwo);
            heap.Insert(nodeThree);
            heap.IncreasePriority(3, 2);

            Assert.AreEqual(nodeThree, heap.Remove());
            Assert.AreEqual(nodeTwo, heap.Remove());
            Assert.AreEqual(nodeOne, heap.Remove());
        }

        [Test()]
        public void ShouldDecreasePriorityOfOneElement_ChangingTheHeap()
        {
            var heap = new MinHeap<int, int>(size);
            var nodeOne = new MinHeap<int, int>.Node { data = 4, priority = 4 }; 
            var nodeTwo = new MinHeap<int, int>.Node { data = 3, priority = 3 };
            var nodeThree = new MinHeap<int, int>.Node { data = 2, priority = 2 };
            var nodeFour = new MinHeap<int, int>.Node { data = 1, priority = 1 };

            heap.Insert(nodeOne);
            heap.Insert(nodeTwo);
            heap.Insert(nodeThree);
            heap.Insert(nodeFour);
            heap.IncreasePriority(4, 1);

            Assert.AreEqual(nodeFour, heap.Remove());
            Assert.AreEqual(nodeOne, heap.Remove());
            Assert.AreEqual(nodeThree, heap.Remove());
            Assert.AreEqual(nodeTwo, heap.Remove());
        }
    }
}
