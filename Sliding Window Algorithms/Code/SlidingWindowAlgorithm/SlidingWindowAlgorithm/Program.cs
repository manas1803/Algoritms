using System;

namespace SlidingWindowAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            SlidingWindowMaxInArray sw = new SlidingWindowMaxInArray();
            //sw.Main();

            FirstNegativeNumberInWindow fn = new FirstNegativeNumberInWindow();
            //fn.Main();

            CountOccurenceOfAnagramGeeksForGeeks cg = new CountOccurenceOfAnagramGeeksForGeeks();
            //cg.Main();

            MaximumOfAllSubArraysOfSizeK m = new MaximumOfAllSubArraysOfSizeK();
            //m.Main();

            LargestSubarrayOfSumK lsm = new LargestSubarrayOfSumK();
            //lsm.Main();

            LargestSubarrayOfSumKWithNegativeValues lss = new LargestSubarrayOfSumKWithNegativeValues();
            lss.Main();
        }
    }
}
