using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentManagementSystem.Logic.Models;
using StudentManagementSystem.Data;

namespace StudentManagementSystem.Logic.service
{
    internal class StudentService
    {
        StudentData data = new StudentData();
        public void AddNewStudent(string strName, int nAge, string strEmail, string strDepartment)
        {
            data.AddStudent(strName, nAge, strEmail,strDepartment);
        }

        public void DisplayAllStudents()
        {
            data.DisplayStudent();
        }
        public void UpdateStudentInfo<T>(T newdata, string strColumnName, string strName)
        {
            data.UpdateStudentInformtion<T>(newdata, strColumnName, strName);
        }
        public void DeleteStudent(int nstudent_ID)
        {
            data.DeleteStudentInformation(nstudent_ID);
        }

        public int getCount()
        {
            return data.GetCount();
        }

        public void FilterStudent()
        {
            data.FilterdStudents();
        }
    }
}
