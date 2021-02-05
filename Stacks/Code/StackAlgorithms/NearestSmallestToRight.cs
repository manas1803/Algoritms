using System;
using System.Collections.Generic;
using System.Text;

namespace StackAlgorithms
{
    class NearestSmallestToRight
    {
        public void Main()
        {
            int[] arr = { 3, 2, 9, 4, 5, 3, 1, 2, 56 };
            List<int> li = NSR(arr, arr.Length);
            li.Reverse();
            foreach (int x in li)
                Console.WriteLine(x);
        }
        public List<int> NSR(int[] arr, int n)
        {
            List<int> li = new List<int>();
            Stack<int> st = new Stack<int>();
            for(int i = n - 1; i >= 0; i--)
            {
                if (st.Count == 0)
                    li.Add(-1);
                else if (st.Count > 0 && st.Peek() < arr[i])
                    li.Add(st.Peek());
                else if(st.Count > 0 && st.Peek() >= arr[i])
                {
                    while (st.Count > 0 && st.Peek() >= arr[i])
                        st.Pop();
                    if (st.Count == 0)
                        li.Add(-1);
                    else if (st.Peek() < arr[i])
                        li.Add(st.Peek());
                }
                st.Push(arr[i]);
            }
            return li;
        }
    }
}
