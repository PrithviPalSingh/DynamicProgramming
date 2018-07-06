using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    /// <summary>
    /// Review this once again
    /// https://www.youtube.com/watch?v=sn0DWI-JdNA
    /// </summary>
    class CoinChange
    {
        public long GetWays(int[] coins, int money)
        {
            Dictionary<string, long> memo = new Dictionary<string, long>();
            var ways = GetWays(coins, money, 0, memo);
            return ways;
            //return GetWays(coins, money, 0);
        }

        private long GetWays(int[] coins, int money, int index, Dictionary<string, long> memo)
        {
            if (money == 0)
                return 1;

            if (index >= coins.Length)
                return 0;

            string key = money + "-" + index;

            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            int amountWithCoin = 0;
            long ways = 0;
            while (amountWithCoin <= money)
            {
                int remaining = money - amountWithCoin;
                ways += GetWays(coins, remaining, index + 1, memo);
                amountWithCoin += coins[index];
            }

            memo.Add(key, ways);

            return ways;
        }

        private long GetWays(int[] coins, int money, int index)
        {
            if (money == 0)
                return 1;

            if (index >= coins.Length)
                return 0;

            //string key = money + "-" + index;

            //if (memo.ContainsKey(key))
            //{
            //    return memo[key];
            //}

            int amountWithCoin = 0;
            long ways = 0;
            while (amountWithCoin <= money)
            {
                int remaining = money - amountWithCoin;
                ways += GetWays(coins, remaining, index + 1);
                amountWithCoin += coins[index];
            }

            //memo.Add(key, ways);

            return ways;
        }
    }
}
