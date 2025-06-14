using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task_B
{
    class BSTree<T> : BinaryTree<T> where T : IComparable
    {  //root declared as protected in Parent Class – Binary Tree
        public BSTree()
        {
            root = null;
        }

        public void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        private void insertItem(T item, ref Node<T> tree)
        {
            if (tree == null)
            {
                tree = new Node<T>(item);
            }
            else if (item.CompareTo(tree.Data) < 0)
            {
                insertItem(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Data) > 0)
            {
                insertItem(item, ref tree.Right);
            }
            else //when item == tree.Data
            {
                return;
            }
        }
        public bool Equals(BSTree<T> tree)
        {
            return equals(root, tree.root);
            //returns true if this BSTree object contains all the same data as
            //tree with the same structure and ordering of data.
        }

        private bool equals(Node<T> root, Node<T> root2)
        {
            if (root == null && root2 == null)
            {
                return true;
            }

            if (root == null || root2 == null)
            {
                return false;
            }

            return root.Data.CompareTo(root2.Data) == 0 && equals(root.Left, root2.Left) && equals(root.Right, root2.Right);
        }
        
        public bool SubTree(BSTree<T> tree)
        {
            return subTree(root, tree.root);
        }
        private bool subTree(Node<T> root, Node<T> root2)
        {
            if(root==null)
            {
                return false;
            }

            if(root2 == null)
            {
                return true;
            }

            if (equals(root, root2))
            {
                return true;
            }

            return subTree(root.Left, root2) || subTree(root.Right, root2); 
            //returns true if this BSTree object contains the subtree tree. 
            //A subtree of a tree T is a tree consisting of a node in T and all
            // of its descendants in T
        }
    }
}
