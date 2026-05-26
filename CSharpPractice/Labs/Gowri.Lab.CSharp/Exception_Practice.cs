using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.Lab.CSharp
{
    public class ExceptionPractice
    {
        public static void CheckException()
        {
            try
            {
                Console.WriteLine("Enter a number: ");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter another number: ");
                int num2 = Convert.ToInt32(Console.ReadLine());
                int result = num1 / num2;
                Console.WriteLine($"The result of {num1} divided by {num2} is: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero. Please provide a non-zero divisor.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input format. Please enter valid integers.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Exception Handling Completed.");
            }
        }
    

    }
}
