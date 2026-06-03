using EmployeeManagementSystem.Log;
using EmployeeManagementSystem.logic.models;
using System.Text.Json;

namespace EmployeeManagementSystem.Data
{
    public class DataStorage
    {
        string FilePath = "C:\\Gowri\\Repositories\\CSharpProject\\CSharpProjects\\EmployeeManagementSystem\\employee.json";

        private object _fileAccess = new object();
        public void SaveToFile(List<EmployeeModel> Employee)
        {
            lock (_fileAccess)
            {
                List<EmployeeModel> Employees = new List<EmployeeModel>();

                if (File.Exists(FilePath))
                {
                    //string ExistingData = File.ReadAllText(FilePath);
                    //Employees = JsonSerializer.Deserialize<List<EmployeeModel>>(ExistingData) ?? new List<EmployeeModel>();

                    Employees.AddRange(Employee);

                }
                string json = JsonSerializer.Serialize(Employees);
                File.WriteAllText(FilePath, json);

            }
        }




        public List<EmployeeModel> ReadFromFile()
        {
            lock (_fileAccess)
            {
                if (!File.Exists(FilePath))
                {
                    return new List<EmployeeModel>();
                }

                string json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<EmployeeModel>>(json);

            }
        }

    }
}
