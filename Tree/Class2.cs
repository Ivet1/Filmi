using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Tree<T>
    {
        private TreeNode<T> root;

        public Tree(T value)
        {
            this.root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        public TreeNode<T> Root
        {
            get
            {
                return this.root;
            }
        }

        // Breadth-First-Search - (BFS)
        public void PrintBFS()
        {
            Queue<TreeNode<T>> visited = new Queue<TreeNode<T>>();
            visited.Enqueue(this.root);
            while (visited.Count != 0)
            {
                TreeNode<T> current = visited.Dequeue();
                Console.Write(current.Value + " ");
                for (int i = 0; i < current.ChildrenCount; i++)
                {
                    visited.Enqueue(current.GetChild(i));
                }
            }
        }

        // Depth-First-Search (DFS)
        public void PrintDFS()
        {
            Stack<TreeNode<T>> visited = new Stack<TreeNode<T>>();
            visited.Push(this.root);
            while (visited.Count != 0)
            {
                TreeNode<T> current = visited.Pop();
                Console.Write(current.Value + " ");
                for (int i = 0; i < current.ChildrenCount; i++)
                {
                    visited.Push(current.GetChild(i));
                }
            }
        }
    }
}
