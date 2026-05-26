using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.CodeForce.CSharp
{
    public class _01_watermelon
    {   

        public static void FindSolution()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n == 2) { Console.WriteLine("NO"); }
            else if (n % 2 == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
        
    }
}
