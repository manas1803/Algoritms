using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class SearchingInANearlySortedArray
    {
        public void Main()
        {
            int[] arr = { 7, 6, 8, 9, 45, 34, 78, 67, 90 };
            int num = 7;
            int resultIndex = ReturnIndex(arr, 0, arr.Length - 1, num);
            Console.WriteLine("The index at which the number is present for nearly sorted array is {0}", resultIndex);
        }
        public static int ReturnIndex(int[] arr,int low,int high,int num)
        {
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == num)
                    return mid;
                else if (arr[mid - 1] == num && mid - 1 >= low)
                    return mid - 1;
                else if (arr[mid + 1] == num && mid + 1 <= low)
                    return mid + 1;
                else if (arr[mid - 1] < num && arr[mid] < num)
                    low = mid + 2;
                else if (arr[mid + 1] > num && arr[mid] > num)
                    high = mid - 2;
            }
            return -1;
        }
    }
}
