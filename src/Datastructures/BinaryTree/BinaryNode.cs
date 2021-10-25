namespace AD
{
    public partial class BinaryNode<T> : IBinaryNode<T>
    {
        public T data;
        public BinaryNode<T> left;
        public BinaryNode<T> right;

        public BinaryNode() : this(default(T), default(BinaryNode<T>), default(BinaryNode<T>)) { }

        public BinaryNode(T data, BinaryNode<T> left, BinaryNode<T> right)
        {
            this.data = data;
            this.left = left;
            this.right = right;
        }

        //----------------------------------------------------------------------
        // Interface methods that have to be implemented for exam
        //----------------------------------------------------------------------
        public T GetData()
        {
            return data;
        }

        public BinaryNode<T> GetLeft()
        {
            return left;
        }

        public BinaryNode<T> GetRight()
        {
            return right;
        }

        public int SizeRecursive(BinaryNode<T> data)
        {
            if (data == null)
            {
                return 0;
            }
            else
            {
                return 1 + SizeRecursive(data.left) + SizeRecursive(data.right);
            }
        }

        public string PrefixRec(BinaryNode<T> data)
        {
            if(data == null)
            {
                return "NIL";
            }
            return "[ " + data.data.ToString() + " " + PrefixRec(data.left) + " " + PrefixRec(data.right) + " ]";
        }
        public string InfixRec(BinaryNode<T> data)
        {
            if (data == null)
            {
                return "NIL";
            }
            return "[ " + InfixRec(data.left) + " " + data.data.ToString() + " " + InfixRec(data.right) + " ]";
        }

        public string PostfixRec(BinaryNode<T> data)
        {
            if (data == null)
            {
                return "NIL";
            }
            return "[ " + PostfixRec(data.left) + " " + PostfixRec(data.right) + " " + data.data.ToString() + " ]";
        }

        public int LeavesRec(BinaryNode<T> data) 
        {
                if(data == null) {
                    return 0;
                }
                if(data.left == null && data.right == null) {
                    return 1;
                }
                return LeavesRec(data.left) + LeavesRec(data.right);
        }

        public int OneChildRec(BinaryNode<T> data) 
        {
                if(data == null) {
                    return 0;
                }
                if((data.left == null && data.right != null) || data.left != null && data.right == null) {
                    return 1;
                }
                return OneChildRec(data.left) + OneChildRec(data.right);
        }
        public int TwoChildRec(BinaryNode<T> data)
        {
                if(data == null) 
                {
                    return 0;
                }
                if(data.left != null && data.right != null) 
                {
                    return 1 + TwoChildRec(data.left) + TwoChildRec(data.right);
                }
                return TwoChildRec(data.left) + TwoChildRec(data.right);
        }
    }
}