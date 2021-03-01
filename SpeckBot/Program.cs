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
        public static Task Log(LogMessage message)
        {
            Console.WriteLine(message.ToString());
            return Task.CompletedTask;
        }

        public static Task CommandHandler(SocketMessage message)
        {
            // Filters
            if (!message.Content.StartsWith('!'))
                return Task.CompletedTask;

            if (message.Author.IsBot)
                return Task.CompletedTask;

            int lengthOfCommand;
            if (message.Content.Contains(' '))
                lengthOfCommand = message.Content.IndexOf(' ');
            else
                lengthOfCommand = message.Content.Length;

            string command = message.Content[1..lengthOfCommand].ToLower();

            // Commands
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
                message.Channel.SendMessageAsync($"The price of Bitcoin is currently {GetBitcoinPrice()}€");
            }

            return Task.CompletedTask;
        }

        private static double GetBitcoinPrice()
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
