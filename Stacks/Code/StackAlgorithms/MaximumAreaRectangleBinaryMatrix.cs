using System;
using System.Collections.Generic;
using System.Text;

namespace StackAlgorithms
{
    class MaximumAreaRectangleBinaryMatrix
    {
        public void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int[,] BinaryMatrix = new int[n, m];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    BinaryMatrix[i, j] = int.Parse(Console.ReadLine());
                }
            }
            List<int> Hn = new List<int>();
            for (int i = 0; i < m; i++)
                Hn.Add(BinaryMatrix[0, i]);
            int max = MAH(Hn.ToArray(), Hn.ToArray().Length);
            for(int i = 1; i < n; i++)
            {
                for(int j = 0; j < m; j++)
                {
                    if (BinaryMatrix[i, j] == 0)
                        Hn[j] = 0;
                    else
                        Hn[j] = Hn[j] + BinaryMatrix[i, j]; 
                }
                max = ReturnMax(max, MAH(Hn.ToArray(), Hn.ToArray().Length));
            }
            Console.WriteLine(max);
        }
        public int MAH(int[] arr,int n)
        {
            List<int> left = NearestSmallestLeft(arr, n);
            List<int> right = NearestSmallestRight(arr, n);
            int max = MaxinMAH(left, right, n, arr);
            return max;
        }
        public List<int> NearestSmallestLeft(int[] arr,int n)
        {
            int pseudoIndex = -1;
            List<int> li = new List<int>();
            Stack<int> st = new Stack<int>();
            for(int i = 0; i < n; i++)
            {
                if (st.Count == 0)
                {
                    li.Add(pseudoIndex);
                }
                else if(st.Count>0 && arr[st.Peek()] < arr[i])
                {
                    li.Add(st.Peek());
                }
                else if(st.Count > 0 && arr[st.Peek()] >= arr[i])
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
        public List<int> NearestSmallestRight(int[] arr, int n)
        {
            int pseudoIndex = n;
            List<int> li = new List<int>();
            Stack<int> st = new Stack<int>();
            for (int i = n-1; i >=0; i--)
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
            li.Reverse();
            return li;
        }
        public int MaxinMAH(List<int> left,List<int> right,int n,int[] arr)
        {
            int max = 0;
            int[] result = new int[n];
            for(int i = 0; i < n; i++)
            {
                result[i] = (right[i]-left[i]-1) * arr[i];
            }
            for(int i = 0; i < n; i++)
            {
                if (result[i] > max)
                    max = result[i];
            }
            return max;
        }
        public int ReturnMax(int a,int b)
        {
            if (a >= b)
                return a;
            return b;
        }
    }
}
