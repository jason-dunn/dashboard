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
    public class MinerHub : Hub
    {
        //readonly CancellationToken stoppingToken;
        //WinhostWorker winhostWorker = new WinhostWorker();

        //public async Task Start()
        //{
        //   // await winhostWorker.StartAsync(stoppingToken);
        //   // await sender.StartAsync(stoppingToken);
        //}
        

        public async Task SendMiners(bool IsConnected)
        {
            int _m = 0;
            int _y = 0;
            var connectionstring = "Data Source = tcp:s23.winhost.com; User ID = DB_146837_jasonisdunn_user; Password = RJ2cc7a#z; Connect Timeout = 600; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False"; ;
            var optionsBuilder = new DbContextOptionsBuilder<TestDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);
            Miner[] miners = new Miner[10];
            Yeild[] yeilds = new Yeild[10];
            try
            {
                using (var context = new TestDbContext(optionsBuilder.Options))
                {
                    foreach (var m in context.Miner)
                    {
                        miners[_m] = m;
                        _m++;
                    }
                    foreach (var y in context.Yeild)
                    {
                        yeilds[_y] = y;
                        _y++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            await Clients.All.SendAsync("RecieveMiners", miners, yeilds, IsConnected, true);
        }

        public async Task StopMiners(bool IsConnected)
        {
            Miner[] miners = new Miner[10];
            Yeild[] yeilds = new Yeild[10];
            await Clients.All.SendAsync("RecieveMiners", miners, yeilds, IsConnected, false);
        }
    }
}

