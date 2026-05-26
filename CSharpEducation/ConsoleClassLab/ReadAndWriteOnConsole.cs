using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpBasics
{
    internal class ReadAndWriteOnConsole
    {
        public static void GetAndDisplayEmpData()
        {
            Console.WriteLine("Enter Employee Details");

            Console.WriteLine("Enter Employee ID");
            int EmployeeID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Name");
            string? Name = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary");
            int Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Employee Address");
            string? Address = Console.ReadLine();
            Console.WriteLine("Enter Employee Department");
            string? Department = Console.ReadLine();

            //Display the Entered Employee Details
            Console.WriteLine("\nEntered Employee Details are as Follows:");
            Console.WriteLine($"Employee ID Is: {EmployeeID}");
            Console.WriteLine($"Employee Name Is: {Name}");
            Console.WriteLine($"Employee Salary Is: {Salary}");
            Console.WriteLine($"Employee Address Is: {Address}");
            Console.WriteLine($"Employee Department Is: {Department}");
            Console.ReadKey();
        }
    }
}
