
using System;

namespace CSharpBasics
{
    internal class ConsoleClass
    {
        public static void ConsoleMethods()
        {
            //  Write/WriteLine with strings and variables
            string name = "User";
            int age = 25;

            Console.Write("Hello ");
            Console.Write(name);
            Console.WriteLine("!");  // Combines writes + newline

            Console.WriteLine($"Age: {age}");  // WriteLine(variable)
            Console.WriteLine();  // Empty line

            Console.Title = "Open New Terminal";
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Colored text!");
            Console.ResetColor();  // Restores defaults

            // Beep sound
            Console.WriteLine("Listen for beep...");
           // Console.Beep(1000, 500);  // 1000Hz for 500ms

            // Clear screen
            Console.WriteLine("\nPress any key to clear screen...");
            Console.ReadKey();
            Console.Clear();  // Clears everything above

            Console.Title = "after clear the screen";
            Console.Write("Enter your name: ");
            string? inputName = Console.ReadLine();
            Console.WriteLine(inputName); // Reads until Enter

            Console.Write("Press any key (not displayed): ");
            var keyInfo = Console.ReadKey();  // Captures key + modifiers
            
            Console.WriteLine($"\nYou pressed: {keyInfo.Key} (ASCII: {(int)keyInfo.KeyChar})");

            // Input demonstrations
            Console.Write("Enter a character: ");
            int ascii = Console.Read();  // Returns ASCII (e.g., 65 for 'A')
            Console.WriteLine($"ASCII: {ascii}");

            Console.WriteLine("\nAll features demonstrated!");
            Console.ReadKey();  // Wait before exit

            Console.Clear();

            //Get the integer input value usiing Convert.ToInt32
            Console.WriteLine("Eneter two Numbers:");
         
            int Number1 = Convert.ToInt32(Console.ReadLine());
            int Number2 = Convert.ToInt32(Console.ReadLine());
            int Result = Number1 + Number2;
            Console.WriteLine($"The Sum is: {Result}");
            Console.WriteLine($"The Sum is: {Number1 + Number2}");
            Console.ReadKey();

        }
    }

}