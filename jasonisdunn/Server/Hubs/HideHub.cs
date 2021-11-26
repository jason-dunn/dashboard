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
    public class HideHub : Hub
    {
        public async Task SendHide(bool IsConnected)
        {
            try
            {
                await Clients.All.SendAsync("RecieveHide", false, IsConnected);
            }
            catch (Exception ex)
            {
                throw;
            }

           
        }
        public async Task StopHide(bool IsConnected)
        {
            try
            {
                await Clients.All.SendAsync("RecieveHide", true, IsConnected);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
