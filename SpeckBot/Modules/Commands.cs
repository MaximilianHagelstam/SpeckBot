using System;
using System.Threading.Tasks;
using Discord.Commands;

namespace SpeckBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        Random random = new Random();

        SerialCommunication serial = new SerialCommunication();
        MarketPrices price = new MarketPrices();
        PiCommunication pi = new PiCommunication();

        int SMOKE_THRESHOLD = 400;

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
        public async Task Smoke()
        {

            int smoke = serial.GetSerialData();

            if (smoke >= SMOKE_THRESHOLD)
            {
                await ReplyAsync($"TOO MUCH SMOKE: {smoke}ppm");
            }
            else
            {
                await ReplyAsync($"Smoke: {smoke}ppm");
            }
        }

        [Command("relay")]
        public async Task Relay(string state)
        {
            await pi.SendPostRequest(state);
            await ReplyAsync($"LED turned {state.ToUpper()}");
        }
    }
}