using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class LastOccurenecOfTheNumber
    {
        public void Main()
        {
            int[] arr = { 2,4,10,10,10,18,20};
            int num = 10;
            int resultIndex = ReturnLast(arr, 0, arr.Length - 1, num);
            Console.WriteLine("Last occurenece of 10 is {0}", resultIndex);
        }
        public static int ReturnLast(int[] arr,int low,int high,int num)
        {
            int result = -1;
            while (low <= high)
            {
                int mid = low + ((high - low) / 2);
                if (arr[mid] == num)
                {
                    result = mid;
                    low = mid + 1;
                }
                else if (arr[mid] > num)
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
