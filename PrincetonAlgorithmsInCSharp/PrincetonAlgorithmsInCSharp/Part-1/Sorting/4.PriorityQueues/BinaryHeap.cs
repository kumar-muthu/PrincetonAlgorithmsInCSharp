using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrincetonAlgorithmsInCSharp
{
    /// <summary>
    ///      BinaryHeap heap = new BinaryHeap(new int[] { 8, 5, 7, 6, 4, 3, 2, 1 });
    ///      heap.Sort();
    ///      foreach (var item in heap.items)
    ///      {
    ///        Console.WriteLine(item);
    ///      }
    /// </summary>
    public class BinaryHeap
    {
        public int[] items { get; set; }
        public BinaryHeap(int[] inputs)
        {
            this.items = inputs;
        }


        public void Sort()
        {
            this.CreateHeap();
            for (int i = this.items.Length - 1; i >= 0; i--)
            {
                Exchange(i + 1, 1);
                Sink(1, i);
            }
        }

        private void CreateHeap()
        {
            for (int i = this.items.Length - 1; i >= 0; i--)
            {
                Sink(i + 1, this.items.Length);
            }
        }

        /// <summary>
        /// Used to create and maintain the heap
        /// </summary>
        /// <param name="k"></param>
        /// <param name="n"></param>
        private void Sink(int k, int n)
        {
            while (2 * k < n)
            {
                int j = 2 * k;
                if (Less(j, j + 1))
                {
                    j++;
                }

                if (Less(j, k))
                    break;

                Exchange(k, j);
                k = j;
            }
        }

        /// <summary>
        /// Used to insert an element on a already sorted heap
        /// </summary>
        /// <param name="k"></param>
        private void Swim(int k)
        {
            while (k > 1 && (Less(k / 2, k)))
            {
                Exchange(k, k / 2);
                k = k / 2;
            }
        }

        private bool Less(int i, int j)
        {
            return items[i - 1] < this.items[j - 1];
        }

        private void Exchange(int k, int v)
        {
            int temp = items[k - 1];
            items[k - 1] = items[v - 1];
            items[v - 1] = temp;
        }

    }
}
