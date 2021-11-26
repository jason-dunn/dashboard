using System;
using System.Threading;
using dashboard.Client.Pages;

namespace dashboard.Server
{
 
    public class StatusChecker
    {
        private int invokeCount;
        private int maxCount;
       // jasonisdunn.Client.Pages.Index _Index = new jasonisdunn.Client.Pages.Index();
        public StatusChecker(int count)
        {
            invokeCount = 0;
            maxCount = count;
        }

        // This method is called by the timer delegate.
        public async void CheckStatus(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;
            Console.WriteLine("{0} Checking status {1,2}.",
                DateTime.Now.ToString("h:mm:ss.fff"),
                (++invokeCount).ToString());
       
            if (invokeCount == maxCount)
            {
                // Reset the counter and signal the waiting thread.
                invokeCount = 0;
                autoEvent.Set();
            }
            //await System.Threading.Tasks.Task.Delay(0);
        }
    }
}
