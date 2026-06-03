using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Logic.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public int Age { get; set; }
        public string? Email { get; set; }
        public string? Department { get; set; }

    }
}
