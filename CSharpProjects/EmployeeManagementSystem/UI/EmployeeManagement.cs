using System.Threading;

using EmployeeManagementSystem.logic.services;
using System;

namespace EmployeeManagementSystem.UI
{
    internal class EmployeeManagement
    {
        EmployeeService service = new EmployeeService();
        public void Start()
        {
            while (true)
            {
                Console.Write("**************************************************\n");
                Console.WriteLine("Select Which operation you want to Perform");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display All Employees");
                Console.WriteLine("3. Delete Employee");
                Console.WriteLine("4.Update Employee");
                Console.WriteLine("5. Exit");
                
                Console.Write("\nEnter Your Choice  :   ");
                int n = Convert.ToInt32(Console.ReadLine());
                
                switch (n)
                {
                    case 1:
                        AddEmployee();
                        Console.WriteLine("***Employee Added Successfully*** \n ");
                        break;
                    case 2:
                        Console.WriteLine("\nDisplay All Employees");
                        DisplayAllEmployees();
                        break;
                    case 3:
                        DeleteEmployee();
                        break;
                    case 4:
                        UpdateEmployee();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the Program");
                        return;
                    default:
                        Console.WriteLine("Select a Valid Option");
                        break;
                }
              
            }
        }
        public void AddEmployee()
        {
            try
            {
                Console.Write("Enter Employee Id : ");
                int nEmpId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Employee Name : ");
                string? strName = Console.ReadLine();

                Console.Write("Enter employee Department  : ");
                string? strDepartment = Console.ReadLine();


                Console.Write("Enter Employee Email : ");
                string? strEmail = Console.ReadLine();

                Console.Write("Enter Employee Salary : ");
                int nSalary = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Employee Age : ");
                int nAge = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Employee Location : ");
                string? strLocation = Console.ReadLine();

                service.AddNewEmployee(nEmpId, strName, strDepartment, strEmail, nSalary, nAge, strLocation);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter the valid Input" + ex.Message);
            }

            //Console.Write("\n\n" + $"Employee ID: {nEmpId}, \nEmployee Name: {strName}, Department: {strDepartment}, Email ID: {strEmail}, " +
            //    $"Employee Salary: {nSalary},Employee Age: {nAge}, Employee Location: {strLocation}\n");
        }

        public void DisplayAllEmployees()
        {
            var employees = service.DisplayAllEmployees();

            foreach (var emp in employees)
            {
                Console.WriteLine($"Employee ID: {emp.id}, Employee Name: {emp.name}, Employee Department: {emp.department}, Mail Id:{emp.email}, Employee Age: {emp.age}, " +
                        $"Employee Salary: {emp.salary},  Employee Location: {emp.location} \n ");
            }
        }

        public void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to Delete:  ");
            int nEmpId = Convert.ToInt32(Console.ReadLine());
            bool status = false;
            
            Thread deleteUserThread = new Thread(() =>
            {
                status = service.DeleteEmployee(nEmpId);
            });
            deleteUserThread.Start();
            deleteUserThread.Join();

            if (status)
            {
                Console.WriteLine($"Employee {nEmpId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Employee {nEmpId} not found.");
            }
        }

        public void UpdateEmployee()
        {
            Console.Write("Enter Employee Id To Update ");
            int nEmpId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Name:  ");
            string? strName = Console.ReadLine();

            Console.Write("Enter new Department: ");
            string? strDepartment = Console.ReadLine();
            Console.Write("Enter new Email: ");
            string? strEmail = Console.ReadLine();
            Console.Write("Enter new Salary: ");
            int nSalary = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new Age: ");
            int nAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter new Location: ");
            string? strLocation = Console.ReadLine();

            bool status = false;
            
            Thread updateUserThread = new Thread(() =>
            {
                status = service.UpdateEmployeeInformation(nEmpId, strName, strDepartment, strEmail, nSalary, nAge, strLocation);
            });
            updateUserThread.Start();
            updateUserThread.Join();


            if (status)
            {
                Console.WriteLine($"Employee {strName} Updated successfully.");
            }
            else
            {
                Console.WriteLine($"Employee {strName} not found.");
            }

        }
    }

}

