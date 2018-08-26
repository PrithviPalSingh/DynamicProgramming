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

        static public int lcs(char[] X, char[] Y, int m, int n)
        {
            int[][] L = new int[m + 1][];
            int i, j;

            /* Following steps build L[m+1][n+1] in bottom up fashion. Note 
               that L[i][j] contains length of LCS of X[0..i-1] and Y[0..j-1] */
            for (i = 0; i <= m; i++)
            {
                L[i] = new int[n + 1];
                for (j = 0; j <= n; j++)
                {
                    if (i == 0 || j == 0)
                        L[i][j] = 0;

                    //else if (X[i - 1].ToString() == Y[j - 1].ToString().ToUpper())
                    else if (IsUpperCase(Y[j - 1]) && X[i - 1] == Y[j - 1])
                    {
                        L[i][j] = L[i - 1][j - 1] + 1;
                    }
                    else if (!IsUpperCase(Y[j - 1]) && X[i - 1].ToString() == Y[j - 1].ToString().ToUpper())
                    {
                        if (L[i][j - 1] > L[i - 1][j - 1])
                            L[i][j] = L[i][j - 1];
                        else
                            L[i][j] = L[i - 1][j - 1] + 1;
                    }
                    else if (IsUpperCase(Y[j - 1]) && X[i - 1] != Y[j - 1])
                    {
                        if (L[i - 1][j] > 0)
                            L[i][j] = L[i - 1][j];
                        else
                            L[i][j] = 0;
                    }

                    else
                        L[i][j] = max(L[i - 1][j], L[i][j - 1]);
                }
            }

            /* L[m][n] contains length of LCS for X[0..n-1] and Y[0..m-1] */
            return L[m][n];
        }

        /* Utility function to get max of 2 integers */
        static int max(int a, int b)
        {
            return (a > b) ? a : b;
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
