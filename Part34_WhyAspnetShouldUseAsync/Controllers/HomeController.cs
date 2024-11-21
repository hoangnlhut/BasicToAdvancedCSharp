using Microsoft.AspNetCore.Mvc;
using Part34_WhyAspnetShouldUseAsync.Models;
using System.Diagnostics;

namespace Part34_WhyAspnetShouldUseAsync.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        private async Task<Product> FindProductAsync(int productId, string name)
        {
            await Task.Delay(1000);
            return new Product() { Id = productId, Name = name };
        }

        private Product FindProduct(int productId, string name)
        {
            Task.Delay(1000).Wait();
            return new Product() { Id = productId, Name = name };
        }

        [Route("/taskresultwait")]
        public IActionResult TaskResultWait()
        {
            var product = FindProduct(1, "Apple");
            return Ok("/taskresultwait:success");
        }

        [Route("/taskawait")]
        public async Task<IActionResult> TaskAwait()
        {
            var product = await FindProductAsync(1, "Apple");
            return Ok("/taskawait:success");
        }
    }
}
