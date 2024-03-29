﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatDemo.Hubs
{
    public class ChatHub :Hub
    {
    //    public override Task OnConnectedAsync()
    //    {
    //        Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
    //        return base.OnConnectedAsync();
    //    }
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendToUser(string user, string receiverConnectionId, string message)
        {
            await Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage", user, message);
        }
        public string GetConnectionId() => Context.ConnectionId;
    }
}
