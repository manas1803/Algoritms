using System;
using System.Collections.Generic;

namespace ZAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string txt = "ABABDABACDABABCABABABABCABAB";
            string pat = "ABABCABAB";
            List<int> li = new Program().ZFunction(txt, pat);
            foreach(int i in li)
            {
                Console.Write("Pattern found at index " + i + " ");
            }
            Console.WriteLine();
        }
        
        List<int> ZFunction(string text,string pattern)
        {
            // This is to store all the indexes returned from Z array
            List<int> li = new List<int>();

            // We are creating a new String by adding a new character in between mainly $
            string newString = pattern + "$" + text;

            // Length checker for checking the pattern length and matching with Z array value
            int lengthCheck = pattern.Length;

            // Getting Z Array here
            int[] Z = CreateZArray(newString);

            // Now here we are adding the values to list and returning it.
            for(int i = 0; i < Z.Length; i++)
            {
                if (Z[i] == lengthCheck)
                {
                    li.Add(i - lengthCheck - 1);
                }
            }
            return li;
        }
        int[] CreateZArray(string text)
        {
            // Creating a blank array for Z values
            int n = text.Length;
            int[] Z = new int[n];

            // Z of 0 is not required so making it 0 and also defining the left and right
            // for the Z box
            Z[0] = 0;
            int left = 0;
            int right = 0;

            for(int i = 1; i < n; i++)
            {
                // First we check if the right values are coming again so that we can simply copy then or not
                // If not then i> right and we will go inside the loop
                if (i > right)
                {
                    // Here inside first we make all equal to i(boith right and left)
                    left = right = i; ;

                    // Here we are checking if right is out of bound or not and also
                    // If the values of the first index is equal to next.
                    // We make use of 2 variables to slide the window further in this while loop
                    while(right<n && text[right]==text[right-left])
                    {
                        right++;
                    }
                    // After this we make the value of Z array equal to right - left and then decrement the right
                    Z[i] = right - left;
                    right--;
                }
                // If the above condition fails i.e. we got the right value greater so the values are repeating now
                else
                {
                    // First we create a variable that is equal to the first repeating value from start
                    // Whose Z value is already calculated.
                    // This will be equal to i-left
                    int k = i - left;
                    // Here we check if that value is going out of bound or not
                    // The check is done by simply checking the Z value of that repeating character with the window
                    // of the Z box if its greater than that then we need to do the checking again
                    if (Z[k] < right - i + 1)
                    {
                        // This check if passes we simply copy those values
                        Z[i] = Z[k];
                    }
                    // If value exceeds the bound then we simply check again by changing the Z box
                    // This is done by making the left == i and thus we do the checking again as before
                    else
                    {
                        left = i;
                        while (right < n && text[right] == text[right - left])
                        {
                            right++;
                        }
                        Z[i] = right - left;
                        right--;
                    }
                }
            }
            return Z;
        }
        
    }
}
