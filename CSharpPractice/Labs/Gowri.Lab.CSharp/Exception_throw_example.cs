using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.Lab.CSharp {
    
    public class Exception_throw_example
    {
        public void CheckMarks(int marks)
        {
            if (marks < 0 || marks > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(marks), "Marks should be between 0 and 100.");
            }
            else
            {
                Console.WriteLine($"Marks entered: {marks}");
            }
        }
        public static void  MyException()
        {
            Exception_throw_example example = new Exception_throw_example();
                
            try
            {
                example.CheckMarks(150);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

//Error: Specified argument was out of the range of valid values. (Parameter 'Marks should be between 0 and 100.')

//Error: Marks should be between 0 and 100. (Parameter 'marks') 