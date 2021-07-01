using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    class SubSetSumRecursive
    {
        public void Main()
        {
            int[] arr = { 2, 3, 8, 12 };
            int sum = 11;
            int n = 4;
            bool[,] t = new bool[n + 1, sum + 1];
            bool result = SubSetSum(arr, sum, n, t);
            Console.WriteLine("the result is {0}",result);
        }
        public bool SubSetSum(int[] arr,int sum,int n,bool[,] t)
        {
            if (n == 0 && sum==0)
            {
                return true;
            }
            if(n==0 && sum != 0)
            {
                return false;
            }
            if(sum==0 && n != 0)
            {
                return true;
            }

            if (arr[n - 1] <= sum)
            {
                return t[n, sum] = SubSetSum(arr,sum-arr[n-1],n-1,t) || SubSetSum(arr,sum,n-1,t);
            }
            else
            {
                return t[n, sum] = SubSetSum(arr, sum, n - 1, t);
            }
        }
    }
}
