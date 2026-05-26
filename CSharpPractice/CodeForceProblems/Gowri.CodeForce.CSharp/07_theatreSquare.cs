using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.CodeForce.CSharp
{
    public class _07_theatreSquare
    {
        public static void Findsqure()
        {
            string? input = Console.ReadLine();

            string[] values = input.Split(" ");

            long n = Convert.ToInt32(values[0]);
            long m = Convert.ToInt32(values[1]);
            long a = Convert.ToInt32(values[2]);

            long result = ((n + a - 1) / a) * ((m + a - 1) / a);

            Console.WriteLine(result);
            

        }
    }
}
