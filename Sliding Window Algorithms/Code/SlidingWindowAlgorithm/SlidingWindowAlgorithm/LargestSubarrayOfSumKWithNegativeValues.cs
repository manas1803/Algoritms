using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindowAlgorithm
{
    class LargestSubarrayOfSumKWithNegativeValues
    {
        public void Main()
        {
            int[] arr = { 4, 1, 1, 1, 2, 3, 5 };
            int ans = ReturnSubArraySize(arr, arr.Length, 5);
            Console.WriteLine(ans);
        }
        public int ReturnSubArraySize(int[] arr,int n,int k)
        {
            int max = int.MinValue;
            Dictionary<int, int> map = new Dictionary<int, int>();
            int sum = 0;
            for(int i = 0; i < n; i++)
            {
                sum += arr[i];
                if (sum == k)
                {
                    max = i + 1;
                }
                if (!map.ContainsKey(sum))
                {
                    map.Add(sum, i);
                }
                if (map.ContainsKey(sum - k))
                {
                    if (max < i - map[sum - k])
                        max = i - map[sum - k];
                }
            }
            return max;
        }
    }
}
