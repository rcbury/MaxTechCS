namespace MaxTechCS.Utils
{
    public class BinaryTree<T> where T: IComparable
    {
        public T NodeValue { get; set; }
        public BinaryTree<T> LeftNode { get; set; }
        public BinaryTree<T> RightNode { get; set; }
        public void Insert(T value) 
        {
            if (NodeValue.CompareTo(default(T)) == 0)
            {
                NodeValue = value;
            }
            else 
            {
                if (value.CompareTo(NodeValue) > 0)
                {
                    if (RightNode == null)
                    {
                        RightNode = new BinaryTree<T>();
                        RightNode.NodeValue = value;
                    }
                    else
                    {
                        RightNode.Insert(value);
                    }
                }
                else
                {
                    if (LeftNode == null)
                    {
                        LeftNode = new BinaryTree<T>();
                        LeftNode.NodeValue = value;
                    }
                    else
                    {
                        LeftNode.Insert(value);
                    }
                }
            }
        }

        //TODO: Пересмотреть составление массива

        public IEnumerable<T> GetSortedArray() 
        {
            IEnumerable<T> result = new List<T>() { NodeValue };
            if (LeftNode != null) 
            {
                result = LeftNode.GetSortedArray().Concat(result);
            }
            if (RightNode != null) 
            {
                result = result.Concat(RightNode.GetSortedArray());
            }
            return result;
        }
    }
}
