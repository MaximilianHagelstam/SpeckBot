using System;
using System.IO.Ports;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Discord.Commands;

namespace SpeckBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        ArduinoData arduino = new ArduinoData();
        MarketPrices price = new MarketPrices();
        Random random = new Random();

        [Command("bitcoin")]
        public async Task Bitcoin(string currency = "EUR")
        {
            double bitcoinPrice = price.GetBitcoinPrice((currency));

            await ReplyAsync($"1 Bitcoin is worth {bitcoinPrice} {currency.ToUpper()}");
        }

        [Command("roll")]
        public async Task Roll()
        {
            string[] voiceUsers = { "Luka", "Niilo", "William", "Maxim" };

            string rollWinner = voiceUsers[random.Next(voiceUsers.Length)];

            await ReplyAsync($"The winner is {rollWinner}");
        }

        [Command("smoke")]
        public async Task ReadSerialData()
        {

            string smoke = arduino.GetSmoke();

            await ReplyAsync($"Smoke: {smoke}");
        }
    }
}
