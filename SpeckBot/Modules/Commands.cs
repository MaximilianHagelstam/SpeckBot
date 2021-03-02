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

        [Command("read")]
        public async Task ReadSerialData(string serialData)
        {
            if (serialData == "temp" || serialData == "temperature")
            {
                string temperature = arduino.GetTemperature();

                await ReplyAsync($"The temperature in Maxims room is {temperature}");
            }

            else if (serialData == "hum" || serialData == "humidity")
            {
                await ReplyAsync("Humidity coming soon");

            }
        }
    }
}
