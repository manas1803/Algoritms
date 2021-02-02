using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class NumberOfTimesArrayIsRotated
    {
        public void Main()
        {
            int[] arr = { 11, 12, 15, 18, 2, 5, 6, 8 };
            int index = ReturnIndex(arr, 0, arr.Length - 1);
            Console.WriteLine("Number of times array is rotated is {0}",index);
        }
        public static int ReturnIndex(int[] arr,int low,int high)
        {
            int n = arr.Length;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int next = (mid + 1) % n;
                int prev = (mid - 1 + n) % n;
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
