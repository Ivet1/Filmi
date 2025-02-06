using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class BinTree<T>
    {
        private BinTreeNode<T> root;

        public BinTreeNode<T> Root
        {
            get
            {
                return this.root;
            }
        }

        public BinTree(T value, BinTree<T> leftChild, BinTree<T> rightChild)
        {
            BinTreeNode<T> leftChildNode = leftChild != null ? leftChild.root : null;
            BinTreeNode<T> rightChildNode = rightChild != null ? rightChild.root : null;
            this.root = new BinTreeNode<T>(value, leftChildNode, rightChildNode);
        }

        public BinTree(T value) : this(value, null, null)
        {
        }

        private void PrintInorder(BinTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }

            PrintInorder(root.LeftChild);
            Console.Write(root.Value + " ");
            PrintInorder(root.RightChild);
        }

        public void PrintInorder()
        {
            PrintInorder(this.Root);
            Console.WriteLine();
        }

        private void PrintPreorder(BinTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }
            Console.Write(root.Value + " ");
            PrintPreorder(root.LeftChild);
            PrintPreorder(root.RightChild);
        }

        public void PrintPreorder()
        {
            PrintPreorder(this.root);
            Console.WriteLine();
        }

        private void PrintPostorder(BinTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }
            PrintPostorder(root.LeftChild);
            PrintPostorder(root.RightChild);
            Console.Write(root.Value + " ");
        }

        public void PrintPostorder()
        {
            PrintPostorder(this.root);
            Console.WriteLine();
        }
    }
}
