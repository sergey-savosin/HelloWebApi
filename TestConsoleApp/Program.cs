using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string uri = "http://localhost.fiddler:64066/api/employees/12345";

            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadString(uri);
                }
                Console.WriteLine("Done.");
            }
            catch(Exception e)
            {
                Console.WriteLine($"error: {e.Message}");
            }
        }
    }
}
