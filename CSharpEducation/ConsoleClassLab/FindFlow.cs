using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpBasics
{
    internal class FindFlow
    {
        public static void Flow()
        {
            Console.WriteLine("=== Control Flow Demo ===");

            // if
            int age = 20;

            if (age >= 18)
            {
                Console.WriteLine("You are eligible to vote.");
            }

            // if-else
            int marks = 45;

            if (marks >= 35)
                Console.WriteLine("You Passed");
            else
                Console.WriteLine("You Failed");

            //else-if ladder
            int score = 75;

            if (score >= 90)
                Console.WriteLine("Grade A");
            else if (score >= 70)
                Console.WriteLine("Grade B");
            else if (score >= 50)
                Console.WriteLine("Grade C");
            else
                Console.WriteLine("Grade D");

            // switch
            int day = 2;

            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                default:
                    Console.WriteLine("Invalid Day");
                    break;
            }

            // for loop
            Console.WriteLine("For Loop:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("i = " + i);
            }

            // while loop
            Console.WriteLine("While Loop:");
            int j = 1;

            while (j <= 3)
            {
                Console.WriteLine("j = " + j);
                j++;
            }

            // do-while loop
            Console.WriteLine("Do-While Loop:");
            int k = 1;

            do
            {
                Console.WriteLine("k = " + k);
                k++;
            }
            while (k <= 2);

            // foreach loop
            Console.WriteLine("Foreach Loop:");
            int[] numbers = { 10, 20, 30 };

            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            // break and continue
            Console.WriteLine("Break and Continue Example:");

            for (int x = 1; x <= 5; x++)
            {
                if (x == 3)
                    continue;   // skips 3

                if (x == 5)
                    break;      //stops loop

                Console.WriteLine(x);
            }

            //goto
            Console.WriteLine("Goto Example:");
            goto SkipLine;

            Console.WriteLine("This line will be skipped.");

            SkipLine:
                Console.WriteLine("Goto executed.");

                //return
                Console.WriteLine("Calling Method...");
                FindFlow.ShowMessage();

                Console.WriteLine("Program End.");
                Console.ReadKey();
        }

        static void ShowMessage()
        {
            Console.WriteLine("Inside Method");
            return; // exits method
        }


    }
}
