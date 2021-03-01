using Discord;
using Discord.WebSocket;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace SpeckBot
{
    class Program
    {
        public static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();

            _client.Log += Log;

            var token = File.ReadAllText("token.txt");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();

            await Task.Delay(-1);
        }

        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private double getBitcoinPrice()
        {
            string URI = String.Format(@"https://blockchain.info/tobtc?currency=EUR&value={0}", 1);

            WebClient client = new WebClient
            {
                UseDefaultCredentials = true
            };

            string data = client.DownloadString(URI);

            double result = 1 / Convert.ToDouble(data.Replace('.', ','));

            return result;
        }
    }
}
