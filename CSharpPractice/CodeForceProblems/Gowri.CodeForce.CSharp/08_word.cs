using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.CodeForce.CSharp
{
    public class _08_word
    {
        public static void ConvertWord()
        {
            //Console.WriteLine("Enter the String:");
            string str = Console.ReadLine();
            int UpperCount = 0;
            int LowerCount = 0;

            foreach(char c in str) {

                if (char.IsUpper(c))
                {
                    UpperCount++;
                }
                else
                {
                    LowerCount++;
                }
            }

            if (UpperCount > LowerCount) {
                Console.WriteLine(str.ToUpper());
            }
            
            else {
                Console.WriteLine(str.ToLower());
            }
        }
    }
}
