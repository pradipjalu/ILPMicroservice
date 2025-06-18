using Microsoft.AspNetCore.Mvc;
using Microsoft.ILP.Web.Models;
using Microsoft.ILP.Web.Services;
using System.Diagnostics;
using System.Net.Http;

namespace Microsoft.ILP.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        //private readonly IHttpClientFactory httpClientFactory;

        private readonly IUserService userService;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory, IUserService userService)
        {
            this.logger = logger;
            //this.httpClientFactory = httpClientFactory;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userService.GetUsersAsync();

            return View();

            //using (var client = httpClientFactory.CreateClient("ILPMicroserviceClient"))
            //{
            //    HttpResponseMessage usersResponse = await client.GetAsync("endpoint");

            //    if (usersResponse.IsSuccessStatusCode)
            //    {
            //        var users = await usersResponse.Content.ReadAsStringAsync();
            //    }

            //    HttpResponseMessage productsResponse = await client.GetAsync("endpoint");

            //    if (productsResponse.IsSuccessStatusCode)
            //    {
            //        var products = await productsResponse.Content.ReadAsStringAsync();
            //    }

            //    HttpResponseMessage ordersResponse = await client.GetAsync("endpoint");

            //    if (ordersResponse.IsSuccessStatusCode)
            //    {
            //        var orders = await ordersResponse.Content.ReadAsStringAsync();
            //    }

            //    return View();
            //}
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
