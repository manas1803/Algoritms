using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicProgramming
{
    class Knapsack01TopDown
    {
        public void Main()
        {
            int[] wt = { 10, 20, 30 };
            int[] val = { 60, 100, 120 };
            int W = 50;
            int n = 3;
            int[,] t = new int[n+1,W+1];
            int result = Knapsack(wt, val, W, n,t);
            Console.WriteLine("The result for the knapsack problem is {0}", result);

        }
        public int Knapsack(int[] wt,int[] val,int W,int n,int[,] t)
        {
            for(int i = 0; i < n + 1; i++)
            {
                for (int w = 0; w < W + 1; w++)
                {
                    if (i == 0 || w == 0)
                    {
                        t[i, w] = 0;
                    }
                    else
                    {
                        if (wt[i - 1] <= w)
                        {
                            t[i, w] = Math.Max(val[i-1] + t[i-1,w-wt[i-1]],t[i-1,w]);
                        }
                        else
                        {
                            t[i, w] = t[i - 1, w];
                        }
                    }
                }
            }
            return t[n,W];
        }
    }
}
