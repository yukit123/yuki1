using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat
{
    [HubName("MySignalrHub")]
    public class MySignalrHub : Hub
    {
        public void GetDetails(string s)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<MySignalrHub>();
            //  context.Clients.Client("1").broadcastMessage(s);
            context.Clients.All.BroadCast(s);
        }
    }
}