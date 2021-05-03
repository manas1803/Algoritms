using System;
using System.Collections.Generic;
using System.Text;

namespace SlidingWindowAlgorithm
{
    class CountOccurenceOfAnagramGeeksForGeeks
    {
        static int Max_Char = 256;
        public void Main()
        {
            string str = "forxxorfxdofr";
            string ptr = "for";
            int ans = ReturnCount(str, ptr, ptr.Length, str.Length);
            Console.WriteLine(ans);
        }
        public int ReturnCount(string text, string word, int k, int n)
        {
            int[] count = new int[Max_Char];
            for (int i = 0; i < k; i++)
            {
                count[word[i]]++;
            }
            for (int i = 0; i < k; i++)
            {
                count[text[i]]--;
            }
            int res = 0;
            if (isCountZero(count))
                res++;
            for (int i = k; i < n; i++)
            {
                count[text[i]]++;
                count[text[i - k]]--;

                if (isCountZero(count))
                    res++;
            }
            return res;
        }
        static bool isCountZero(int[] count)
        {
            for (int i = 0; i < count.Length; i++)
                if (count[i] != 0)
                    return false;
            return true;
        }
    }
}
