using System;
using System.Net;

namespace SpeckBot.Modules
{
    class MarketPrices
    {
        public double GetBitcoinPrice(string currency)
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
