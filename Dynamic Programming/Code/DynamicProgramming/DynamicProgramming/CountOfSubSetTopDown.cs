using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    class CountOfSubSetTopDown
    {
        public void Main()
        {
            int[] arr = { 2,3,5,6,8,10 };
            int sum = 10;
            int n = arr.Length;
            int result = CountOfSubset(arr, sum, n);
            Console.WriteLine("The count of the subsets is {0}",result);
        }
        public int CountOfSubset(int[] arr,int sum,int n)
        {
            int[,] t = new int[n+1, sum+1];
            for(int i = 0; i < n + 1; i++)
            {
                t[i, 0] = 1;
            }
            for(int i = 1; i < sum + 1; i++)
            {
                t[0, i] = 0;
            }

            for(int size = 1; size < n + 1; size++)
            {
                for(int sm = 1; sm < sum + 1; sm++)
                {
                    if (arr[size - 1] <= sm)
                    {
                        t[size, sm] = t[size - 1, sm] + t[size - 1, sm - arr[size - 1]];
                    }
                    else if (arr[size - 1] > sm)
                    {
                        t[size, sm] = t[size - 1, sm];
                    }
                }
            }
            return t[n, sum];
        }
    }
}
