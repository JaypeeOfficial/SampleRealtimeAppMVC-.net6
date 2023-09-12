using Microsoft.AspNetCore.SignalR;
using SampleRealTimeAppMVC.Contracts;

namespace SampleRealTimeAppMVC.Hubs
{
    public class ProductHub : Hub<IProductHub>
    {

        public async Task SendProduct(string name, string description, string status, string actionType)
        {
            await Clients.All.ReceiveProduct(name, description, status, actionType);
        }


    }
}
