using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.CodeForce.CSharp
{
    public class _12_BoyOrGirl
    {
        public static void Find()
        {
            string? input = Console.ReadLine();
            List<char> uniqueChars = new List<char>();  
            foreach (char c in input)
            {
                if (uniqueChars.Contains(c))
                {
                    continue;
                }
                else
                {
                    uniqueChars.Add(c);
                }
            }

            int length = uniqueChars.Count;
            if (length % 2 == 0)
            {
                Console.WriteLine("CHAT WITH HER!");
            }
            else
            {
                Console.WriteLine("IGNORE HIM!");
            }
        }
    }
}
