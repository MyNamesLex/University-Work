using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree
{
    class BinaryTree<T> where T : IComparable
    {
        protected Node<T> root; //change to protected

        public BinaryTree()  //creates an empty tree
        {
            root = null;
        }
        public BinaryTree(Node<T> node)  //creates a tree with node as the root
        {
            root = node;
        }

        public void PreOrder() //for the user of this class - hides nodes away ADT 
        {
            preOrder(root); //start recursion at top of the tree
        }

        private void preOrder(Node<T> tree) //current node we are at for this copy of the code
        {
            //stopping condition? - empty tree : null
            if (tree == null)
            {
                //do nothing
            }
            else
            {
                Console.Write("," + tree.Data.ToString());
                //recursive call(s)  - left and right, think about one step away from, stop
                //name my method, look at parameter(s)
                //it is a function - is there anything to do with what is returned
                preOrder(tree.Left);
                preOrder(tree.Right);
            }
        }

        public void PostOrder() //for the user of this class - hides nodes away ADT 
        {
            string buffer = "";
            postOrder(root, ref buffer);
            Console.WriteLine(buffer); //start recursion at top of the tree
        }

        private void postOrder(Node<T> tree, ref string buffer)
        {
            if (tree == null)
            {
                return;
            }
            else
            {
                inOrder(tree.Left, ref buffer);
                inOrder(tree.Right, ref buffer);
                buffer += tree.Data.ToString() + ",";
            }
        }

        public void InOrder()
        {
            string buffer = "";
            inOrder(root, ref buffer);
            Console.WriteLine(buffer);
        }

        private void inOrder(Node<T> tree, ref string buffer)
        {
            if (tree == null)
            {
                return;
            }
            inOrder(tree.Left, ref buffer);
            buffer += tree.Data.ToString() + ",";
            inOrder(tree.Right, ref buffer);
        }

        public void Copy(BinaryTree<T> tree2)
        {
            copy(ref root, tree2.root);
        }

        private void copy(ref Node<T> tree, Node<T> tree2)
        {

        }

        public int Count()
        {
            return count(root);
        }
        private int count(Node<T> tree)
        {
            //stopping condition
            if (tree == null) //if empty tree, count should be 0 - return 0;
            {
                return 0;
            }

            //recursive calls - left & right
            //count comes back with an integer
            //count should 1 + count left
            return 1 + count(tree.Left) + count(tree.Right); //process this node
        }

        public int Height()
        {
            return height(root);
        }
        private int height(Node<T> root)
        //Return the max level of the tree
        {
            if(root == null)
            {
                return 0;
            }

            int leftHeight = height(root.Left);
            int rightHeight = height(root.Right);
            int maxheight = Math.Max(leftHeight, rightHeight);

            return 1 + maxheight;
        }

        public Boolean Contains(T item)
        //Return true if the item is contained in the BSTree, false 	  //otherwise.
        {
            bool present = false;
            while (item != null)
            {
                if (item.Equals(root.Data))
                {
                    present = true;
                    return present;
                }
            }
            return present;
        }
    }
}