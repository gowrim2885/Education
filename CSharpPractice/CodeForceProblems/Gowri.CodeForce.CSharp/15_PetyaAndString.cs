using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.CodeForce.CSharp
{
    public class _15_PetyaAndString
    {
        public static void Main()
        {
            string? input1 = Console.ReadLine();
            string? input2 = Console.ReadLine();

            if(input1 == null || input2 == null)
            {
                return;
            }
            else if(input1.ToUpper() == input2.ToUpper())
            {
                Console.WriteLine("0");
            }
            
            int length = Math.Min(input1.Length, input2.Length);
            for ( int i=0; i < length; i++)
            {
                char char1 = input1[i];
                char char2 = input2[i];

                if (char.ToUpper(char1) < char.ToUpper(char2))
                {
                    Console.WriteLine("-1");
                    break;
                }
                else if (char.ToUpper(char1) > char.ToUpper(char2))
                {
                   Console.WriteLine("1");
                    break;

                }
            }

          
        }
    }
}
//int result = input1.ToUpper().CompareTo(input2.ToUpper());
//Console.WriteLine(result);