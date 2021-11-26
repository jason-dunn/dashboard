using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using dashboard.Shared;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace dashboard.Server.Hubs
{
    public class MarqueeHub : Hub
    {
        public async Task SendMarquee(bool IsConnected)
        {
            Miner marqueeMiner = new Miner();
            Yeild marqueeYeild = new Yeild();
            var rnd = new Random();
            int r = rnd.Next(1, 10);
            var connectionstring = "Data Source = tcp:s23.winhost.com; User ID = DB_146837_jasonisdunn_user; Password = RJ2cc7a#z; Connect Timeout = 600; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"; ;
            var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            try
            {
                using (var context = new TestDbContext(optionsBuilder.Options))
                {
                    marqueeMiner = context.Miner.SingleOrDefault(c => c._worker == r);
                    marqueeYeild = context.Yeild.SingleOrDefault(c => c._worker == r);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            await Clients.All.SendAsync("RecieveMarquee", marqueeMiner, marqueeYeild, IsConnected);
        }

        public async Task StopMarquee(bool IsConnected)
        {
            Miner marqueeMiner = new Miner();
            Yeild marqueeYeild = new Yeild();
            await Clients.All.SendAsync("RecieveMarquee", marqueeMiner, marqueeYeild, IsConnected);
        }
    }
}
