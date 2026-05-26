using System.Text;

namespace Gowri.CodeForce.CSharp
{
    public class _06_NextRound
    {
        public static void FindNextRound()
        {
            List<int> result = new List<int>();
            string? value1 = Console.ReadLine(); //"8 5"

            string[] array1 = (value1.Split(' '));

            int n = int.Parse(array1[0]); //8
            int k = int.Parse(array1[1]); //5


            string value2 = Console.ReadLine();

            string[] array2 = value2.Split(" ");

            int threshold = int.Parse(array2[k-1]);

            for (int i = 0; i < array2.Length; i++) {
                int val = int.Parse(array2[i]);

                if (val>=threshold && val > 0)
                {
                    result.Add(val);
                }

            }

           int listLength = result.Count;

           Console.WriteLine(listLength);
      

        }
    }
}
