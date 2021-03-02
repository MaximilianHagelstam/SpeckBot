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
        [Command("bitcoin")]
        public async Task Bitcoin(string currency = "EUR")
        {
            await ReplyAsync($"1 Bitcoin is worth {GetBitcoinPrice(currency)} {currency.ToUpper()}");
        }

        [Command("roll")]
        public async Task Roll()
        {
            Random random = new Random();

            string[] voiceUsers = { "Luka", "Niilo", "William", "Maxim" };

            string rollWinner = voiceUsers[random.Next(voiceUsers.Length)];

            await ReplyAsync($"The winner is {rollWinner}");
        }

        [Command("read")]
        public async Task ReadSerialData(string serialData)
        {
            if (serialData == "temp" || serialData == "temperature")
            {
                await ReplyAsync($"The temperature in Maxims room is {GetTemperature()}");
            }

            else if (serialData == "hum" || serialData == "humidity")
            {
                await ReplyAsync("Humidity coming soon");

            }
        }

        private string GetTemperature()
        {
            SerialPort mySerialPort = new SerialPort("COM4", 9600);

            mySerialPort.Open();

            string temperature = mySerialPort.ReadLine();

            mySerialPort.Close();

            return temperature;
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
