using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.SignalR;

namespace dashboard.Server
{
    public class Sender 
    {


        //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        //{
        //    while (!stoppingToken.IsCancellationRequested)
        //    {
        //        // Create an AutoResetEvent to signal the timeout threshold in the
        //        // timer callback has been reached.
        //        var autoEvent = new AutoResetEvent(false);

        //        var statusChecker = new StatusChecker(10);

        //        // Create a timer that invokes CheckStatus after one second, 
        //        // and every 1/4 second thereafter.
        //        Console.WriteLine("{0:h:mm:ss.fff} Creating timer.\n",
        //                          DateTime.Now);
        //        var stateTimer = new Timer(statusChecker.CheckStatus,
        //                                   autoEvent, 1000, 250);

        //        // When autoEvent signals, change the period to every half second.
        //        autoEvent.WaitOne();
        //        stateTimer.Change(0, 500);
        //        Console.WriteLine("\nChanging period to .5 seconds.\n");

        //        // When autoEvent signals the second time, dispose of the timer.
        //        autoEvent.WaitOne();
        //        stateTimer.Dispose();
        //        Console.WriteLine("\nDestroying timer.");
        //    }
        //}
    }
}
