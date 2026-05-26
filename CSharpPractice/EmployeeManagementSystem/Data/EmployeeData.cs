
using System;
using EmployeeManagementSystem.logic;

namespace EmployeeManagementSystem.Data
{
    public class EmployeeData
    {
      
        DataStorage storage = new DataStorage();

        List<EmployeeModel> Employees = new List<EmployeeModel>();
        public void AddEmployee(EmployeeModel emp)
        {
            Employees.Add(emp);

            storage.SaveToFile(Employees);
        }
        public void GetAllEmployees()
        {

            storage.ReadFromFile();
        }

        

    }
}
