using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Models;
using System.Diagnostics;

namespace Northwind.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            #region View yazmadığımız için ilk etapta test etmek adına yazıldı. 
            //WebApiClient<Category> apiClient = new WebApiClient<Category>();
            ////var result = await apiClient.Get(ApiUrl.Categories + "1"); //+ "1" id belirterek getiriyoruz Get yerine GetAll dersek bunu yazmıyoruz.
            //Category category = new Category { id = 0, name = "Tekstil", description = "Giyim Kusam" };
            //var result = await apiClient.Post(ApiUrl.Categories, category)
            ////var result1 = await apiClient.Put(ApiUrl.Categories, category); 
            #endregion

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