using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace dashboard.Server
{
    public class WinhostWorker : BackgroundService
    {
        const int amount = 11;
        const int min = 4000;
        const int max = 5000;
        private readonly ILogger<WinhostWorker> _logger;

        private WinhostIWorker[] _WinhostIWorker = new WinhostIWorker[amount];

        public WinhostWorker()
        {
            //_logger = _logger;
            for (int i = 1; i <= amount; i++)
            {
                _WinhostIWorker[i - 1] = new WinhostIWorker((ILogger<WinhostWorker>)_logger);
            }
        }

        public WinhostWorker(ILogger<WinhostWorker> logger)
        {
            _logger = logger;
            for (int i = 1; i <= amount; i++)
            {
                _WinhostIWorker[i - 1] = new WinhostIWorker(_logger);
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Random rnd = new Random();
            int count = 0;
            int spawn = rnd.Next(1, amount);
            int delay = rnd.Next(min, max);
            while (!stoppingToken.IsCancellationRequested)
            {
                count++;

                await Task.Delay(delay, stoppingToken);
                try
                {
                    await _WinhostIWorker[spawn-1].DoWork(stoppingToken, this, count, spawn);
                }
                catch (Exception ex)
                {
#if DEBUG
                    {
                        //_logger.LogError(ex.ToString());
                    }
#else
                    {
                        // log.WriteEntry(ex.ToString(), System.Diagnostics.EventLogEntryType.Error);
                        //_logger.LogError(ex.ToString());
                    }
#endif
                }
                finally
                {
                    if (count == 1)
                    {
#if DEBUG
                        {
                         //   _logger.LogInformation("{worker} - The Value is: {value}, The DateTime is: {datetime}, The Delay is: {delay}", NewValue.getWorker(), NewValue.getValue(), NewValue.getDateTime(), delay.ToString());
                            try
                            {
                                //_logger.LogInformation("{worker} - The Value is: {value}, The DateTime is: {datetime}, The Delay is: {delay}", NewValue.getWorker(), NewValue.getValue(), NewValue.getDateTime(), delay.ToString());
                                //string str = $"{ NewValue.getWorker()} - The Value is: {NewValue.getValue()}, The DateTime is: {NewValue.getDateTime()}, The Delay is: {delay.ToString()}";
                                //string str = $"Spawn {spawn}";
                                //Debug.WriteLine(str);
                               
                                //_logger.LogInformation(str);
                               // log.WriteEntry(str, System.Diagnostics.EventLogEntryType.Information);
                            }
                            catch (Exception ex)
                            {
                                //_logger.LogInformation(ex.ToString());
                                throw;
                            }
                        }
#else
                        {


                        }
#endif    
                    }
                }
            }
        }
        //protected override Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
