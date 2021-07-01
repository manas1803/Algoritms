using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    class EqualSumPartitionTopDown
    {
        public void Main()
        {
            int[] arr = { 5, 1, 5, 11 };
            int n = arr.Length;
            bool result = EqualSumPartition(arr,n);
            Console.WriteLine("The result for the above is {0}",result);
        }
        public bool EqualSumPartition(int[] arr,int n)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
                sum += arr[i];
            if (sum % 2 != 0)
            {
                return false;
            }
            else
            {
                sum /= 2;
                bool[,] t = new bool[n+1, sum+1];
                
                // Now here we write code for subset sum //

                for(int i = 0; i < n + 1; i++)
                {
                    t[i, 0] = true;
                }
                for(int i = 1; i < sum + 1; i++)
                {
                    t[0, i] = false;
                }
                for(int i = 1; i < n + 1; i++)
                {
                    for (int j = 1; j < sum + 1; j++)
                    {
                        if (arr[i-1] <= j)
                        {
                            t[i, j] = t[i - 1, j - arr[i - 1]] || t[i - 1, j];
                        }
                        else
                        {
                            t[i, j] = t[i - 1, j];
                        }
                    }
                }
                return t[n, sum];
            }
        }
    }
}
