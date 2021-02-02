using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class IndexOfFirst1InBinaryInfiniteArray
    {
        public void Main()
        {
            int[] arr = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            int num = 1;
            int low = 0;
            int high = 1;
            while (num > arr[high])
            {
                low = high;
                high *= 2;
            }
            int index = ReturnIndex(arr, low, high, num);
            Console.WriteLine("The index of the first occurence of 1 in the binary sorted infifnite array is {0}", index);
        }
        public static int ReturnIndex(int[] arr, int low, int high, int num)
        {
            int result = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == num)
                {
                    result = mid;
                    high = mid - 1;
                }

                else if (arr[mid] < num)
                {
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
