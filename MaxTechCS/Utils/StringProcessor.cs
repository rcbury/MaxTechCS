namespace MaxTechCS.Utils
{
    public static class StringProcessor
    {
        public static string ProcessString(string input) 
        {
            if (input == null) 
            {
                throw new ArgumentNullException("Input is null");
            }
            var allowedSymbols = "abcdefghijklmnopqrstuvwxyz";
            foreach (var inputChar in input) 
            {
                if (!allowedSymbols.Contains(inputChar)) 
                {
                    throw new ArgumentException("Input string is not allowed");
                }
            }
            if (input.Length % 2 != 0)
            {
                var revCharArr = input.Reverse();
                return string.Join("", revCharArr.Concat(input.ToCharArray()));
            }
            else 
            {
                var sequenceLength = input.Length / 2;
                var firstSequence = input.Substring(0, sequenceLength).Reverse();
                var secondSequence = input.Substring(sequenceLength, sequenceLength).Reverse();
                return string.Join("", firstSequence.Concat(secondSequence));
            }
        }
    }
}
