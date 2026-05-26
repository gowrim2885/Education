using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.Gowri.CSES.Gowri.CSES.Introductory_problems
{
    internal class _04_IncreasingArray
    {
        public static void FindMaxMoveInSort()
        {
            Console.WriteLine("Enter the size of Array :  ");
            int num= Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[num];
            Console.WriteLine("Enter the elements in to an array  ::  ");
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            for(int i=1; i< arr.Length; i++)
            {
                int temp;
                int prev;
                int curr;

                if (arr[i - 1] > arr[i])
                {
                    temp = arr[i - 1];
                    prev = arr[i];
                    curr = temp;
                }
               
                Console.WriteLine("AFTER COMPLETE ONE ITERATION");

                foreach (int j in arr)
                {
                    Console.WriteLine(j);
                }

                    i++;
            }


        }
    }
}
