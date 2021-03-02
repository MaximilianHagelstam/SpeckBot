using System.Threading.Tasks;
using Discord.Commands;

namespace SpeckBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("hello")]
        public async Task Greeting()
        {
            await ReplyAsync("Hello team");
        }

        //private static double GetBitcoinPrice()
        //{
        //    string URI = String.Format(@$"https://blockchain.info/tobtc?currency=EUR&value={0}", 1);

        //    WebClient client = new WebClient
        //    {
        //        UseDefaultCredentials = true
        //    };

        //    string data = client.DownloadString(URI);

        //    double result = 1 / Convert.ToDouble(data.Replace('.', ','));

        //    return result;
        //}
    }
}
