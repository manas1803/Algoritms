using System;
using System.Collections.Generic;
using System.Text;

namespace StackAlgorithms
{
    class NearestSmallestToLeft
    {
        public void Main()
        {
            int[] arr = { 4,5,2,10,8 };
            List<int> li = NSL(arr, arr.Length);
            foreach (int x in li)
                Console.WriteLine(x);
        } 
        public List<int> NSL(int[] arr, int n)
        {
            List<int> li = new List<int>();
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                if (st.Count == 0)
                {
                    li.Add(-1);
                }
                else if (st.Count > 0 && st.Peek() < arr[i])
                {
                    li.Add(st.Peek());
                }
                else if (st.Count > 0 && st.Peek() >= arr[i])
                {
                    while (st.Count > 0 && st.Peek() >= arr[i])
                    {
                        st.Pop();
                    }
                    if (st.Count <= 0)
                    {
                        li.Add(-1);
                    }
                    else if (st.Peek() < arr[i])
                        li.Add(st.Peek());
                }
                st.Push(arr[i]);
            }
            return li;
        }
    }
}
