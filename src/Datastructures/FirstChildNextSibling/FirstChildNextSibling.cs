namespace AD
{
    public partial class FirstChildNextSibling<T> : IFirstChildNextSibling<T>
    {
        public FirstChildNextSiblingNode<T> root;

        public IFirstChildNextSiblingNode<T> GetRoot()
        {
            return root;
        }

        public int Size()
        {
            return CountNode(root);
        }

        public void PrintPreOrder()
        {
            System.Console.WriteLine(PrintNode(root));
        }

        public string PrintNode(FirstChildNextSiblingNode<T> root)
        {
            if (root == null) return "";
            return root.data.ToString() + "\n" + PrintNode(root.firstChild) +
            PrintNode(root.nextSibling);
        }

        public int CountNode(FirstChildNextSiblingNode<T> root)
        {
            if (root == null) return 0;
            return 1 + CountNode(root.firstChild)
                     + CountNode(root.nextSibling);
        }

        public override string ToString()
        {
            if (root == null)
            {
                return "NIL";
            }
            return stringNode(root);
        }

        public string stringNode(FirstChildNextSiblingNode<T> root)
        {
            string str;
            if (root == null) return "NIL";

            str = root.data.ToString();
            if (root.firstChild != null)
            {
                str += $",FC({stringNode(root.firstChild)})";
            }
            if (root.nextSibling != null)
            {
                str += $",NS({stringNode(root.nextSibling)})";
            }
            return str;
        }

    }
}