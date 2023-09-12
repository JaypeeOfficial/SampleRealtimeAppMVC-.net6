using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SampleRealTimeAppMVC.Contracts;
using SampleRealTimeAppMVC.Hubs;
using SampleRealTimeAppMVC.Models;
using System.Diagnostics;

namespace SampleRealTimeAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHubContext<ProductHub, IProductHub> _hub;

        public HomeController(IHubContext<ProductHub, IProductHub> hub)
        {
            _hub = hub;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult AddTestProduct()
        {
            _hub.Clients.All.ReceiveProduct("from controller", $"Added {DateTime.Now:f}", "A", "create");
            return Content("Added product in backend");
        }


    }
}