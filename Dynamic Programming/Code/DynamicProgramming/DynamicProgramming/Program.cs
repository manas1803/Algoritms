using System;
using System.Collections.Generic;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Knapsack01Recursive knap = new Knapsack01Recursive();
            //knap.Main();

            //Knapsack01TopDown knapTop = new Knapsack01TopDown();
            //knapTop.Main();

            //SubSetSumRecursive ssr = new SubSetSumRecursive();
            //ssr.Main();

            //EqualSumPartitionTopDown etd = new EqualSumPartitionTopDown();
            //etd.Main();

            //CountOfSubSetTopDown co = new CountOfSubSetTopDown();
            //co.Main();

            Program p = new Program();
            int[] arr = { -5,1,5,0,-7};
            int res = p.LargestAltitude(arr);
            Console.WriteLine(res);
        }
        public bool CheckZeroOnes(string s)
        {
            char[] ss = s.ToCharArray();
            int i = 0;

            while (ss[i] == 49)
            {
                i++;
            }
            while (ss[i] == 48)
            {
                i++;
            }
            return i == ss.Length;
        }
        public int RemoveElement(int[] nums, int val)
        {
            int count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    nums[i] = 51;
                    count++;
                }
            }
            Array.Sort(nums);
            return nums.Length - count;
        }
        public int RemoveDuplicates(int[] nums)
        {
            int count = 0;
            for(int i = 0,j=1; j < nums.Length; i++,j++)
            {
                if (nums[i] == nums[j])
                {
                    nums[i] = 10001;
                }
            }
            Array.Sort(nums);
            for(int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 10001)
                {
                    count++;
                }
            }
            return count;
        }
        public int NumIdenticalPairs(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    var val = dict[nums[i]];
                    dict.Remove(nums[i]);
                    dict.Add(nums[i], val + 1);
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }
            int sum = 0;
            foreach(KeyValuePair<int,int> kvp in dict)
            {
                if (kvp.Value > 1)
                {
                    sum += ((kvp.Value) * (kvp.Value - 1) / 2);
                }
            }
            return sum;
        }
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            Dictionary<int, int> cDict = new Dictionary<int, int>();
            SortedSet<int> srt = new SortedSet<int>(nums);

            int[] result = new int[nums.Length];
            int[] copy = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                copy[i] = nums[i];
            Array.Sort(nums);
            for(int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    var value = dict[nums[i]];
                    dict.Remove(nums[i]);
                    dict.Add(nums[i], value + 1);
                }
                else
                {
                    dict.Add(nums[i], 1);
                }
            }
            cDict.Add(nums[0], 0);
            int[] srtArray = new int[srt.Count];
            srt.CopyTo(srtArray);
            int cummaltive = 0;
            for(int i = 0; i < srtArray.Length - 1; i++)
            {
                cummaltive += dict[srtArray[i]];
                cDict.Add(srtArray[i + 1], cummaltive);
            }
            for(int i = 0; i < copy.Length; i++)
            {
                result[i] = cDict[copy[i]];
            }
            return result;
        }
        public int XorOperation(int n, int start)
        {
            int[] arr = new int[n];
            int xor_sum = 0;
            for(int i = 0; i < n; i++)
            {
                arr[i] = start + 2 * i;
                xor_sum = xor_sum ^ arr[i];
            }
            return xor_sum;
        }
        public int SumOfUnique(int[] nums)
        {
            int[] freqNum = new int[101];
            for(int i = 0; i < nums.Length; i++)
            {
                freqNum[nums[i]]++;
            }
            int sum = 0;
            for(int i = 0; i < freqNum.Length; i++)
            {
                if (freqNum[i] == 1)
                {
                    sum += i;
                }
            }
            return sum;
        }
        public int LargestAltitude(int[] gain)
        {
            int[] resOutput = new int[gain.Length + 1];
            resOutput[0] = 0;
            resOutput[1] = gain[0];
            int sum = gain[0];
            for(int i = 1; i < gain.Length; i++)
            {
                sum += gain[i];
                resOutput[i + 1] = sum;
            }
            int max = -101;
            for(int i = 0; i < resOutput.Length; i++)
            {
                if (resOutput[i] > max)
                    max = resOutput[i];
            }
            return max;
        }
        public int FindNumbers(int[] nums)
        {
            int count = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                int digitCount = Convert.ToInt32(Math.Floor(Math.Log10(nums[i]) + 1));
                if (digitCount % 2 == 0) count++;
            }
            return count;
        }
    }
}
