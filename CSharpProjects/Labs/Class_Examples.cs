using Labs;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public abstract class ParentClass
    {
        public void Add(int x, int y)
        {
            Console.WriteLine($"Addition of{x} and {y} is : {x + y}");
        }
        public void Sub(int x, int y)
        {
            Console.WriteLine($"Subtraction of {x} and {y} is : {x - y}");
        }
        public abstract void Mul(int x, int y);
        public abstract void Div(int x, int y);

    }

  public class Childclass : ParentClass
    {
        public override void Mul(int x, int y)
        {
            Console.WriteLine($"Mutiplication of {x} and {y} is {x * y}");
        }
        public override void Div(int x, int y)
        {
            Console.WriteLine($"Mutiplication of {x} and {y} is {x / y}");
        }

    }

   

    /*  sealed class Printer
     {
         public  void Display()
         {
             Console.WriteLine("Display Method");
         }
         public virtual void Print() 
         {
             Console.WriteLine("Printing Method"); Can not able to methion this as virtual
                                                    Because is mention as a sealed class
             }
         }
      public class ImplementVirtualMethod: Printer
         {
             public sealed  override void Display()
         {
             Console.WriteLine("Display method in derived class");
         }

     }*/


        public class asysnchronous
        {
            public virtual void Method1()
            {
                Console.WriteLine("Class1 Method1");
            }
        }

        public class Class2 : asysnchronous
        {
            private void Method2()
            {
                Console.WriteLine("Class2 Private Method2");
            }

            public sealed override void Method1()
            {
                Console.WriteLine("Class2 Sealed Method1");
            }
        }

        public class Class3 : Class2
        {
            public void Method2()
            {
                Console.WriteLine("Class3 public Method2");
            }
        }

        
    
}

public static class Class_Examples
{
    public static void Main()
    {
        Childclass obj = new Childclass(); /* Child Class instances */
        ParentClass refParent = obj; /* Creat reference using child not an instances */


        obj.Add(5, 5);
        obj.Sub(5, 5);
        obj.Mul(5, 5);
        obj.Div(5, 5);
        refParent.Add(3, 3);
        refParent.Mul(3, 3);

        asysnchronous obj1 = new asysnchronous();
        obj1.Method1();

        Class2 obj2 = new Class2();
      /*  obj2.Method1();       We can not able to  access the private method */
        //obj2.Method2();  
        Class3 obj3 = new Class3();
        obj3.Method1();
        obj3.Method2();

    }
}

