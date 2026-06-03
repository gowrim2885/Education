using System.Threading;
using System.Collections;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.logic.models;
using System.Text.Json;
using EmployeeManagementSystem.Log;

namespace EmployeeManagementSystem.logic.services
{
    public class EmployeeService
    {
        EmployeeData data = new EmployeeData();
       
        public void AddNewEmployee(int nEmpId, string strName, string strDepartment, string strEmail, decimal dSalary, int nAge, string strLocation)
        {
            Thread addUserThread = new Thread(() =>
            {
                data.AddEmployee(new EmployeeModel
                {
                    id = nEmpId,
                    name = strName,
                    department = strDepartment,
                    email = strEmail,
                    salary = (int)dSalary,
                    age = nAge,
                    location = strLocation
                });
            });

            addUserThread.Start();
            addUserThread.Join();
        
        }

        public List<EmployeeModel> DisplayAllEmployees()
        {
            return data.GetAllEmployees();
        }

        public bool DeleteEmployee(int nEmpId)
        {
            bool IsDelete = false;

            List<EmployeeModel> employees = DisplayAllEmployees();
            var employeeToDelete = employees.Find(emp => emp.id == nEmpId);

            if (employeeToDelete != null)
            {
                string olddata = JsonSerializer.Serialize(employeeToDelete);
                employees.Remove(employeeToDelete);
                IsDelete = true;

                data.UpdateNewEmployeeList(employees);

                EmployeeHistoryStorage.SaveHistory(new EmployeeHistory
                {
                    EmployeeId = nEmpId,
                    Action = "DELETE",
                    OldValue = olddata,
                    NewValue = null
                });

                return IsDelete;
            }
            else
            {
                return IsDelete;
            }
        }

        public bool UpdateEmployeeInformation(int nEmpId, string strName, string strDepartment, string strEmail, int nSalary, int nAge, string strLocation)
        {
            bool IsUpdate = false;
            List<EmployeeModel> employees = DisplayAllEmployees();

            var employeeToUpdate = employees.Find(emp => emp.id == nEmpId);
            if (employeeToUpdate != null)
            {
                string oldData = JsonSerializer.Serialize(employeeToUpdate);

                //string sample = employeeToUpdate;
                employeeToUpdate.name = strName;
                employeeToUpdate.department = strDepartment;
                employeeToUpdate.email = strEmail;
                employeeToUpdate.salary = nSalary;
                employeeToUpdate.age = nAge;
                employeeToUpdate.location = strLocation;
                IsUpdate = true;
                

                string newData = JsonSerializer.Serialize(employeeToUpdate);

                EmployeeHistoryStorage.SaveHistory(new EmployeeHistory
                {
                    EmployeeId = nEmpId,
                    Action = "UPDATE",
                    OldValue = oldData,
                    NewValue = newData
                });

                data.UpdateNewEmployeeList(employees);

                return IsUpdate;
            }
            else
            {
                return IsUpdate;

            }
        }
    }
}
