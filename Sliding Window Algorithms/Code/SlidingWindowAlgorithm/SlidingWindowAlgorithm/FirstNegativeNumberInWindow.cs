using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindowAlgorithm
{
    class FirstNegativeNumberInWindow
    {
        public void Main()
        {
            int[] arr = { 12,-1,-7,8,-15,30,16,18};
            int k = 3;
            List<int> result = ReturnFirstNegativeNumber(arr, arr.Length, k);
            Console.WriteLine(result);
        }
        public List<int> ReturnFirstNegativeNumber(int[] arr,int n,int k)
        {
            int start = 0;
            int end = 0;
            List<int> li = new List<int>();
            List<int> returnResult = new List<int>();
            while (end < n)
            {
                if (arr[end] < 0)
                    li.Add(arr[end]);
                if(end-start+1<k)
                    end++;
                else if(end - start + 1 == k)
                {
                    if (li.Count > 0)
                    {
                        returnResult.Add(li[0]);
                        if (li[0] == arr[start])
                        {
                            li.Remove(arr[start]);
                        }
                    }
                    else if (li.Count == 0)
                    {
                        returnResult.Add(0);
                    }
                    start++;
                    end++;
                }
            }
            return returnResult;
        }
    }
}
