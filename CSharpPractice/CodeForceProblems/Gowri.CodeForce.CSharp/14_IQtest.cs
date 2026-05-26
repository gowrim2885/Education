using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.CodeForce.CSharp
{
    public class _14_IQtest
    {
        public static void FindIq() {
            int n = Convert.ToInt32(Console.ReadLine());
            string? input = Console.ReadLine();

            string[] number = input.Split(' ');
            int[] numbers = Array.ConvertAll(number, int.Parse);

            List<int> EvenArray = new List<int>();
            List<int> OddArray = new List<int>();

            foreach (int value in numbers)
            { 

                if (value % 2 == 0)
                {
                    EvenArray.Add(value);
                }
                else
                {
                    OddArray.Add(value);
                }

            }

            if(EvenArray.Count < OddArray.Count)
            {
                int result =  Array.IndexOf(numbers, EvenArray[0]) + 1;
                Console.WriteLine(result);
            }
            else
            {
                int result =  Array.IndexOf(numbers, OddArray[0])+ 1;
                Console.WriteLine(result);
            }



        }
    }
}
