using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.CodeForce.CSharp
{
    public class _10_stringTask
    {
        public static void SolveStringTask()
        {
            string? input = Console.ReadLine();
            StringBuilder result = new StringBuilder();

            if(input == null)
            {
                return;
            }

            foreach (char c in input)
            {
                if ("aeiouyAEIOUY".Contains(c))
                {
                    continue;

                }
                else
                {
                    result.Append('.');
                    if (char.IsUpper(c))
                    {
                        result.Append(char.ToLower(c));
                    }
                    else
                    {
                        result.Append(c);
                    }
                }

            }
            Console.WriteLine(result.ToString());
        }
    }
}
