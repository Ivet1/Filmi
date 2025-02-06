using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<int> t1 = new Tree<int>(10,
                new Tree<int>(5,
                new Tree<int>(18),
                new Tree<int>(21)
                ),
                new Tree<int>(8,
                new Tree<int>(3),
                new Tree<int>(30)
                )
                );
            BinTree<int> binTree =
              new BinTree<int>(14,
              new BinTree<int>(19,
              new BinTree<int>(23),
              new BinTree<int>(6,
              new BinTree<int>(10),
              new BinTree<int>(21))),
              new BinTree<int>(15,
              new BinTree<int>(3),
              null));


            Console.Write("Inorder: ");
            binTree.PrintInorder();

            Console.Write("Preorder: ");
            binTree.PrintPreorder();

            Console.Write("Postorder: ");
            binTree.PrintPostorder();
        }
    }
}
