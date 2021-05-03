using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindowAlgorithm
{
    class MaximumOfAllSubArraysOfSizeK
    {
        public void Main()
        {
            int[] arr = { 1, 3, -1, -3, 5, 3, 6, 7 };
            List<int> result = ReturnMaxinSubArray(arr, arr.Length, 3);
            foreach(int i in result)
                Console.WriteLine(i);
        }
        public List<int> ReturnMaxinSubArray(int[] arr,int n,int k)
        {
            List<int> res = new List<int>();
            int i = 0, j = 0;
            List<int> containsMax = new List<int>();
            while (j < n)
            {
                while(containsMax.Count>0 && arr[j] > containsMax[0])
                {
                    containsMax.RemoveAt(0);
                }
                containsMax.Add(arr[j]);
                if (j - i + 1 < k)
                    j++;
                else if (j - i + 1 == k)
                {
                    res.Add(containsMax[0]);
                    if (arr[i] == containsMax[0])
                    {
                        containsMax.RemoveAt(0);
                    }
                    i++;
                    j++;
                }
            }
            return res;
        }
    }
}
