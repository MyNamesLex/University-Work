using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Task_B
{
    class AVLTree<T> : BSTree<T> where T : IComparable
    {
        public new void InsertItem(T item)
        {
            insertItem(item, ref root);
        }

        private void insertItem(T item, ref Node<T> tree) //inserts, then rearranges tree if necessary
        {
            if (tree == null)
            {
                tree = new Node<T>(item);
            }
            else if (item.CompareTo(tree.Data) < 0)
            {
                insertItem(item, ref tree.Left); //call a copy of the code with left tree
            }
            else if (item.CompareTo(tree.Data) > 0)
            {
                insertItem(item, ref tree.Right);
            }
            tree.BalanceFactor = height(tree.Left) - height(tree.Right);
            //-2
            if (tree.BalanceFactor <= -2)
                rotateLeft(ref tree);
            else if (tree.BalanceFactor >= 2)
                rotateRight(ref tree);
        }

        private void rotateRight(ref Node<T> tree)
        {
            //double rotate -see lecture notes for help
            if (tree.Right.BalanceFactor > 0)
            {
                rotateLeft(ref tree.Left);
            }
            Node<T> newRoot, oldRoot;

            //rotate left algorithm
            oldRoot = tree;
            newRoot = oldRoot.Right;
            oldRoot.Right = newRoot.Left;
            newRoot.Left = oldRoot;
            tree = newRoot;
        }

        private void rotateLeft(ref Node<T> tree)
        {
            //double rotate -see lecture notes for help
            if (tree.Right.BalanceFactor > 0)
            {
                rotateLeft(ref tree.Left);
            }
            Node<T> newRoot, oldRoot;

            //rotate left algorithm
            oldRoot = tree;
            newRoot = oldRoot.Right;
            oldRoot.Right = newRoot.Left;
            newRoot.Left = oldRoot;
            tree = newRoot;
        }

    }
}
