using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gowri.Lab.CSharp
{
    internal class AsyncAwaitExample
    {
        public static async Task Main()
        {
            Console.WriteLine("Start");

            string result = await GetDataAsync();

            Console.WriteLine(result);
            Console.WriteLine("End");
        }

        public static async Task<string> GetDataAsync()
        {
            await Task.Delay(5000);
            return "Done";
        }
    }
}
