using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public  class StudentAsychExecution
    {
        
        public static async Task Main()
        {
            Console.WriteLine("Main Thread Start");
            
            AsynchronousMethod().GetAwaiter().GetResult(); //Blocking the thread
            //await Task.Run(()=>AsynchronousMethod());  // Unblock the thread
            
            Console.WriteLine("Main thread End");
        }
        public static async Task AsynchronousMethod()
        {
            //await Task.WhenAll(
            //    LoadStudents(),
            //    GenerateStudent(),
            //    SendEmail()
            //);

            //Task.WaitAll();
            Task T1 = LoadStudents();
            Task T2 = GenerateStudent();
            Task T3 = SendEmail();

            await Task.WhenAll(T1, T2, T3);

            Console.WriteLine("All task Finish the execution");
        }

        //public void SynchronousMethod()
        //{
        //    Task T4 = LoadStudents();
        //    Task T5 = GenerateStudent();
        //    Task T6 = SendEmail();

        //}
        
        public static async Task LoadStudents()
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Start Loading Student {i} Information...");
                await Task.Delay(3000);
                Console.WriteLine($"End Loading Student{i} Information...");
            }

        }
        public static async Task GenerateStudent()
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Start Generate Student {i} Reports...");
                await Task.Delay(3000);
                Console.WriteLine($"End Generate Student {i} Reports...");
            }

        }
        public static async Task SendEmail()
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Start Send Mail to Student {i}...");
                await Task.Delay(3000);
                Console.WriteLine($"End Send Mail to Student {i}...");
            }

        }

    }
}


