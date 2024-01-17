using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeSolutions
{
    /// <summary>
    /// Group Anagram solution
    /// <see ref="https://leetcode.com/problems/group-anagrams/description/"/>
    /// </summary>
    public class GroupAnagramsSolution
    {
        /// <summary>
        /// Optimized solution
        /// </summary>
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            //IList<IList<string>> groups = new List<IList<string>>();
            Dictionary<string, List<string>> groupsWithSortedWord = new Dictionary<string, List<string>>();

            for (int i = 0; i < strs.Length; i++)
            {
                string sortedStr = SortString(strs[i]);

                if (groupsWithSortedWord.ContainsKey(sortedStr))
                {
                    groupsWithSortedWord[sortedStr].Add(strs[i]);
                }
                else
                {
                    groupsWithSortedWord.Add(sortedStr, new List<string>() { strs[i] }); ;
                }
            }

            return groupsWithSortedWord.Values.Select(x => x).ToArray();
        }

        /// <summary>
        /// Worst solution ever
        /// </summary>
        public IList<IList<string>> GroupAnagramsWorst(string[] strs)
        {
            IList<IList<string>> groups = new List<IList<string>>();
            groups.Add(new List<string>() { strs[0] });
            bool isNeedToCreateNewGroup = true;

            for (int i = 1; i < strs.Length; i++)
            {
                for (int j = 0; j < groups.Count; j++)
                {
                    if (groups[j][0].Length == strs[i].Length && SortString(groups[j][0]).Equals(SortString(strs[i])))
                    {
                        groups[j].Add(strs[i]);
                        isNeedToCreateNewGroup = false;
                        break;
                    }
                }

                if (isNeedToCreateNewGroup)
                {
                    groups.Add(new List<string>() { strs[i] });
                }
                isNeedToCreateNewGroup = true;
            }

            return groups;
        }

        private string SortString(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Sort(chars);
            return new string(chars);
        }
    }
}
