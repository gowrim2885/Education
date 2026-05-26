using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.Lab.CSharp
{
    internal class Variable_practice
    {
       

         double Calculate_bmi(double height, double weight){
            double bmi = weight / (height * height);
            return bmi;
        }

        public void CheckStatus(double Bmi)
        {
            switch (Bmi)
            {
                case < 18.5:
                    Console.WriteLine("Underweight");
                    break;
                case >= 18.5 and < 25:
                    Console.WriteLine("Normal weight");
                    break;
                case >= 25 and < 30:
                    Console.WriteLine("Overweight");
                    break;
                default:
                    Console.WriteLine("Obesity");
                    break;
            }
        }

        public static void Entrypoint()
        {
            Console.WriteLine("Enter your Height");
            double _height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter your Weight");
            double _weight = Convert.ToDouble(Console.ReadLine());

            Variable_practice Obj = new Variable_practice();

            double Bmi = Obj.Calculate_bmi(_height, _weight);
            Obj.CheckStatus(Bmi);

        }
    }
    }

