using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class EqualDistribution
    {
        private static int min = -1;
        // Complete the equal function below.
        public int Equal(int[] intArray)
        {
            decimal difference = -1;
            int max = intArray.Length - 1;
            int count = 0;
            do
            {
                Array.Sort(intArray);
                difference = intArray[max] - intArray[0];
                int numberToSubtract = 0;
                if (difference > 2 && intArray[max] >= 5)
                {
                    numberToSubtract = 5;
                }
                else if (difference >= 2 && intArray[max] < 5)
                {
                    numberToSubtract = 2;
                }
                else if (difference == 2 && intArray[max] >= 5)
                {
                    numberToSubtract = 2;
                }
                else if (difference == 1)
                {
                    numberToSubtract = 1;
                }
                else
                {
                    break;
                }

                count++;

                intArray[max] = intArray[max] - numberToSubtract;

            } while (difference != 0);

            return count;
        }

        public int MinRound(int[] counts)
        {
            for (int j = 0; j < counts.Length; j++)
            {
                // get min value from input array
                if (counts[j] < min || min < 0)
                {
                    min = counts[j];
                }
            }

            int[][] results = new int[counts.Length][];
            for (int i = 0; i < counts.Length; i++)
            {
                results[i] = new int[3];
                for (int j = 0; j < 3; j++)
                {

                    //Determine baselines -- difference between possible Max and Min
                    //Not only possible to take from Max values also can take from Min values
                    //Like the case  1 5 5  -> 0 5 5 -> 0 0 5 -> 0 0 0
                    //Baseline can be keep min, take 1 or 2 from min. 
                    //Dont need to consider the case of take 5 coz it will not affect greedy approach below

                    int delta = counts[i] - min + j;
                    results[i][j] = 0;
                    while (true)
                    {
                        // Greedy approach
                        if (delta >= 5)
                        {
                            delta -= 5;
                            results[i][j]++;
                        }
                        else if (delta >= 2)
                        {
                            delta -= 2;
                            results[i][j]++;
                        }
                        else if (delta >= 1)
                        {
                            delta -= 1;
                            results[i][j]++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            int finalResult = -1;
            // Compare results from different baseline cases (keep min, take 1, 2 ). 
            for (int i = 0; i < 3; i++)
            {
                int subFinal = 0;
                for (int j = 0; j < counts.Length; j++)
                {
                    subFinal += results[j][i];
                    //if (DBG) System.out.format("results[%d][%d] = %d \n", j, i, results[j][i]);
                }
                //if (DBG) System.out.println(subFinal);
                if (finalResult < 0 || finalResult > subFinal) { finalResult = subFinal; }
            }

            return finalResult;
        }
    }
}