
using EmployeeManagementSystem.logic.services;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        EmployeeService service = new EmployeeService();

        while (true)
        {
            Console.WriteLine("\n Select Which operation you want to Perform");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Display All Employees");
            Console.WriteLine("3. Update Employee");
            Console.WriteLine("4. Exit");


            Console.WriteLine("\n\n Enter Your Choice  : ");
            int n = Convert.ToInt32(Console.ReadLine());

            switch (n)
            {
                case 1:
                    service.AddEmployee();
                    Console.WriteLine("***Employee Added Successfully***");
                    break;
                case 2:
                    Console.WriteLine("\n\n\n Display All Employees");
                    service.DisplayAllEmployees();
                    break;
                //case 3:
                //    emp.UpdateEmployee();
                //    break;
                case 4:
                    Console.WriteLine("Exiting the Program");
                    return;
                default:
                    Console.WriteLine("Select a Valid Option");
                    break;

            }
        }

    }
}