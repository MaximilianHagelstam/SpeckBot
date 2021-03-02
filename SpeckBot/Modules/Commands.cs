using System;
using System.Net;
using System.Threading.Tasks;
using Discord.Commands;

namespace SpeckBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("bitcoin")]
        public async Task Greeting()
        {
            await ReplyAsync($"The price of Bitcoin is currently {GetBitcoinPrice()}€");
        }

        private double GetBitcoinPrice()
        {
            string URI = String.Format(@"https://blockchain.info/tobtc?currency=EUR&value={0}", 1);

            WebClient client = new WebClient
            {
                UseDefaultCredentials = true
            };

            string data = client.DownloadString(URI);

            double result = 1 / Convert.ToDouble(data.Replace('.', ','));

            return Math.Round(result, 2);
        }
    }
}
