using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpBasics
{
    internal class StudentVariables
    {
        // Static Variable Class Level - One Copy
        static string schoolName = "GHS School";

        // Instance Variable Object Level - Separate Copy
        string studentName;

        //Const Variable Compile-time constant
        public const string COUNTRY = "India";

        //Readonly Variabl Runtime constant-per object
        readonly int rollNumber;

        //Static Readonly Variable One copy, but assigned at runtime
        static readonly DateTime admissionDate;

        // Static Constructor for rreadonly
        static StudentVariables()
        {
            admissionDate = DateTime.Now;
        }

        // Instance Constructor
        public StudentVariables(string name, int roll)
        {
            studentName = name;
            rollNumber = roll;
        }
         public void Display()
        {
            Console.WriteLine($"School: {schoolName}");
            Console.WriteLine($"Name: {studentName}");
            Console.WriteLine($"Roll: {rollNumber}");
            Console.WriteLine($"Country: {COUNTRY}");
            Console.WriteLine($"Admission Date: {admissionDate}");
            Console.WriteLine("-------------------------");
        }
    }
}
