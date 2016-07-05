using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincetonAlgorithmsInCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryHeap heap = new BinaryHeap(new int[] { 8, 5, 7, 6, 4, 3, 2, 1 });
            heap.Sort();

            foreach (var item in heap.items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
