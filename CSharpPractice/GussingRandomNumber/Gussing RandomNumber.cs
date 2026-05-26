using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GussingRandomNumber
{
    public class Gussing_RandomNumber
    {
        public static void Main()
        {
            
            int RandomNumber = GenerateRandomNumber();
            int chance = 3;
            while (chance  > 0)
            {
                Console.Write("\n Guess the Number Between 0 to 10\t");
                int Input = Convert.ToInt32(Console.ReadLine());

                if(Input < 1 || Input > 10)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");
                }

                else if (Input == RandomNumber)
                {
                    Console.WriteLine($"\n \n ***Congratulations! You Guess the correct number at {chance} attempt.***");
                    checkInterest();
                    break;
                }
                else
                {
                    Console.Write($"Sorry, you guessed the wrong number.");
                    
                    if(Input > RandomNumber)
                    {
                        Console.WriteLine(" Your Answer is to Large");
                    }
                    else if(Input < RandomNumber)
                    {
                        Console.WriteLine(" Your Answer is small");
                    }
                   
                    chance--;
                }
            }

             if(chance == 0){
                Console.WriteLine(" Game Over! You've used all your chances. The correct number was: " + RandomNumber);
                checkInterest();
            }

        }
        public static void checkInterest()
        {
            Console.Write("Do you want to play again? (yes/no)\t");
            string? answer = Console.ReadLine().ToLower();
            if (answer == "yes")
            {
                Main();
            }
            else
            {
                Console.WriteLine("Thank you for playing! Goodbye!");
            }
        }
        public static int GenerateRandomNumber()
        {
            Random rand = new Random();
            int RandomNumber = rand.Next(0, 11);
            return RandomNumber;
        }
    }
}
