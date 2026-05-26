using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.CodeForce.CSharp
{
    public class _11_soldiersAndBananas
    {
        public static void CalculateBananaCost()
        {
            string input = Console.ReadLine();
            string[] data = input.Split(' ');
            int k = int.Parse(data[0]);
            int n = int.Parse(data[1]);
            int w = int.Parse(data[2]);


            int totalcost = 0;
            for (int i = 1; i <= w; i++)
            {
                totalcost += i * k;
            }

            int result= totalcost - n;
            if (result >= 0) {
                Console.WriteLine(result);
            }
            else
            {
              
                Console.WriteLine(0);
            }
            
        }
    }
}
