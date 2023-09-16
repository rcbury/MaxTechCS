using MaxTechCS.Data.Dto;
using MaxTechCS.Data.Enum;

namespace MaxTechCS.Utils
{
    public static class StringProcessor
    {
        public static ProcessedStringDto ProcessString(string input, int sortType)
        {
            if (input == null)
            {
                throw new ArgumentNullException("Input is null");
            }
            CheckString(input);
            var resultString = GetProcessedString(input);
            var resultStringCharsCount = GetCharsCount(resultString);
            var longestSubstring = GetLongestSubstring(resultString);
            var sortedString = GetSortedString(resultString, sortType);
            return new ProcessedStringDto()
            {
                Result = resultString,
                CharsCount = resultStringCharsCount,
                LongestSubstring = longestSubstring,
                SortedString = sortedString
            };
        }

        private static string GetSortedString(string input, int sortType)
        {
            if ((SortType)sortType == SortType.Quicksort)
            {
                return string.Join("", input.ToCharArray().Quicksort());
            }
            else if ((SortType)sortType == SortType.TreeSort) 
            {
                return string.Join("", input.ToCharArray().TreeSort());
            }
            throw new ArgumentException("Sort type is not allowed. 0 is for Quicksort and 1 is for Tree sort");
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

        private static string GetLongestSubstring(string input) 
        {
            var pattern = "aeiouy";
            var longestSubstringStartChar = input.SkipWhile(x => !pattern.Contains(x)).FirstOrDefault();
            if (longestSubstringStartChar == default(char)) 
            {
                return "";
            }
            var longestSubstringEndChar = input.Reverse().SkipWhile(x => !pattern.Contains(x)).FirstOrDefault();
            if (longestSubstringEndChar == default(char)) 
            {
                return longestSubstringStartChar.ToString();
            }
            var longestSubstringStartIndex = input.IndexOf(longestSubstringStartChar);
            var longestSubstringEndIndex = input.LastIndexOf(longestSubstringEndChar);
            if (longestSubstringEndIndex - longestSubstringStartIndex + 1 == input.Length) 
            {
                return input;
            }
            return input.Substring(longestSubstringStartIndex, longestSubstringEndIndex - longestSubstringStartIndex + 1);
        }
    }
}
