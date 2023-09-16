using MaxTechCS.Data.Dto;

namespace MaxTechCS.Utils
{
    public static class StringProcessor
    {
        public static ProcessedStringDto ProcessString(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("Input is null");
            }
            CheckString(input);
            var resultString = GetProcessedString(input);
            var resultStringCharsCount = GetCharsCount(resultString);
            return new ProcessedStringDto()
            {
                Result = resultString,
                CharsCount = resultStringCharsCount
            };
        }

        private static string GetProcessedString(string input)
        {
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

        private static void CheckString(string input)
        {
            var allowedSymbols = "abcdefghijklmnopqrstuvwxyz";
            foreach (var inputChar in input)
            {
                if (!allowedSymbols.Contains(inputChar))
                {
                    throw new ArgumentException("Input string is not allowed");
                }
            }
        }

        private static Dictionary<char, int> GetCharsCount(string input) 
        {
            var result = new Dictionary<char, int>();
            foreach (var symbol in input) 
            {
                if (result.ContainsKey(symbol))
                {
                    result[symbol]++;
                }
                else 
                {
                    result.Add(symbol, 1);
                }
            }
            return result;
        }
    }
}
