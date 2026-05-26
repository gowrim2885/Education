using System;
using System.Collections.Generic;
namespace Gowri.Lab.CSharp
{
    public class CollectionsClass
    {
        public static void MainMethod()
        {
            Dictionary<int, string> students = new Dictionary<int, string>();
            HashSet<string> names = new HashSet<string>();

            while (true)
            {
                Console.WriteLine("\n 1. Add Students");
                Console.WriteLine("2.View Students");
                Console.WriteLine("3.search students");
                Console.WriteLine(" 4. Remove Students");
                Console.WriteLine("5. Exit");

                Console.WriteLine("Enter Choice :");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Roll No: ");
                        int roll = int.Parse(Console.ReadLine());

                        Console.Write("Enter Name: ");
                        string? name = Console.ReadLine(); // hash set not allow the duplicate value

                        if (names.Contains(name))
                        {
                            Console.WriteLine("Duplicate name not allowed!");
                            break;
                        }

                        students[roll] = name;
                        names.Add(name);

                        Console.WriteLine("Student Added!");
                        break;

                    case 2:
                        Console.WriteLine("\nStudent List:");
                        foreach (var s in students)
                        {
                            Console.WriteLine(s.Key + " - " + s.Value);
                        }
                        break;

                    case 3:
                        Console.Write("Enter Roll No to search: ");
                        int searchRoll = int.Parse(Console.ReadLine());

                        if (students.ContainsKey(searchRoll))
                        {
                            Console.WriteLine("Found: " + students[searchRoll]);
                        }
                        else
                        {
                            Console.WriteLine("Student not found!");
                        }
                        break;

                    case 4:
                        Console.Write("Enter Roll No to remove: ");
                        int removeRoll = int.Parse(Console.ReadLine());

                        if (students.ContainsKey(removeRoll))
                        {
                            string removedName = students[removeRoll];

                            students.Remove(removeRoll);
                            names.Remove(removedName);

                            Console.WriteLine("Student removed!");
                        }
                        else
                        {
                            Console.WriteLine("Student not found!");
                        }
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }



}
