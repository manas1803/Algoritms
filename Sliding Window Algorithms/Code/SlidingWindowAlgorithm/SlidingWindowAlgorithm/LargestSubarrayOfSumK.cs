using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindowAlgorithm
{
    class LargestSubarrayOfSumK
    {
        public void Main()
        {
            int[] arr = { 4, 1, 1, 1, 2, 3, 5 };
            int ans = ReturnSubArraySize(arr, arr.Length, 9);
            Console.WriteLine(ans);
        }
        public int ReturnSubArraySize(int[] arr,int n,int k)
        {
            int max = int.MinValue;
            int i = 0, j = 0;
            long sum = 0;
            while (j < n)
            {
                sum += arr[j];
                if (sum < k)
                {
                    j++;
                }
                else if (sum == k)
                {
                    max = Math.Max(max,j-i+1);
                    j++;
                }
                else if (sum > k)
                {
                    while (sum > k)
                    {
                        sum -= arr[i];
                        i++;
                    }
                    j++;
                }
            }
            return max;

        }
    }
}
