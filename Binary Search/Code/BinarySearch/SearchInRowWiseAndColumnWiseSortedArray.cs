using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class SearchInRowWiseAndColumnWiseSortedArray
    {
        public void Main()
        {
            int[,] arr = { { 10, 20, 30, 40 }, { 15, 25, 35, 45 }, { 27, 29, 37, 45 }};
            int m = arr.GetLength(0);
            int n = arr.GetLength(1);
            int[] result = ReturnIndex(arr,m,n,29);
            Console.WriteLine(result[0] + " and " + result[1]);
        }
        public int[] ReturnIndex(int[,] arr,int m,int n,int target)
        {
            int[] result = new int[2];
            result[0] = -1;
            result[1] = -1;
            int i = 0;
            int j = m - 1;
            while(i>=0 && i<m && j>=0 && j < n)
            {
                if (arr[i, j] == target)
                {
                    result[0] = i;
                    result[1] = j;
                    break;
                }
                else if (arr[i, j] > target)
                {
                    j--;
                }
                else if (arr[i, j] < target)
                {
                    i++;
                }
            }
            return result;
        }
    }
}
