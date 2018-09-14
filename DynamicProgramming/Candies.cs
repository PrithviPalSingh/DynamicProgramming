using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Candies
    {
        public static long candies1(long n, long[] arr)
        {
            long[] lis = new long[n];
            long i, max = 0;
            lis[0] = 1;
            long d = -1;
            Stack<long> poppedIndex = new Stack<long>();

            if (arr[0] > arr[1])
            {
                poppedIndex.Push(0);
            }

            for (long k = 1; k < n; k++)
            {
                if (arr[k] <= arr[k - 1])
                {
                    poppedIndex.Push(k);
                }
                else
                {
                    if (poppedIndex.Count > 0)
                    {
                        long pop = poppedIndex.Pop();
                        lis[pop] = 1;
                        while (poppedIndex.Count > 0)
                        {
                            pop = poppedIndex.Pop();
                            lis[pop] = lis[pop + 1] + 1;
                        }
                    }

                    lis[k] = lis[k - 1] + 1;
                    d = k;
                }
            }

            if (poppedIndex.Count > 0)
            {
                long pop = poppedIndex.Pop();
                lis[pop] = 1;
                while (poppedIndex.Count > 0)
                {
                    pop = poppedIndex.Pop();
                    lis[pop] = lis[pop + 1] + 1;
                }

                if (d != -1 && lis[d] <= lis[pop])
                {
                    lis[d] = lis[d] + 1;
                }
            }

            /* Pick maximum of all LIS values */
            for (i = 0; i < n; i++)
            {
                max = max + lis[i];
            }

            return max;
        }

        public static long candies(int n, long[] arr)
        {
            long[] lis = new long[n];

            for (int i = 0; i < n; i++)
            {
                lis[i] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    lis[i] = lis[i - 1] + 1;
                }
            }

            for (int i = n - 2; i >= 0; i--)
            {
                if (arr[i] > arr[i + 1] && lis[i] <= lis[i+1])
                {
                    lis[i] = lis[i + 1] + 1;
                }
            }

            long max = 0;

            for (int i = 0; i < n; i++)
            {
                max = max + lis[i];
            }

            return max;
        }
    }
}
