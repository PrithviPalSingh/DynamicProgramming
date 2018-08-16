using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    class Abbreviation
    {
        public static string abbreviation1(string a, string b)
        {
            char[] a1 = a.ToCharArray();
            var b1 = b.ToCharArray();
            Dictionary<char, int> memo = new Dictionary<char, int>();
            #region - remove unnecessary items
            for (int i = a1.Length - 1; i >= 0; i--)
            {
                if (a1[i].ToString() == a1[i].ToString().ToUpper())
                {
                    continue;
                }

                var found = false;
                for (int j = 0; j < b1.Length; j++)
                {
                    if (a1[i].ToString().ToUpper() == b[j].ToString())
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    var j = i;
                    if (i == a1.Length - 1)
                    {
                        a1[i] = ' ';
                    }
                    else
                    {
                        while (j < a1.Length - 1 && a1[j] != ' ')
                        {
                            a1[j] = a1[j + 1];
                            j++;
                        }

                        if (j != a1.Length)
                            a1[j] = ' ';
                    }
                }
            }
            #endregion

            //string str = string.Empty;
            //for (int i = 0; i < a1.Length; i++)
            //{
            //    if (a1[i] != ' ')
            //    {
            //        str = str + a1[i].ToString();
            //    }
            //}

            var up = a1;// str.ToCharArray();


            for (int i = 0; i < b.Length && up[i] != ' '; i++)
            {
                //var j = i;

                if (up[i].ToString() == up[i].ToString().ToUpper() && up[i].ToString() == b[i].ToString())
                {
                    continue;
                }

                if (up[i].ToString() != b[i].ToString() && up[i].ToString().ToUpper() == b[i].ToString())
                {
                    continue;
                }


                //if (b[i].ToString() != up[i].ToString().ToUpper() && up[j] != ' ')
                //{
                //    while (j < up.Length - 1)
                //    {
                //        up[j] = up[j + 1];
                //        j++;
                //    }

                //    if (j != a1.Length)
                //        up[j] = ' ';

                //    i--;
                //}

                if (b[i].ToString() != up[i].ToString().ToUpper())
                {
                    var j = i;
                    if (i == up.Length - 1)
                    {
                        up[i] = ' ';
                    }
                    else
                    {
                        while (j < up.Length - 1 && up[j] != ' ')
                        {
                            up[j] = up[j + 1];
                            j++;
                        }

                        if (j != a1.Length)
                            up[j] = ' ';
                    }

                    i--;
                }
            }

            if (b.Length < up.Length)
            {
                for (int i = b.Length; i < up.Length && (up[i].ToString() != up[i].ToString().ToUpper()); i++)
                {
                    up[i] = ' ';
                }
            }

            string str1 = string.Empty;
            for (int i = 0; i < up.Length; i++)
            {
                if (up[i] != ' ')
                {
                    str1 = str1 + up[i].ToString().ToUpper();
                }
            }

            return str1 == b ? "YES" : "NO";
        }

        public static string abbreviation(string a, string b)
        {
            Queue<char> memo = new Queue<char>();
            return abs(a, b, memo) ? "YES" : "NO";
        }

        //private static bool abs1(string a, string b, Queue<char> memo)
        //{
        //    int aMaxIndex = a.Length - 1;
        //    int bMaxIndex = b.Length - 1;

        //    if (string.IsNullOrWhiteSpace(a) && string.IsNullOrWhiteSpace(b))
        //        return true;

        //    if (!string.IsNullOrWhiteSpace(b) && string.IsNullOrWhiteSpace(a))
        //        return false;

        //    if (string.IsNullOrWhiteSpace(b) && !string.IsNullOrWhiteSpace(a))
        //    {
        //        var pop = memo.Count > 0 ? memo.Dequeue() : ' ';
        //        if (IsLowerCase(a[aMaxIndex]))
        //        {
        //            if (pop == a[aMaxIndex])
        //            {
        //                memo.Enqueue(a[aMaxIndex]);
        //            }

        //            //memo.Push(pop);
        //            return abs(a.Substring(0, aMaxIndex), b, memo);
        //        }
        //        else
        //        {
        //            // If a[maxIndex] matches keyValue
        //            if (pop.ToString() == a[aMaxIndex].ToString().ToLower())
        //            {
        //                return abs(a.Substring(0, aMaxIndex), b, memo);
        //            }

        //            return false;
        //        }
        //    }

        //    if (b[bMaxIndex] == a[aMaxIndex])
        //    {
        //        return abs(a.Substring(0, aMaxIndex), b.Substring(0, bMaxIndex), memo);
        //    }

        //    if (b[bMaxIndex].ToString() == a[aMaxIndex].ToString().ToUpper())
        //    {
        //        memo.Enqueue(a[aMaxIndex]);
        //        return abs(a.Substring(0, aMaxIndex), b.Substring(0, bMaxIndex), memo);
        //    }

        //    if (b[bMaxIndex] != a[aMaxIndex])
        //    {
        //        var pop = memo.Count > 0 ? memo.Dequeue() : ' ';
        //        if (IsLowerCase(a[aMaxIndex]))
        //        {
        //            //if (pop == a[aMaxIndex])
        //            //{                        
        //            //    memo.Enqueue(a[aMaxIndex]);                        
        //            //}

        //            memo.Enqueue(a[aMaxIndex]);
        //            //memo.Push(pop);
        //            return abs(a.Substring(0, aMaxIndex), b, memo);
        //        }
        //        else
        //        {
        //            // If a[maxIndex] matches keyValue
        //            if (pop.ToString() == a[aMaxIndex].ToString().ToLower())
        //            {
        //                return abs(a.Substring(0, aMaxIndex), b, memo);
        //            }

        //            return false;
        //        }
        //    }

        //    return false;

        //}

        private static bool abs(string a, string b, Queue<char> memo)
        {
            int aMaxIndex = a.Length - 1;
            int bMaxIndex = b.Length - 1;

            #region Base-cases
            //both empty
            if (string.IsNullOrWhiteSpace(a) && string.IsNullOrWhiteSpace(b))
                return true;

            //a is empty but b have items
            if (string.IsNullOrWhiteSpace(a) && !string.IsNullOrWhiteSpace(b))
                return false;
            #endregion

            #region Need to re-visit -- special case 1
            //b is empty and a is non-empty
            if (string.IsNullOrWhiteSpace(b) && !string.IsNullOrWhiteSpace(a))
            {
                if (!IsLowerCase(a[aMaxIndex]))
                {
                    if (memo.Count == 0)
                        return false;

                    while (memo.Count > 0)
                    {
                        var deq = memo.Dequeue();

                        if (deq.ToString().ToUpper() == a[aMaxIndex].ToString().ToUpper())
                            break;
                    }
                }

                return abs(a.Substring(0, aMaxIndex), b, memo); ;
            }
            #endregion

            // Both same and upper case
            if (a[aMaxIndex] == b[bMaxIndex])
            {
                //var foundinmemo = false;
                //while (memo.Count > 0)
                //{
                //    var deq = memo.Dequeue();

                //    if (deq.ToString().ToUpper() == a[aMaxIndex].ToString().ToUpper())
                //    {
                //        foundinmemo = true;
                //        break;
                //    }
                //}

                //if (foundinmemo)
                //{
                //    return abs(a.Substring(0, aMaxIndex), b, memo);

                //}
                //else
                { return abs(a.Substring(0, aMaxIndex), b.Substring(0, bMaxIndex), memo); }
            }

            #region - special case 2
            //both upper case and different - special case
            if (IsUpperCase(a[aMaxIndex]) && a[aMaxIndex] != b[bMaxIndex])
            {
                if (memo.Count == 0)
                    return false;

                while (memo.Count > 0)
                {
                    var deq = memo.Dequeue();

                    if (deq.ToString().ToUpper() == a[aMaxIndex].ToString().ToUpper())
                        break;
                }

                return abs(a.Substring(0, aMaxIndex), b, memo);
            }
            #endregion

            //a lower case and not equal to b
            if (IsLowerCase(a[aMaxIndex]) && a[aMaxIndex].ToString().ToUpper() != b[bMaxIndex].ToString())
            {
                return abs(a.Substring(0, aMaxIndex), b, memo);
            }

            #region - special case 3
            //a lower case and equal to b
            if (IsLowerCase(a[aMaxIndex]) && a[aMaxIndex].ToString().ToUpper() == b[bMaxIndex].ToString())
            {
                //Memorize this
                memo.Enqueue(a[aMaxIndex]);
                return abs(a.Substring(0, aMaxIndex), b.Substring(0, bMaxIndex), memo);
            }
            #endregion

            return false;
        }

        private static bool IsLowerCase(char c)
        {
            if (c >= 97 && c <= 122)
                return true;

            return false;
        }

        private static bool IsUpperCase(char c)
        {
            if (c >= 65 && c <= 90)
                return true;

            return false;
        }
    }
}
