using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class FindingElementinRotatedSortedArray
    {
        public void Main()
        {
            int[] arr = { 18, 2, 5, 6, 8,11,12,15 };
            int num = 12;
            int index = ReturnMinIndex(arr, 0, arr.Length - 1);
            int firstHalfIndex = ReturnIndex(arr, 0, index - 1, num);
            int secondHalfIndex = ReturnIndex(arr, index, arr.Length-1, num);
            if (firstHalfIndex == -1 && secondHalfIndex == -1)
            {
                Console.WriteLine("Element does not exist");
            }
            else
            {
                Console.WriteLine("Element is present at index {0}",Math.Max(firstHalfIndex,secondHalfIndex));
            }

        }
        public static int ReturnIndex(int[] arr,int low,int high,int num)
        {
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == num)
                    return mid;
                else if (num > arr[mid])
                    low = mid + 1;
                else if (num < arr[mid])
                    high = mid - 1;
            }
            return -1;
        }
        public static int ReturnMinIndex(int[] arr, int low, int high)
        {
            int n = arr.Length;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int next = (mid + 1) % n;
                int prev = (mid + n - 1) % n;
                if (arr[mid] <= arr[next] && arr[mid] <= arr[prev])
                    return mid;
                else if (arr[mid] <= arr[high])
                    high = mid - 1;
                else if (arr[mid] >= arr[low])
                    low = mid + 1;
            }
            return -1;
        }
    }
}
