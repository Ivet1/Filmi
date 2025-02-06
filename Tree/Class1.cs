using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class TreeNode<T>
    {
        private T value;
        private List<TreeNode<T>> children;
        private bool hasParent;

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.value = value;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.children.Count;
            }
        }
        public TreeNode(T value)
        {
            this.Value = value;
            this.children = new List<TreeNode<T>>();
        }
        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException();
            }
            if (child.hasParent)
            {
                throw new ArgumentException();
            }
            child.hasParent = true;
            this.children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.children[index];
        }
    }
}
