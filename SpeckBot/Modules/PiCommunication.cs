using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpeckBot.Modules
{
    class PiCommunication
    {
        string URI;

    public async Task SendPostRequest(string state)
        {
            URI = String.Format($"http://192.168.1.8:3000/{state}");
            using var client = new HttpClient();

            HttpResponseMessage result = await client.PostAsync(URI, null);
        }
    }
}
