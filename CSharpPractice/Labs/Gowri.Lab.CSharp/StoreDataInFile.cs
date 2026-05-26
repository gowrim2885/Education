using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class StoreDataInFiles
{
    static void StoreDataInFile()
    {
        string filePath = "students.csv";
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Grade = "A" },
            new Student { Id = 2, Name = "Brian", Grade = "B" },
            new Student { Id = 3, Name = "Chloe", Grade = "A-" }
        };

        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write the header row
                writer.WriteLine("Id,Name,Grade");

                // Write the data rows
                foreach (var student in students)
                {
                    writer.WriteLine($"{student.Id},{student.Name},{student.Grade}");
                }
            }
            Console.WriteLine($"Data successfully written to {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error writing to file: {ex.Message}");
        }
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Grade { get; set; }
}
