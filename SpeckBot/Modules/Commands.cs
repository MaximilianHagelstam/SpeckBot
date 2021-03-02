using System;
using System.Net;
using System.Threading.Tasks;
using Discord.Commands;

namespace SpeckBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("bitcoin")]
        public async Task Bitcoin(string currency = "EUR")
        {
            await ReplyAsync($"1 Bitcoin is worth {GetBitcoinPrice(currency)} {currency.ToUpper()}");
        }

        private double GetBitcoinPrice(string currency)
        {
            string URI = String.Format($"https://blockchain.info/tobtc?currency={currency}&value=1");

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
