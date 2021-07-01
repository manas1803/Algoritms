using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    class SubSetSumTopDown
    {
        public void Main()
        {
            int[] arr = { 2, 3, 8, 12 };
            int sum = 11;
            int n = 4;
            bool[,] t = new bool[n + 1, sum + 1];
            bool result = SubSetSum(arr, sum, n, t);
            Console.WriteLine("the result is {0}", result);
        }
        public bool SubSetSum(int[] arr, int sum, int n, bool[,] t)
        {
            t[0, 0] = true;
            for (int i = 1; i < sum + 1; i++)
            {
                t[0, i] = false;
            }
            for (int i = 1; i < n + 1; i++)
            {
                t[i, 0] = true;
            }
            for (int i = 1; i < n + 1; i++)
            {
                for (int j = 1; j < sum + 1; j++)
                {
                    if (arr[i - 1] <= j)
                    {
                        t[i, j] = t[i - 1, j - arr[i - 1]] || t[i - 1, j];
                    }
                    else if (arr[i - 1] > j)
                    {
                        t[i, j] = t[i - 1, j];
                    }
                }
            }
            return t[n, sum];
        }
    }
}
