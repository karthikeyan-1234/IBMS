using Common.Domain;

using Microsoft.AspNetCore.SignalR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure
{
    public class ChatHub : Hub
    {
    }


    public class SignalRService : INotificationService
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public SignalRService(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync<T>(string methodName, T message)
        {
            await _hubContext.Clients.All.SendAsync(methodName, message);
        }
    }
}
