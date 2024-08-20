using System;
using Microsoft.AspNetCore.SignalR;

namespace ChartsServer.Hubs
{
	public class SatisHub : Hub
	{
		public async Task SendMessageAsync()
		{
			await Clients.All.SendAsync("receiveMessage", "Merhaba");
		}
	}
}

