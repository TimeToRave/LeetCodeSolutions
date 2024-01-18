using System;
using System.Linq;

namespace LeetCodeSolutions
{
    /// <summary>
    /// 238. Product of Array Except Self
    /// <see ref="https://leetcode.com/problems/product-of-array-except-self/description/"/>
    /// </summary>
    class ProductOfArrayExceptSelfSolution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int accumulatorIncrement = 1;
            int accumulatorDecrement = 1;

            var answer = new int[nums.Length];
            Array.Fill(answer, 1);

            for (int i = 0; i < nums.Length; i++)
            {
                answer[i] *= accumulatorIncrement;
                accumulatorIncrement *= nums[i];
                answer[nums.Length - 1 - i] *= accumulatorDecrement;
                accumulatorDecrement *= nums[nums.Length - i - 1];
            }

            return answer;
        }

        public int[] ProductExceptSelfTwoCycle(int[] nums)
        {
            int accumulatorIncrement = 1;
            int accumulatorDecrement = 1;

            var result = new int[nums.Length];
            result[nums.Length - 1] = 1;

            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = accumulatorIncrement;
                accumulatorIncrement *= nums[i];
                result[nums.Length - i - 1] *= accumulatorDecrement;
                accumulatorDecrement *= nums[nums.Length - i - 1];
            }

            return result;
        }

        public int[] ProductExceptSelfNaiveSolution(int[] nums)
        {
            var result = Enumerable.Repeat(1, nums.Length).ToArray();

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i != j)
                    {
                        result[j] *= nums[i];
                    }
                }
            }

            return result;
        }
    }
}
