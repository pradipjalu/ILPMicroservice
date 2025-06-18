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

        private readonly IUserService userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            this.logger = logger;
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await userService.GetUsersAsync();

            return View();
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
