using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class FindCelingOfANumberInArray
    {
        public void Main()
        {
            int n = 5;
            int ans = (int)Math.Sqrt(n);
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 42, 43, 45, 67, 78, 90 };
            int num = 40;
            int resultIndex = ReturnIndex(arr, 0, arr.Length - 1, num);
            Console.WriteLine("The number which is ceiling of 40 in given list is {0}", resultIndex);
        }

        public static int ReturnIndex(int[] arr, int low, int high, int num)
        {
            int result = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (arr[mid] == num)
                {
                    result = arr[mid];
                }
                else if (arr[mid] < num)
                {
                    low = mid + 1;
                }
                else if (arr[mid] > num)
                {
                    result = arr[mid];
                    high = mid - 1;
                }
            }
            return result;
        }
    }
}
