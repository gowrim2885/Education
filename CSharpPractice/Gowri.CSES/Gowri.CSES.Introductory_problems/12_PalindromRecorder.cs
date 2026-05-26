using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.Gowri.CSES.Gowri.CSES.Introductory_problems
{
    internal class _12_PalindromRecorder
    {
        public static void CheckPalindrom()
        {
            String s = Console.ReadLine();

            bool flag = true;
            int i = 0;
            int j = s.Length - 1;
            int mid = (i + j) / 2;
            for (i = 0; i <= mid; i++)
            {
                //mid = (i + j) / 2;
                if (s[i] == s[j])
                {
                    j--;
                }
                else
                {
                    flag = false;
                    break;
                }
            }

            if (flag == true)
            {
                Console.WriteLine("Yes, it is a Valid Palindrom");
            }
            else
            {
                Console.WriteLine("NO SOLUTION, is not a valid palindrom.");
            }
        }
    }
}
