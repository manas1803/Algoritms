using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class BasicBS
    {
        public void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 34, 45, 67, 78, 90 };
            int num = 45;
            int resultIndex = BinarySearchResult(arr, 0, arr.Length - 1, num);
            Console.WriteLine("The index at which the number is present is {0}",resultIndex);
        }
        public static int BinarySearchResult(int[] arr,int low,int high,int num)
        {
            if (low <= high)
            {
                int mid = low + ((high - low) / 2);
                if (arr[mid] == num)
                    return mid;
                if (arr[mid] > num)
                    return BinarySearchResult(arr, low, mid-1, num);
                return BinarySearchResult(arr, mid+1, high, num);
            }
            return -1;
        }
    }
}
