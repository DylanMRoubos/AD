namespace AD
{
    public partial class BinarySearchTree<T> : BinaryTree<T>, IBinarySearchTree<T>
        where T : System.IComparable<T>
    {

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------

        public void Insert(T x)
        {
            root = InsertRec(root, x);
        }

        public BinaryNode<T> InsertRec(BinaryNode<T> r, T x)
        {
            //No root exists yet
            if (r == null)
            {
                r = new BinaryNode<T>
                {
                    data = x,
                };
            }
            //Check if x item is < root -> left node
            else if (x.CompareTo(r.data) < 0)
            {
                r.left = InsertRec(r.left, x);
            }
            //Check if x item is > root -> right node
            else if (x.CompareTo(r.data) > 0)
            {
                r.right = InsertRec(r.right, x);
            }
            else
            {
                throw new BinarySearchTreeDoubleKeyException();
            }
            return r;
        }


        public void RemoveMin()
        {
            if (root == null) throw new BinarySearchTreeEmptyException();
            //check if only root item exists
            root = RemoveMinRec(root);
        }

        public T FindMin()
        {
            if (root == null) throw new BinarySearchTreeEmptyException();
            //check if only root item exists
            return FindMinRec(root).data;
        }

        public BinaryNode<T> FindMinRec(BinaryNode<T> r)
        {
            if (r.left != null)
            {
                r = FindMinRec(r.left);
            }
            return r;
        }

        public void RemoveMin(BinaryNode<T> r)
        {
            if (root == null) throw new BinarySearchTreeEmptyException();
            root = RemoveMinRec(r);
        }

        public BinaryNode<T> RemoveMinRec(BinaryNode<T> r)
        {
            //Only the root element excists
            if (r.left != null)
            {
                r.left = RemoveMinRec(r.left);
                return r;
            }
            else
            {
                return r.right;
            }
        }

        //Check if the node exists in the three
        public bool nodeExists(BinaryNode<T> node, T data)
        {
            if (node == null)
            {
                return false;
            }

            bool found = false;

            //Check the node
            if (node.data.Equals(data))
            {
                found = true;
            }
            else
            {
                found = nodeExists(node.right, data);
                if (found == false) found = nodeExists(node.left, data);
            }

            return found;
        }

        public void Remove(T x)
        {
            if (IsEmpty() || !nodeExists(root, x)) throw new BinarySearchTreeElementNotFoundException();
            root = Remove(root, x);
        }

        private BinaryNode<T> Remove(BinaryNode<T> node, T data)
        {
            if (data.CompareTo(node.data) < 0)
            {
                node.left = Remove(node.left, data);
            }
            else if (data.CompareTo(node.data) > 0)
            {
                node.right = Remove(node.right, data);
            }
            else if (node.left != null && node.right != null)
            {
                node.data = FindMinRec(node.right).data;
                node.right = RemoveMinRec(node.right);
            }
            else
            {
                if (node.left != null)
                {
                    node = node.left;
                }
                else
                {
                    node = node.right;
                }
            }
            return node;
        }

        public string InOrder()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            if (root == null) return "";

            var text = InfixRec(root);
            return text.Remove(text.Length - 1);
        }

        public string InfixRec(BinaryNode<T> data)
        {
            if (data == null)
            {
                return "";
            }
            return InfixRec(data.left) + data.data.ToString() + " " + InfixRec(data.right);

        }


    }
}
