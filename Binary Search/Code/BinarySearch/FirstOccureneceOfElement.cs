using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class FirstOccureneceOfElement
    {
        public void Main()
        {
            int[] arr = { 0,0,0,0,0,0,0,1,1,1,1,1,1,1,1};
            int num = 1;
            int resultIndex = BinaryIndex(arr, 0, arr.Length - 1, num);
            Console.WriteLine("First occurenece of 1 is {0}",resultIndex);
        }
        public static int BinaryIndex(int[] arr,int low,int high,int num)
        {
            int result = -1;
            while (low <= high)
            {
                int mid = low + ((high - low) / 2);
                if (arr[mid] == num)
                {
                    result = mid;
                    high = mid - 1;
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
