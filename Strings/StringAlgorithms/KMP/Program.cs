using System;
using System.Collections.Generic;

namespace KMP
{
    class Program
    {
        List<int> KMPSearch(string text,string pattern)
        {
            List<int> index = new List<int>();
            int n = text.Length;
            int m = pattern.Length;

            // Here we are creating the lps table for the pattern first
            int[] lps = CreateLpsTable(pattern, m);

            int i = 0, j = 0; // i for text and j for pattern traversal
            while (i < n)
            {
                // if pattern and text matches
                if (pattern[j] == text[i])
                {
                    // Increment both pattern and text
                    i++;j++;
                }
                // If whole pattern is reached and our j value becomes equal to pattern length
                // Then we have found the pattern in text
                if (j == m)
                {
                    // Returning the start index for text from where pattern is matching
                    index.Add((i - j));

                    // Now we need to assign a new value again to j to continue the search further

                    j = lps[j - 1];
                }
                else if (pattern[j] != text[i])
                {
                    // If the value of j!=0 i.e. we are in middle of search
                    // Then we need to assign the value of from the lps table i.e. lps[j-1]
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    // If j is 0 then in that case our pattern is not matching entirely and we need to start over
                    // Here we just make i to increment
                    else
                    {
                        i++;
                    }
                }

            }
            return index;
        }
        int[] CreateLpsTable(string pattern,int m)
        {
            // First we create an instance of array of size of pattern
            int[] lps = new int[m];
            // We declare a variable length that we use a start point so that we can have 2 pointers for checking as we will run loop from 1
            // ALso we make lps[0]=0 as it is always 0
            int len = 0;
            lps[0] = 0;
            int i = 1;
            while (i < m)
            {
                // If the character matches with the previous character(the two pointer here are i and len) so
                // We first increment length and then make value of lps[i]=len and then increment i;
                if (pattern[i] == pattern[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                // If value does not matches we have 2 cases
                else
                {
                    // Case one is that the value of len is not zero in that case we 
                    // first make value of len = lps[len-1]
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    // If the value is zero we simply assign that to lps and here only we increment i 
                    else
                    {
                        lps[i] = len;
                        i++;
                    }
                }
            }
            return lps;
        }
        static void Main(string[] args)
        {
            string txt = "ABABDABACDABABCABABABABCABAB";
            string pat = "ABABCABAB";
            List<int> li = new Program().KMPSearch(txt, pat);
            foreach (int i in li)
            {
                Console.Write("Pattern found at index " + i + " ");
            }
            Console.WriteLine();
        }
    }
}
