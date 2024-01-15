using System.Collections.Generic;
using System.Linq;

namespace LeetCodeSolutions
{
    /// <summary>
    /// https://leetcode.com/problems/contains-duplicate/
    /// </summary>
    class ContainsDuplicateSolution
    {
        public bool ContainsDuplicate(int[] nums)
        {
            var distinctNums = new HashSet<int>(nums);
            return nums.Length != distinctNums.Count;
        }

        public bool ContainsDuplicateManualHashSet(int[] nums)
        {
            var distinctNums = new HashSet<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (distinctNums.Contains(nums[i]))
                {
                    return true;
                }
                distinctNums.Add(nums[i]);
            }

            return false;
        }

        public bool ContainsDuplicateSecondSolution(int[] nums)
        {
            Dictionary<int, int> distinctNums = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (distinctNums.ContainsKey(nums[i]))
                {
                    return true;
                }
                distinctNums.Add(nums[i], i);
            }

            return false;
        }

        public bool ContainsDuplicateNaiveSolution(int[] nums)
        {
            return nums.Distinct().ToArray().Length != nums.Length;
        }
    }
}
