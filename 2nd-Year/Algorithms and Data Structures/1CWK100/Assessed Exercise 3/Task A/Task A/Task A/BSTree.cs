using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_A
{
    class BSTree<T> : BinaryTree<T> where T : IComparable
    {  //root declared as protected in Parent Class – Binary Tree
        public BSTree()
        {
            root = null;
        }

        public void InsertItem(T word)
        {
            insertItem(ref root, word);
        }

        private void insertItem(ref Node<T> tree, T word)
        {
            if (tree == null)
            {
                tree = new Node<T>(word);
            }
            else if (word.CompareTo(tree.Data) < 0)
            {
                insertItem(ref tree.Left, word);
            }
            else if (word.CompareTo(tree.Data) > 0)
            {
                insertItem(ref tree.Right, word);
            }
            else //when item == tree.Data
            {
                return;
            }
        }
    }
}
