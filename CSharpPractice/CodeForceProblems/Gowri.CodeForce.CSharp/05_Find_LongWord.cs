using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.CodeForce.CSharp
{
    public class _05_Find_LongWord
    {
        public static void Find_LongWord() {
            int n = Convert.ToInt32(Console.ReadLine());

            string[] words = new string[n];

            for (int i = 0; i < n; i++) { 
                string value = Console.ReadLine();
                words[i] = value;
            }

            foreach (string word in words)
            {


                int word_length = word.Length;
                //Console.WriteLine(word_length);

                if (word_length > 10)
                {
                    char start = word[0];
                    string char_count = Convert.ToString(word_length - 2); 
                    char end = word[word_length - 1];

                    //Console.WriteLine(start);
                    //Console.WriteLine(char_count);
                    //Console.WriteLine(end);

                    Console.WriteLine(start + char_count + end);


                }
                else
                {
                    Console.WriteLine(word);
                }
            }

        }
    }
}
