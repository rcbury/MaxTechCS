namespace MaxTechCS.Utils
{
    public static class CharArrayExtensions
    {
        public static IEnumerable<char> Quicksort(this IEnumerable<char> arr) 
        {
            if (arr.Count() <= 1) 
            {
                return arr;
            }

            var startChar = arr.First();
            var leftArray = arr.Where(x => x < startChar);
            var centerArray = arr.Where(x => x == startChar);
            var rightArray = arr.Where(x => x > startChar);
            return leftArray.Quicksort().Concat(centerArray).Concat(rightArray.Quicksort());
        }

        public static IEnumerable<char> TreeSort(this IEnumerable<char> arr) 
        {
            var tree = new BinaryTree<char>();
            foreach (var item in arr) 
            {
                tree.Insert(item);
            }
            var res = tree.GetSortedArray();
            return res;
        }
    }
}
