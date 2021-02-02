using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class BinarySearchOnReverseSortedArray
    {
        public void Main()
        {
            int[] arr = { 20, 19, 12, 11, 10, 6, 5, 4, 3, 2, 1 };
            int num = 4;
            int returnedIndex = BinarySearchIndex(arr, 0, arr.Length - 1, num);
            Console.WriteLine("The returned index is {0}",returnedIndex);
        }
        public static int BinarySearchIndex(int[] arr,int low,int high,int num)
        {
            if (low <= high)
            {
                int mid = low + ((high - low) / 2);
                if (arr[mid] == num)
                    return mid;
                if (arr[mid] > num)
                    return BinarySearchIndex(arr, mid + 1, high, num);
                return BinarySearchIndex(arr, low, mid - 1, num);
            }
            return -1;
        }
    }
}
