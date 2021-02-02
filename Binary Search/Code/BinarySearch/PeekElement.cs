using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearch
{
    class PeekElement
    {
        public void Main()
        {

        }
        public static int ReturnIndexOfPeekElement(int[] arr)
        {
            int low = 0;
            int high = arr.Length - 1;
            int n = arr.Length - 1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if(mid!=0 && mid !=n)
                {
                    if (arr[mid] > arr[mid + 1] && arr[mid] > arr[mid - 1])
                        return mid;
                    else if (arr[mid] < arr[mid + 1])
                        low = mid + 1;
                    else if (arr[mid] < arr[mid - 1])
                        high = mid - 1;
                }
                else if (mid == 0)
                {
                    if (arr[0] > arr[1])
                        return 0;
                    else
                        return 1;
                }
                else if (mid == n)
                {
                    if (arr[n] > arr[n - 1])
                        return n;
                    else
                        return n - 1;
                }
            }
            return -1;
        }
    }
}
