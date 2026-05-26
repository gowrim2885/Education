using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.Lab.CSharp
{
    public class calculator
    {
        public delegate int operations(int x, int y);

        public static int Add(int x, int y) => x + y;
        public static int Subtraction(int x, int y) => x - y;
        public static int Multiplication(int x, int y) =>x * y; 
        public static int Division(int x, int y) => x / y;

        public static void Main()
        {
            operations op = Add;
            Console.WriteLine("Addition: " + op(10, 5));

            op = Subtraction;
            Console.WriteLine("Subtraction: " + op(10, 5));

            op = Multiplication;
            Console.WriteLine("Multiplication: " + op(10, 5));

            op = Division;
            Console.WriteLine("Division: " + op(10, 5));
        }
    }
}
