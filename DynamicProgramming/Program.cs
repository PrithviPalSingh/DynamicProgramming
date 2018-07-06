using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] intArray = { 2, 5, 5, 5, 5, 5 };
            //int[] intArray = { 1, 5, 5, 5, 5, 5 };
            //int[] intArray = { 512, 125, 928, 381, 890 , 90, 512, 789, 469, 473, 908, 990, 195, 763, 102, 643, 458, 366, 684, 857, 126, 534, 974, 875, 459, 892, 686, 373, 127, 297, 576, 991, 774, 856, 372, 664, 946, 237, 806, 767, 62, 714, 758, 258, 477, 860, 253, 287, 579, 289, 496 };
            //int[] intArray = { 858, 710 };
            //Console.WriteLine(new EqualDistribution().MinRound(intArray));

            int[] coins = { 2, 5, 3, 6 };
            Console.WriteLine(new CoinChange().GetWays(coins, 10));
            Console.Read();
        }
    }
}
