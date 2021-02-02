using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class NextAlphabeticalElement
    {
        public void Main()
        {
            char[] arr = {'a','b','e','f','h','i'};
            char c = 'f';
            int resultIndex = ReturnIndex(arr,0, arr.Length - 1, c);
            Console.WriteLine("The character next to f in this array is {0}", arr[resultIndex]);
        }
        public static int ReturnIndex(char[] arr,int low,int high,char c)
        {
            int result = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] == c)
                {
                    low = mid + 1;
                }
                else if (arr[mid] > c)
                {
                    result = mid;
                    high = mid - 1;
                }
                else if (arr[mid] < c)
                {
                    low = mid + 1;
                }
            }
            return result;
        }
    }
}
