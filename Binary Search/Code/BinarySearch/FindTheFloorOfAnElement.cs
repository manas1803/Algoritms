using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class FindTheFloorOfAnElement
    {
        public void Main()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 34, 45, 67, 78, 90 };
            int num = 40;
            int resultIndex = ReturnIndex(arr, 0, arr.Length - 1, num);
            Console.WriteLine("The number which is floor of 40 in given list is {0}", resultIndex);
        }

        public static int ReturnIndex(int[] arr,int low,int high,int num)
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
                    result = arr[mid];
                    low = mid + 1;
                }
                else if (arr[mid] > num)
                {
                    high = mid - 1;
                }
            }
            return result;
        }
    }
}
