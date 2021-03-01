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
            _client.MessageReceived += CommandHandler;
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

        private Task CommandHandler(SocketMessage message)
        {
            if (!message.Content.StartsWith('!'))
                return Task.CompletedTask;

            if (message.Author.IsBot)
                return Task.CompletedTask;

            int lengthOfCommand;
            if (message.Content.Contains(' '))
                lengthOfCommand = message.Content.IndexOf(' ');
            else
                lengthOfCommand = message.Content.Length;

            string command = message.Content.Substring(1, lengthOfCommand - 1).ToLower();

            //Commands begin here
            if (command.Equals("hello"))
            {
                message.Channel.SendMessageAsync($@"Hello {message.Author.Mention}");
            }
            else if (command.Equals("age"))
            {
                message.Channel.SendMessageAsync($@"Your account was created at {message.Author.CreatedAt.DateTime.Date}");
            }
            else if (command.Equals("bitcoin"))
            {
                message.Channel.SendMessageAsync($"The price of Bitcoin is currently {getBitcoinPrice()}€");
            }

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
