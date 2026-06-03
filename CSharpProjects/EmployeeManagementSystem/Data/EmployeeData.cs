using EmployeeManagementSystem.Log;
using EmployeeManagementSystem.logic.models;
using System.Collections.Generic;
using System.Text.Json;


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
            EmployeeHistoryStorage.SaveHistory(new EmployeeHistory
            {
                EmployeeId = emp.id,
                Action = "ADD",
                OldValue = null,
                NewValue = JsonSerializer.Serialize(emp)
            });

        }
        public List<EmployeeModel> GetAllEmployees()
        {

            return storage.ReadFromFile();
        }

        public void UpdateNewEmployeeList(List<EmployeeModel> Employees)
        {
            storage.SaveToFile(Employees);
        }

    }
}
