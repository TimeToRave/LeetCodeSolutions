using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeSolutions
{
    /// <summary>
    /// 242. Valid Anagram
    /// <see ref="https://leetcode.com/problems/valid-anagram/"/>
    /// </summary>
    class ValidAnagramSolution
    {
        /// <summary>
        /// Single Dictionary solution
        /// </summary>
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;

            Dictionary<char, int> symbolsCount = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!symbolsCount.ContainsKey(s[i])) {
                    symbolsCount.Add(s[i], 0);
                }

                if (!symbolsCount.ContainsKey(t[i])) {
                    symbolsCount.Add(t[i], 0);
                }

                if (symbolsCount.ContainsKey(s[i]))
                {
                    symbolsCount[s[i]]++;
                }
                if (symbolsCount.ContainsKey(t[i]))
                {
                    symbolsCount[t[i]]--;
                }
            }

            foreach (var symbol in symbolsCount)
            {
                if (symbol.Value != 0) return false;
            }

            return true;
        }

        /// <summary>
        /// Solution with sorting both input strings
        /// </summary>
        public bool IsAnagramViaSorting(string s, string t)
        {
            if (s.Length != t.Length) return false;

            return SortString(s).Equals(SortString(t));
        }

        /// <summary>
        /// Sorts input string as char array
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Sorted string</returns>
        static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }
    }
}
