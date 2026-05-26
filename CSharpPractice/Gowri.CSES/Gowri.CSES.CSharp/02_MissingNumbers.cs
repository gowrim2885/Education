namespace Gowri.CSES.CSharp
{
    internal class _02_MissingNumbers
    {
        public static void FindNumber()
        {
            Console.WriteLine("Enter the Number of values");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr1 = new int[n];

            Console.WriteLine("Enter any " + (n - 1) + " values");
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                arr1[i] = Convert.ToInt32(Console.ReadLine());
            }

            bool flag = false;

            for (int j = 1; j <= n; j++)//1,2,3,4,5
            {


                foreach (var item in arr1)//1 2 3 4
                {
                    if (j == item)
                    {
                        flag = true;
                        break;
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("The Missing Value is  " + j);
                }
            }
        }
    }
}
