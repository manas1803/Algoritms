using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class MinimumDifferenceElementinArray_Ceil_Floor_Another_Method_
    {
        public void Main()
        {
            int[] arr = { 2, 5, 8, 12, 15, 18, 23, 45, 56, 67, 78, 89 };
            int num = 50;
            int result = ReturnValue(arr, 0, arr.Length - 1, num);
            Console.WriteLine("The minimum difference element in the array is {0}",result);
        }
        public static int ReturnValue(int[] arr,int low,int high,int num)
        {
            int floor = 0;
            int ceil = 0;
            int result = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == num)
                    result = arr[mid];
                else if (arr[mid] < num)
                    low = mid + 1;
                else if (arr[mid] > num)
                    high = mid - 1;
            }
            floor = high;
            ceil = low;
            if (result == -1)
            {
                if(Math.Abs(arr[floor] - num)>Math.Abs(arr[ceil] - num))
                {
                    result = arr[ceil];
                }
                else
                {
                    result = arr[floor];
                }
            }
            return result;
        }
    }
}
