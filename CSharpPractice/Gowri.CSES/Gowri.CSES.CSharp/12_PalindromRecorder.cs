using System;
namespace Gowri.CSES.CSharp
{
    internal class _12_PalindromRecorder
    {
        public static void CheckPalindrom()
        {
            Console.WriteLine("Enter the string and its palindrom or not");
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
