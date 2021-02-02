using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class CountOfElementInSortedArray
    {
        public void Main()
        {
            int[] arr = { 2, 4, 10, 10, 10, 18, 20 };
            int num = 10;
            int firstOccurence = ReturnFirstOccurence(arr, 0, arr.Length - 1, num);
            int lastOccurence = ReturnLastOccurence(arr, 0, arr.Length - 1, num);
            Console.WriteLine("Count of 10 in the given array is {0}",lastOccurence-firstOccurence+1);
        }
        public static int ReturnFirstOccurence(int[] arr,int low,int high,int num)
        {
            int result = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == num)
                {
                    result = mid;
                    high = mid - 1;
                }
                else if (num<arr[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return result;
        }
        public static int ReturnLastOccurence(int[] arr, int low, int high, int num)
        {
            int result = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == num)
                {
                    result = mid;
                    low = mid + 1;
                }
                else if (num < arr[mid])
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return result;
        }
    }
}
