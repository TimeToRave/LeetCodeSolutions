using System.Collections.Generic;
using System.Linq;

namespace LeetCodeSolutions
{
    /// <summary>
    /// Top K Frequent Solution
    /// <see ref="https://leetcode.com/problems/top-k-frequent-elements/description/"/>
    /// </summary>
    public class TopKFrequentSolution
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
           return nums.GroupBy(num => num)
                .Select(num => new { index = num.Key, count = num.Count() })
                .OrderByDescending(x => x.count)
                .Take(k)
                .Select(t => t.index)
                .ToArray();
        }

        public int[] TopKFrequentIterator(int[] nums, int k)
        {
            var frequencyRating = new Dictionary<int, int>();

            foreach (int number in nums)
            {
                if (frequencyRating.ContainsKey(number)) {
                    frequencyRating[number]++;
                } else {
                    frequencyRating.Add(number, 1);
                }
            }

            return frequencyRating.OrderByDescending(x => x.Value).Take(k).Select(t => t.Key).ToArray();
        }
    }
}
