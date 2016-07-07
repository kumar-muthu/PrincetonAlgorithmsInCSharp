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
            BinarySearchTrees tree = new BinarySearchTrees();
            tree.Put(1, 100);
            tree.Put(3, 300);
            tree.Put(4, 400);
            tree.Put(2, 200);

            Console.WriteLine(tree.Get(2));

            tree.Delete(2);

            foreach (var item in tree.keys())
            {
                Console.WriteLine(item);
            }

        }
    }
}
