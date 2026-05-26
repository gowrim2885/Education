using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.Lab.CSharp
{
    public class interfaceSample
    {
        public interface IShape
        {
            void Draw();           // method declaration
            double GetArea();      // method declaration
        }

        public interface IPrintable
        {
            void Print();
        }

        public class Circle : IShape
        {
            public double Radius { get; set; }

            // Must implement all interface methods
            public void Draw()
            {
                Console.WriteLine("Drawing Circle");
            }

            public double GetArea()
            {
                return 3.14 * Radius * Radius;
            }
        }

        // 3️⃣ Class implementing multiple interfaces
        public class Document : IShape, IPrintable
        {
            public void Draw()
            {
                Console.WriteLine("Drawing Document Shape");
            }

            public double GetArea()
            {
                return 0; 
            }

            public void Print()
            {
                Console.WriteLine("Printing Document");
            }
        }

     
        public static void Main()
        {
            // Interface reference to Circle object
            IShape shape = new Circle { Radius = 5 };
            shape.Draw();
            Console.WriteLine("Area: " + shape.GetArea());

            Console.WriteLine("--------------------------------");

            // Interface reference to Document object
            IPrintable printable = new Document();
            printable.Print();

            IShape docShape = new Document();
            docShape.Draw();
            Console.WriteLine("Document Area: " + docShape.GetArea());
            
        }
    
    }
}
