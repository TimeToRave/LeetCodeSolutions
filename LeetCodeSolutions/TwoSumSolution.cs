using System;
using System.Collections.Generic;

namespace LeetCodeSolutions
{
    /// <summary>
    /// 1. Two Sum Solution
    /// <see ref="https://leetcode.com/problems/two-sum/description/"/>
    /// </summary>
    class TwoSumSolution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> substractionResult = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var currentSubstractionResult = target - nums[i];

                if (substractionResult.ContainsKey(currentSubstractionResult)) {
                    return new int[] { substractionResult[currentSubstractionResult], i };
                } else {
                    substractionResult.Add(nums[i], i);
                }
            }

            return Array.Empty<int>();
        }
        public int[] TwoSumIterator(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i+1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return Array.Empty<int>();
        }
    }
}
