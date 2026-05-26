namespace Gowri.CSES.CSharp
{
    internal class _01_WeirdAlgorithm
    {
        public static void WeridAlgm()
        {
            Console.WriteLine("--- Weird Algorithm ---");
            Console.WriteLine("Enter the number");

            int n = Convert.ToInt32(Console.ReadLine());


            while (n > 1)
            {
                if (n % 2 == 0)
                {
                    n /= 2;
                    Console.WriteLine(n);
                }
                else
                {
                    n = (3 * n) + 1;
                    Console.WriteLine(n);
                }
            }

        }

    }
}
