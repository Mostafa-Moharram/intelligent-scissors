using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelligentScissors {
    public class MinHeap<T> where T : IComparable<T> {
        private static int Parent(int i) => (i - 1) / 2;
        private static int LeftChildIndex(int i) => 2 * i + 1;
        private static int RightChildIndex(int i) => 2 * i + 2;
        private static void Swap(ref T o1, ref T o2) => (o2, o1) = (o1, o2);

        private bool HasLeftChild(int i) => LeftChildIndex(i) < count;
        private bool HasRightChild(int i) => RightChildIndex(i) < count;

        private int count = 0;
        private T[] elements = (T[])Array.CreateInstance(typeof(T), 4);
        private void EnsureEnoughSpace() {
            if (count + 1 < elements.Length)
                return;
            Array.Resize(ref elements, 2 * elements.Length);
        }
        private void ShrinkIfBig() {
            if (4 < elements.Length && 2 * count < elements.Length) {
                Array.Resize(ref elements, elements.Length / 2);
            }
        }
        public void Push(T element) {
            EnsureEnoughSpace();
            int i = count;
            elements[count++] = element;
            for (; 0 < i; i = Parent(i)) {
                if (elements[i].CompareTo(elements[Parent(i)]) < 0)
                    Swap(ref elements[i], ref elements[Parent(i)]);
            }
        }
        public void Pop() {
            count--;
            Swap(ref elements[0], ref elements[count]);
            ShrinkIfBig();
            for (int i = 0; HasLeftChild(i);) {
                if (HasRightChild(i)) {
                    if (elements[i].CompareTo(elements[LeftChildIndex(i)]) <= 0
                        && elements[i].CompareTo(elements[RightChildIndex(i)]) <= 0)
                        break;
                    if (elements[LeftChildIndex(i)].CompareTo(elements[RightChildIndex(i)]) > 0) {
                        Swap(ref elements[i], ref elements[RightChildIndex(i)]);
                        i = RightChildIndex(i);
                    } else {
                        Swap(ref elements[i], ref elements[LeftChildIndex(i)]);
                        i = LeftChildIndex(i);
                    }
                } else {
                    if (elements[i].CompareTo(elements[LeftChildIndex(i)]) > 0)
                        Swap(ref elements[i], ref elements[LeftChildIndex(i)]);
                    break;
                }
            }
        }
        public T Peek { get { return elements[0]; } }
        public int Count { get { return count; } }
        public int Capacity { get { return elements.Length; } }
        public void Clear() {
            count = 0;
            Array.Resize(ref elements, 4);
        }
    }
}
