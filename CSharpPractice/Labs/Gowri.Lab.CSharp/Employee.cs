using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.Lab.CSharp
{
    public class Employeedata
    {   
        
        public string? name { get; set; }
        public int age { get; set; } 
        public int salary { get; set; }
        public string? location { get; set; }
    }

        public class Employee
        {

            List<Employeedata> Employeedata = new List<Employeedata>();

            public void AddEmployee()
            {
                Employeedata empdata = new Employeedata();

                Console.Write("Enter Employee Name  ");
                empdata.name = Console.ReadLine();
                Console.Write("Enter Employee Age  ");
                empdata.age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Employee Salary  ");
                empdata.salary = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Employee Location  ");
                empdata.location = Console.ReadLine();

                Employeedata.Add(empdata);
                Console.WriteLine("\n\n" + $"Employee Name: {empdata.name}, Employee Age: {empdata.age}, Employee Salary: {empdata.salary}, Employee Location: {empdata.location}");

            }

            public void DisplayAllEmployees()
            {
                foreach (var emp in Employeedata)
                {
                    Console.WriteLine($"\n Employee Name: {emp.name},\n  Employee Age: {emp.age}, " +
                        $"\n Employee Salary: {emp.salary}, \n Employee Location: {emp.location}");
                }

            }

            public void UpdateEmployee() {
        
            }
            public static void MainMethod()
            {
                Employee emp = new Employee();

                while (true)
                {
                    Console.WriteLine("\n Select Which operation you want to Perform");
                    Console.WriteLine("1. Add Employee");
                    Console.WriteLine("2. Display All Employees");
                    Console.WriteLine("3. Update Employee");
                    Console.WriteLine("4. Exit");
                    

                Console.WriteLine("Enter Your Choice");
                int n = Convert.ToInt32(Console.ReadLine());

                    switch (n)
                    {
                        case 1:
                            emp.AddEmployee();
                            Console.WriteLine("***Employee Added Successfully***");
                            break;
                        case 2:
                            Console.WriteLine("Display All Employees");
                            emp.DisplayAllEmployees();
                            break;
                        case 3:
                            emp.UpdateEmployee();
                            break; 
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
}




