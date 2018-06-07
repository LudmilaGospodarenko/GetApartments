using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Onliner
{
    public class Initial
    {
        const string url =
            "https://pk.api.onliner.by/search/apartments?price%5Bmin%5D=4696&price%5Bmax%5D=60000&currency=usd&bounds%5Blb%5D%5Blat%5D=53.70077162898384&bounds%5Blb%5D%5Blong%5D=27.36900329589844&bounds%5Brt%5D%5Blat%5D=54.09483886777795&bounds%5Brt%5D%5Blong%5D=27.754211425781254&page={0}&_=0.40143548690752895";

        static void Main()
        {
            Task t = new Task(DownloadPageAsync);
            t.Start();
            Console.WriteLine("Downloading page...");
            Console.ReadKey();
        }

        static async void DownloadPageAsync()
        {
            using (HttpClient client = new HttpClient())
            {

                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                for (int page = 1; page <= 15; page++)
                    using (HttpResponseMessage response = await client.GetAsync(string.Format(url, page)))
                    using (HttpContent content = response.Content)
                    {
                        string result = await content.ReadAsStringAsync();
                        var json = JsonConvert.DeserializeObject<RootObject>(result);
                        if (json.page.current < page)
                        {
                            Console.WriteLine($"Last page ({json.page.current}) proceeded, check output files.");
                            break;
                        }

                        using (StreamWriter w = File.AppendText(@"json.txt"))
                        {
                            w.WriteLine(result);
                        }
                        using (StreamWriter w = File.AppendText(@"result.txt"))
                        {
                            w.WriteLine(json.ToString());
                        }
                        Console.WriteLine($"page {page} proceeded.");
                    }
                Console.WriteLine("All pages proceeded, check output files.");
            }
        }
    }


}
