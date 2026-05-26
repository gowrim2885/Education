using EmployeeManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace EmployeeManagementSystem.logic.services
{
    public class EmployeeService
    {
        EmployeeData data = new EmployeeData();
        public void AddEmployee()
        {
            Console.Write("Enter Employee Name  ");
            string? strName = Console.ReadLine();

            Console.Write("Enter employee Department   ");
            string? strDepartment = Console.ReadLine();

            
            Console.Write("Enter Employee Email  ");
            string? strEmail = Console.ReadLine();

            Console.Write("Enter Employee Salary  ");
            double dSalary = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Age  ");
            int nAge = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employee Location  ");
            string? strLocation = Console.ReadLine();

          
            data.AddEmployee(new logic.EmployeeModel
            {
                name = strName,
                department = strDepartment,
                email = strEmail,
                salary = (int)dSalary,
                age = nAge,
                location = strLocation
            });



            Console.WriteLine("\n\n" + $"Employee Name: {strName}, Department: {strDepartment}, Email ID: {strEmail}, " +
                $"Employee Salary: {dSalary},Employee Age: {nAge}, Employee Location: {strLocation}\n");

        }

        public void DisplayAllEmployees()
        {
            data.GetAllEmployees();
            //foreach (var emp in data.GetAllEmployees())
            //{
            //    Console.WriteLine($"\n Employee Name: {emp.name},\n Employee Department: {emp.department}, \n Mail Id:{emp.email}, \n  Employee Age: {emp.age}, " +
            //            $"\n Employee Salary: {emp.salary}, \n Employee Location: {emp.location}");
            //}

        }
        

    }
}
