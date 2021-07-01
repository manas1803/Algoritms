using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    class Knapsack01Recursive
    {
        public static int[,] t = new int[4,51];
        public void Main()
        {
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 51; j++)
                {
                    t[i, j] = -1;
                }
            }
            int[] wt = { 10, 20, 30 };
            int[] val = { 60, 100, 120 };
            int W = 50;

            int result = Knapsack(wt, val, W, 3);
            Console.WriteLine("The result for the knapsack problem is {0}",result);

        }
        public int Knapsack(int[] wt,int[] val,int W,int n)
        {
            if(n==0 || W == 0)
            {
                return 0;
            }
            if (t[n, W] != -1)
            {
                return t[n, W];
            }
            if (wt[n - 1] <= W)
            {
                return t[n, W] = Math.Max(val[n-1]+Knapsack(wt,val,W-wt[n-1],n-1), Knapsack(wt, val, W, n - 1));
            }
            else
            {
                return t[n, W] = Knapsack(wt, val, W, n - 1);
            }
        }
    }
}
