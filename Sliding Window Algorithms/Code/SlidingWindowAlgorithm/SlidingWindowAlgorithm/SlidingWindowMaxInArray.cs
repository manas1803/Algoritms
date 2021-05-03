using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindowAlgorithm
{
    class SlidingWindowMaxInArray
    {
        public void Main()
        {
            int[] arr = {2,5,8,12,3,23,65,69,1,6};
            int k = 4;
            int max = ReturnMaxInWindow(arr, k, arr.Length);
            Console.WriteLine(max);
        }
        public int ReturnMaxInWindow(int[] arr,int k,int size)
        {
            int start=0,end = 0;
            int sum = 0;
            int max = int.MinValue;
            while (end < size)
            {
                sum += arr[end];
                if (end - start + 1 < k)
                {
                    end++;
                }
                else if (end - start + 1 == k)
                {
                    max = ReturnMax(max, sum);
                    sum -= arr[start];
                    start++;
                    end++;
                }
            }
            return max;
        }
        public int ReturnMax(int a ,int b)
        {
            if (a > b)
                return a;
            return b;
        }
    }
}
