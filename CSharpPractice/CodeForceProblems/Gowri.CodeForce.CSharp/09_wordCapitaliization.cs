using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.CodeForce.CSharp
{
    public class _09_wordCapitaliization
    {
        public static void CapitalizeWord()
        {
            string str = Console.ReadLine();
            if (str.Length != 0 && str.Length<=Math.Pow(10,3))
            {
               
                if (char.IsUpper(str[0]))
                {
                    Console.Write(str);
                }
                else
                {
                    char firstChar = char.ToUpper(str[0]);
                    string restOfString = str.Substring(1);
                    Console.WriteLine(firstChar + restOfString);
                }

            }
            
        }
    }
}
