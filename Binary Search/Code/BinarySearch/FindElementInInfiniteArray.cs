using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class FindElementInInfiniteArray
    {
        public void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14,15,16,17,18,19,20};
            int num = 6;
            int low = 0;
            int high = 1;
            while (num > arr[high])
            {
                low = high;
                high *= 2;
            }
            int index = ReturnIndex(arr, low, high, num);
            Console.WriteLine("The index of the element in the infifnite array is {0}",index);
        }
        public static int ReturnIndex(int[] arr,int low,int high,int num)
        {
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == num)
                    return mid;
                else if (arr[mid] < num)
                {
                    low = mid + 1;
                }
                else if (arr[mid] > num)
                {
                    high = mid - 1;
                }
            }
            return -1;
        }
    }
}
