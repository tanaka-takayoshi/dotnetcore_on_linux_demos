
using System.Collections.Generic;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Hubs;

namespace RHTE2016SignalRDemo.Hubs
{
    [HubName("message")]
    public class MessageHub : Hub
    {

        public IEnumerable<string> GetValues()
        {
            return new[] { "ほげほげ", "ふがふが", "はうはう" };
        }

        public static int Count { get; set; } = 0;
        public void Send()
        {
            Clients.All.broadcast(++Count);
        }

        public int GetCurrent()
        {
            return Count;
        }
    }
}