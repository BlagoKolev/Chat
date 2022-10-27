﻿using Chat.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Hubs
{
    public class ChatHub : Hub
    {
        //private UserManager<ApplicationUser>? _userManager;

        public ChatHub(UserManager<ApplicationUser> userManager)
        {
            //this._userManager = userManager;
        }
        [Authorize]
        public async Task SendGlobalMessage()
        {
            var user = Context.User.Identity.Name;
            await Clients.All.SendAsync("receiveGlobalMessage",user);
        }


    }
}