using System;
using System.Thread.Task;
using System.Net.Http;

namespace Gowri.Lab.CSharp
{
    public class ExternalAPIExample
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Calling API...");

            // Step 1: Create HttpClient
            HttpClient client = new HttpClient();

            // Step 2: API URL
            string url = "https://jsonplaceholder.typicode.com/posts/1";

            try
            {
                // Step 3: Call API
                string response = await client.GetStringAsync(url);

                // Step 4: Print response
                Console.WriteLine("Response received:");
                Console.WriteLine(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Finished");
        }
    }

}