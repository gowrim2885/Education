using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public class Asysnchronous
    {
        public static void Main()
        {
            Console.WriteLine("Main Method.. start .");
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}");

            Asysnchronous obj = new Asysnchronous();
            obj.NonStaicNormalMethod();
            SomeMethod();
            Console.WriteLine("Main Method.. end .");

        }
        public void NonStaicNormalMethod()
        {
            Console.WriteLine("non static method call using the class instances", "Without waiting");
        }
        public static void SomeMethod()
        {
            Console.WriteLine("Method Started");

            Thread.Sleep(TimeSpan.FromSeconds(10)); // Thread.Sleep(10000); the botha rea same
            //Pause the execution in 10 seconds
            // threads are in Blocking stae or an waiting state
            //It cannot process anything else.  It just sits idle

            Console.WriteLine("Methods ends");
        }
    }
}
