using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpBasics
{
    internal class TypeCasting
    {
        public static void CheckTypeConvertion()
        {
            Console.WriteLine(" Implicit Casting ");
            int numInt = 1500;
            double numDouble = numInt;
            Console.WriteLine($"Int: {numInt}");
            Console.WriteLine($"Double (Implicit): {numDouble}");

            Console.WriteLine("\n Explicit Casting");
            double d = 1.23;
            int i = (int)d;
            Console.WriteLine($"Original double: {d}");
            Console.WriteLine($"Converted int: {i}");

            Console.WriteLine("\n----- Data Loss Example -----");
            int bigNumber = 500;
            byte smallNumber = (byte)bigNumber;
            Console.WriteLine($"Original: {bigNumber}");
            Console.WriteLine($"Converted to byte: {smallNumber}");

            Console.WriteLine("\n----- Convert Class -----");
            string str = "100";
            int converted = Convert.ToInt32(str);
            Console.WriteLine($"String: {str}  converted to Int: {converted}");

            Console.WriteLine("\n----- Parse Method -----");
            string str2 = "200";
            int parsed = int.Parse(str2);
            Console.WriteLine($"String: {str2} → Int: {parsed}");

            Console.WriteLine("\n----- TryParse Method -----");
            string str3 = "Hello";
            bool isSuccess = int.TryParse(str3, out int result);

            if (isSuccess)
                Console.WriteLine($"Converted: {result}");
            else
                Console.WriteLine($"Failed to convert '{str3}'");


        }
    }
}