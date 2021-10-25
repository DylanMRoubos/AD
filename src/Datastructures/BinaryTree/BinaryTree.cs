namespace AD
{
    public partial class BinaryTree<T> : IBinaryTree<T>
    {
        public BinaryNode<T> root;

        //----------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------

        public BinaryTree()
        {
            root = null;
        }

        public BinaryTree(T rootItem)
        {
            root = new BinaryNode<T>(rootItem, null, null);
        }


        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public BinaryNode<T> GetRoot()
        {
            return root;
        }

        public int Size()
        {
            if (root == null)
            {
                return 0;
            }
            return root.SizeRecursive(root);

        }

        public int Height()
        {
            return HeightRecursive(root);
        }

        public int HeightRecursive(BinaryNode<T> root)
        {
            int lh;
            int rh;

            if (root == null)
            {
                return -1;
            }
            else
            {
                lh = HeightRecursive(root.left);
                rh = HeightRecursive(root.right);
                if (lh > rh) return 1 + lh;
                else return 1 + rh;
            }
        }

        public void MakeEmpty()
        {
            root = null;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public void Merge(T rootItem, BinaryTree<T> t1, BinaryTree<T> t2)
        {

            if (t1.root == t2.root && t1.root != null)
            {
                throw new System.Exception();
            }

            root = new BinaryNode<T>(rootItem, t1.root, t2.root);

            if (this != t1)
            {
                t1.root = null;
            }
            if (this != t2)
            {
                t2.root = null;
            }
        }

        public string ToPrefixString()
        {
            if (root == null)
            {
                return "NIL";
            }
            else
            {
                return root.PrefixRec(root);
            }
        }

        public string ToInfixString()
        {
            if (root == null)
            {
                return "NIL";
            }
            return root.InfixRec(root);
        }

        public string ToPostfixString()
        {
            if (root == null)
            {
                return "NIL";
            }
            return root.PostfixRec(root);
        }


        //----------------------------------------------------------------------
        // Interface methods : methods that have to be implemented for homework
        //----------------------------------------------------------------------

        public int NumberOfLeaves()
        {
            if (root == null)
            {
                return 0;
            }
            return root.LeavesRec(root);
        }

        public int NumberOfNodesWithOneChild()
        {
            if (root == null)
            {
                return 0;
            }
            return root.OneChildRec(root);
        }

        public int NumberOfNodesWithTwoChildren()
        {
            if (root == null)
            {
                return 0;
            }
            return root.TwoChildRec(root);
        }
    }
}