using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class MaximumSumArray
    {
        public long MaxSubsetSum(int[] arr)
        {
            var memo = new Dictionary<int, long>();

            for (int i = 0; i <= arr.Length - 1; i++)
            {

                if (i == 0 || i == 1)
                {
                    memo.Add(i, arr[i]);
                    continue;
                }
                else if (i == 2)
                {
                    long m = GetMax(arr, i, memo[i - 2]);
                    memo.Add(i, m);
                    continue;
                }

                long max1 = memo[i - 2] > memo[i - 3] ? memo[i - 2] : memo[i - 3];
                long n = GetMax(arr, i, max1);

                memo.Add(i, n);
            }

            long max = -1;
            foreach (var item in memo)
            {
                if (item.Value > max)
                    max = item.Value;
            }

            return max;
        }

        private static long GetMax(int[] arr, int i, long max1)
        {
            long n = -1;

            if (arr[i] < 0 && max1 > 0)
            {
                n = max1;
            }
            else if (max1 < 0 && arr[i] > 0)
            {
                n = arr[i];
            }
            else
            {
                n = arr[i] + max1;
            }

            return n;
        }


        public long MaxSubsetSumWithRecursion(int[] arr)
        {
            var memo = new Dictionary<int, long>();
            long max = -1;

            MaxSubsetSumWithRecursion(arr, arr.Length - 1, memo);

            foreach (var item in memo)
            {
                if (item.Value > max)
                    max = item.Value;
            }

            return max;
        }

        private void MaxSubsetSumWithRecursion(int[] arr, int i, Dictionary<int, long> memo)
        {
            if (i == 0)
            {
                memo.Add(i, arr[i]);
                return;
            }
            else if (i == 1)
            {
                MaxSubsetSumWithRecursion(arr, i - 1, memo);
                memo.Add(i, arr[i]);
                return;
            }
            else if (i == 2)
            {
                MaxSubsetSumWithRecursion(arr, i - 1, memo);
                long m = GetMax(arr, i, memo[i - 2]);
                memo.Add(i, m);
                return;
            }

            MaxSubsetSumWithRecursion(arr, i - 1, memo);
            long max1 = memo[i - 2] > memo[i - 3] ? memo[i - 2] : memo[i - 3];
            long n = GetMax(arr, i, max1);
            memo.Add(i, n);
        }

    }
}
