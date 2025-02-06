using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class BinTreeNode<T>
    {
        private T value;
        private bool hasparent;
        private BinTreeNode<T> leftChild;
        private BinTreeNode<T> rightChild;


        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (this.value == null)
                {
                    throw new ArgumentNullException();
                }
                this.value = value;
            }
        }

        public BinTreeNode<T> LeftChild
        {
            get
            {
                return this.leftChild;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                if (value.hasparent)
                {
                    throw new ArgumentException();
                }
                value.hasparent = true;
                this.leftChild = value;
            }
        }

        public BinTreeNode<T> RightChild
        {
            get
            {
                return this.rightChild;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                if (value.hasparent)
                {
                    throw new ArgumentException();
                }
                value.hasparent = true;
                this.rightChild = value;
            }
        }

        public BinTreeNode(T value, BinTreeNode<T> leftChild, BinTreeNode<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public BinTreeNode(T value) : this(value, null, null)
        {
        }

    }
}
