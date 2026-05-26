using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpBasics
{
    internal class Variables
    {
        const float PI = 3.14f;
        static int x = 100;
        int y = 200;

        public Variables(int a)
        {
            y = a;
            x = a; // we can also access the static variables 
        }
        public static void CheckVariablesType()
        {
            Console.WriteLine($" The value of x is {x}");
            Console.WriteLine(PI);
            // x  access directly

            //Variables obj = new Variables();
            Variables obj1 = new Variables(300);
            
            // each time we initialize, the static variable value will override with the new value. 
            Console.WriteLine($" The value of y is {obj1.y}");
            Console.WriteLine($" The value of x is {x}");

            Variables obj2 = new Variables(400);
            
            // each time we initialize, the static variable value will override with the new value. 
            Console.WriteLine($" The value of y is {obj2.y}");
            Console.WriteLine($" The value of x is {x}");
           


            Console.WriteLine($" The value of x is {x}");

            //y can access using instance or obj because it isa non static fields

        }
    }
}
