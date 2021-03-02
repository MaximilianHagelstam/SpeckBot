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
        static SerialPort _serialPort;

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

        [Command("temp")]
        public async Task ReadSerialData()
        {
            SerialPort mySerialPort = new SerialPort("COM4", 9600);

            mySerialPort.Open();

            string data = mySerialPort.ReadLine();

            await ReplyAsync($"The temperature in Maxims room is {data}");

            mySerialPort.Close();
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
