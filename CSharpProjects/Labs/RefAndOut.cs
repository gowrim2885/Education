using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    internal class RefAndOut
    {
        public static void RunMain()
        {
            int counter = 10;
            IncreamentReference(ref counter);
            Console.WriteLine($"Ref Result (10 + 1): {counter}");

            int result;
            GetValues(out result);
            Console.WriteLine($" Out Result (Assigned in method):{result}");

            if (int.TryParse("123", out int parseValue))
            {
                Console.WriteLine($"Inline Out: {parseValue}");
            }

        }
        public static void IncreamentReference(ref int value)
        {
            value = value + 1;
        }

        public static void GetValues(out int value)
        {
            value = 42;

        }

        
    }
}
