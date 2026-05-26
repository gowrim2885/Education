using EmployeeManagementSystem.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EmployeeManagementSystem.Data
{
    public class DataStorage
    {

        string FilePath = "C:\\Gowri\\Repositories\\Batch-2026\\Gowri\\Solution\\Gowri\\EmployeeManagementSystem\\employees.csv";

        public void SaveToFile(List<EmployeeModel> Employees)
        {


            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    //writer.WriteLine("Name , Department, Email, Salary, Age, Location");

                    foreach (var emp in Employees)
                    {
                        writer.WriteLine($"{emp.name},{emp.department},{emp.email},{emp.salary},{emp.age},{emp.location}");
                    }
                }
                Console.WriteLine($"Data successfully written to {FilePath}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }

        }

       
        public void ReadFromFile()
        {
            try
            {
                 using(StreamReader reader = new StreamReader(FilePath))
                 {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    { 
                       
                        string[] fields = line.Split(',');
                        Console.WriteLine($"\n\n Employee Name: {fields[0]} \n " +
                            $"Department: {fields[1]} \n" +
                            $"Email: {fields[2]} \n" +
                            $"Salary: {fields[3]} \n" +
                            $"Age: {fields[4]} \n" +
                            $"Location:{fields[5]}\n ");

                    }
                 }
            }

            catch(Exception e)
            {
                Console.WriteLine("Can not able to read the data from the File." + e.Message);
            }
        }

    }
}
