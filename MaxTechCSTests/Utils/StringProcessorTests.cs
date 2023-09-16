using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaxTechCS.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxTechCS.Data.Enum;

namespace MaxTechCS.Utils.Tests
{
    [TestClass()]
    public class StringProcessorTests
    {
        [TestMethod()]
        [DataRow("a", "aa")]
        [DataRow("abcdef", "cbafed")]
        [DataRow("abcde", "edcbaabcde")]
        public void GetProcessedStringTest(string input, string expected)
        {
            var actual = StringProcessor.GetProcessedString(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow("AAAAaaa")]
        [DataRow("a1")]
        [DataRow("a1234567890Z./")]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckStringIsInvalidTest(string input) 
        {
            StringProcessor.CheckString(input);
        }

        [TestMethod()]
        [DataRow("abcdefghijklmnopqrstuvwxyz")]
        public void CheckStringIsValidTest(string input)
        {
            StringProcessor.CheckString(input);
        }

        [TestMethod()]
        public void GetCharsCountTest()
        {
            var input = "ababcececee";
            var expected = new Dictionary<char, int>()
            {
                { 'a', 2 },
                { 'b', 2 },
                { 'c', 3 },
                { 'e', 4 }
            };

            var actual = StringProcessor.GetCharsCount(input);

            var isDictionariesEqual = actual.Count == expected.Count && !actual.Except(expected).Any();

            Assert.IsTrue(isDictionariesEqual);
        }

        [TestMethod()]
        [DataRow("aa", "aa")]
        [DataRow("cbafed", "afe")]
        [DataRow("edcbaabcde", "edcbaabcde")]
        [DataRow("ccccccccccc", "")]
        [DataRow("ccccccccccca", "a")]
        public void GetLongestSubstringTest(string input, string expected)
        {
            var actual = StringProcessor.GetLongestSubstring(input);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GetSortedStringInvalidSortTypeTest()
        {
            StringProcessor.GetSortedString("a", 2131);
        }

        [TestMethod()]
        [DataRow("aaccbbafg", "aaabbccfg", (int)SortType.Quicksort)]
        [DataRow("aaccbbafg", "aaabbccfg", (int)SortType.TreeSort)]
        [DataRow("cba", "abc", (int)SortType.Quicksort)]
        [DataRow("cba", "abc", (int)SortType.TreeSort)]
        [DataRow("ccab", "abcc", (int)SortType.Quicksort)]
        [DataRow("ccab", "abcc", (int)SortType.TreeSort)]
        public void GetSortedStringInvalidSortType(string input, string expected, int sortType)
        {
            var actual = StringProcessor.GetSortedString(input, sortType);

            Assert.AreEqual(expected, actual);
        }
    }
}