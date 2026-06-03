using StudentManagementSystem.Logic.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.UI
{
    internal class StudentManagement
    {
        StudentService service = new StudentService();
        public void Start()
        {
            bool interest = true;

            while(interest)
            {
                Console.WriteLine(" *** WELCOME TO STUDENT MANAGEMENT SYSTEM ***");

                Console.WriteLine("Enter Which Operation are to be performed");
                Console.WriteLine("1. Add Students");
                Console.WriteLine("2. Display Students");
                Console.WriteLine("3. Update Student Details");
                Console.WriteLine("4.Delete Student Details");
                Console.WriteLine("5.Get the total students count");
                Console.WriteLine("6.Display the student with Age less than or equal to 20");

                Console.WriteLine("Enter your option");
                int n = Convert.ToInt32(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        AddStudent(); //create
                        break;
                    case 2:
                        ShowAllStudentDetail();//read
                        break;
                    case 3:
                        UpdateStudent(); //Update
                        break;
                    case 4:
                        DeleteStudent();
                        break;
                    case 5:
                        GetTotalStudentCount();
                        break;
                    case 6:
                        FilterStudentBasedOnAge();
                        break;
                }

                Console.WriteLine("\n Do You want to continue(Y/N): ");
                char input = Convert.ToChar(Console.ReadLine());
                if(input == 'Y' || input == 'y')
                {
                    interest = true;
                }
                else
                {
                    interest = false;
                }
                

            }

        }

        public void AddStudent()
        {
            //Console.Write("Enter Student ID :");
            //int nId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Student Name :");
            string? strName = Console.ReadLine();
            Console.Write("Enter Student Age :");
            int nAge = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Student Email :");
            string? strEmail = Console.ReadLine();
            Console.Write("Enter Student Department :");
            string? strDepartment = Console.ReadLine();

            service.AddNewStudent(strName, nAge, strEmail, strDepartment);

            Console.WriteLine("Student ADDED Successfully");
        }


        public void ShowAllStudentDetail()
        {
            Console.WriteLine("All Students Detail");
            service.DisplayAllStudents();
        }
    
        public void UpdateStudent()
        {
            Console.WriteLine("Enter the name of the student to update :");
            string strName = Console.ReadLine();

            Console.WriteLine("Enter Which column you want to update (Name, Email, Department, Age) :");
            string strColumnName = Console.ReadLine();

            Console.WriteLine("Enter new data to update the old data");

            if (strColumnName == "Name" || strColumnName == "Email" || strColumnName == "Department")
            { 
                string newdata = Console.ReadLine();
                service.UpdateStudentInfo<string>(newdata, strColumnName, strName);
            }
            if (strColumnName == "Age")
            {
                int newdata = Convert.ToInt32(Console.ReadLine());
                service.UpdateStudentInfo<int>(newdata, strColumnName, strName);
            }

            Console.WriteLine("Student UPDATED Successfully");

        }

        public void DeleteStudent()
        {
            Console.WriteLine("Enter ID For delete the student :");
            int nStudent_ID = int.Parse(Console.ReadLine());

            service.DeleteStudent(nStudent_ID);

            Console.WriteLine("Student DELETED Successfully");
        }
    
        public void GetTotalStudentCount()
        {
            int result = service.getCount();
            Console.Write("TOTAL STUDENT COUNT: "+ result);
        }
        public void FilterStudentBasedOnAge()
        {
            service.FilterStudent();
        }


    }

}
