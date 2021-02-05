using System;
using System.Collections.Generic;
using System.Text;

namespace StackAlgorithms
{
    class MaximumAreaHistogram
    {
        public void Main()
        {
            int[] arr = { 6, 2, 5, 4, 5, 1, 6 };
            List<int> left = IndexNSL(arr, arr.Length);
            List<int> right = IndexNSR(arr, arr.Length);
            int[] result = new int[arr.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = (right[i] - left[i] - 1) * arr[i];
            }
            int max = 0;
            for(int i = 0; i < result.Length; i++)
            {
                if (result[i] > max)
                    max = result[i];
            }
            Console.WriteLine(max);
        }
        public List<int> IndexNSR(int[] arr,int n)
        {
            int pseudoIndex = n;
            List<int> li = new List<int>();
            Stack<int> st = new Stack<int>();
            for(int i = n - 1; i >= 0; i--)
            {
                if (st.Count == 0)
                {
                    li.Add(pseudoIndex);
                }
                else if(st.Count>0 && arr[st.Peek()] < arr[i])
                {
                    li.Add(st.Peek());
                }
                else if(st.Count>0 && arr[st.Peek()] >= arr[i])
                {
                    while(st.Count > 0 && arr[st.Peek()] >= arr[i])
                    {
                        st.Pop();
                    }
                    if (st.Count == 0)
                    {
                        li.Add(pseudoIndex);
                    }
                    else if (arr[st.Peek()] < arr[i])
                    {
                        li.Add(st.Peek());
                    }
                }
                st.Push(i);
            }
            li.Reverse();
            return li;
        }
        public List<int> IndexNSL(int[] arr,int n)
        {
            int pseudoIndex = -1;
            List<int> li = new List<int>();
            Stack<int> st = new Stack<int>();
            for (int i=0; i<n; i++)
            {
                if (st.Count == 0)
                {
                    li.Add(pseudoIndex);
                }
                else if (st.Count > 0 && arr[st.Peek()] < arr[i])
                {
                    li.Add(st.Peek());
                }
                else if (st.Count > 0 && arr[st.Peek()] >= arr[i])
                {
                    while (st.Count > 0 && arr[st.Peek()] >= arr[i])
                    {
                        st.Pop();
                    }
                    if (st.Count == 0)
                    {
                        li.Add(pseudoIndex);
                    }
                    else if (arr[st.Peek()] < arr[i])
                    {
                        li.Add(st.Peek());
                    }
                }
                st.Push(i);
            }
            return li;
        }
    }
}
