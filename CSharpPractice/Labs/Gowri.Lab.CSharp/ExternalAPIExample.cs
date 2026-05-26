using System;
using System.Net.Http;
using System.Threading.Tasks;

class ExternalAPIExamples
{
    public static async Task Main()
    {
        Console.WriteLine("Calling API...");

        HttpClient client = new HttpClient();
        string url = "https://www.google.com";

        try
        {
            Console.WriteLine("Before API call");

            HttpResponseMessage response = await client.GetAsync(url);

            Console.WriteLine("After API call");

            Console.WriteLine("Status Code: " + response.StatusCode);

            string data = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Response:");
            Console.WriteLine(data);
        }
        catch (Exception ex)
        {
            Console.WriteLine("ERROR OCCURRED:");
            Console.WriteLine(ex.ToString());
        }

        Console.WriteLine("Finished");
    }
}