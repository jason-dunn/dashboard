using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using dashboard.Shared;
using dashboard.Server.Hubs;

namespace dashboard.Server
{
    public class WinhostIWorker : IWorker
    {
        public static event EventHandler MyEvent;
        private static void RaiseEvent()
        {
            MyEvent?.Invoke(typeof(MinerHub), EventArgs.Empty);
        }
        private readonly ILogger<WinhostWorker> _logger;
        //private Miner[] miners = new Miner[10];
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public WinhostIWorker(ILogger<WinhostWorker> logger)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            _logger = (ILogger<WinhostWorker>?)logger;
#pragma warning restore CS8601 // Possible null reference assignment.
        }

        public WinhostIWorker()
        {
        }


        public async Task DoWork(CancellationToken stoppingToken, WinhostWorker worker, int count, int intWorker)
        {
            Task tc;
            while (!stoppingToken.IsCancellationRequested)
            {
                switch (count)
                {
                    case 1:
                        {
                            tc = Task.Run(() => DoSomeWork());
                            break;
                        }
                    case 2:
                        {
                            await worker.StopAsync(stoppingToken).ConfigureAwait(true);
                            await worker.StartAsync(new CancellationToken()).ConfigureAwait(true);
                            break;
                        }

                    default:
                        {
                            tc = Task.Run(() => DoSomeWork());
                            break;
                        }
                }
                break;
            }
        }

        private static void DoSomeWork()
        {
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(0);
                break;
            }
         
        }
    }
}