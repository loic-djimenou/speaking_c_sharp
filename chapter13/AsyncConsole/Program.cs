


using System;

using System.Threading;

using System.Threading.Tasks;

using System.Diagnostics;

using static System.Console;

using System.Linq;

using System.Net.Http;



namespace AsyncConsole

{

    class Program

    {
 

        async static Task Main(string[] args)

        {
            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("http://www.apple.com/");

            WriteLine("Apple's home page has {0:N0} bytes.", response.Content.Headers.ContentLength);

        }

    }

}
