using System;
using System.Collections.Generic;
using System.Text;

namespace StackAlgorithms
{
    class StockSpanProblem
    {
        public void Main()
        {
            int[] arr = { 100,80,60,70,60,75,85};
            List<int> li = StockSpan(arr, arr.Length);
            List<int> result = new List<int>();
            int i = 0;
            foreach(int x in li)
            {
                result.Add(i - x);
                i++;
            }
            foreach (int x in result)
            {
                Console.WriteLine(x);
            }
        }
        public List<int> StockSpan(int[] arr, int n)
        {
            List<int> li = new List<int>();
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                if (st.Count == 0)
                {
                    li.Add(-1);
                }
                else if(st.Count>0 && arr[st.Peek()] > arr[i])
                {
                    li.Add(st.Peek());
                }
                else if(st.Count > 0 && arr[st.Peek()] <= arr[i])
                {
                    while(st.Count > 0 && arr[st.Peek()] <= arr[i])
                    {
                        st.Pop();
                    }
                    if (st.Count == 0)
                    {
                        li.Add(-1);
                    }
                    else if(arr[st.Peek()] > arr[i])
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
