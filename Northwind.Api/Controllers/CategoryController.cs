using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Models;

namespace Northwind.Api.Controllers
{
    public class CategoryController : Controller
    {
        private readonly WebApiClient<Category> apiClient;
        public CategoryController()
        {
            apiClient = new WebApiClient<Category>();
        }
        public async Task<IActionResult> Index()
        {
            var result = await apiClient.GetAll(ApiUrl.Categories);
            //Category category = new Category { id = 0, name = "Tekstil", description = "Giyim kusam" };
            //var result = await apiClient.Post(ApiUrl.Categories, category);

            return View(result);
        }


        [HttpGet]
        public async Task<IActionResult> Create() // WebApiClient'deki  Post
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category) // WebApiClient'deki  Post
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            Category category2 = new Category
            {
                id = category.id,
                name = category.name,
                description = category.description,
            };
            var result = await apiClient.Post(ApiUrl.Categories, category2);
            if (result)
            {
                return RedirectToAction("Index", "Category");
            }
            else
            {
                ModelState.AddModelError("", "bir hata oluştu");
                return View(category);

            }

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await apiClient.Delete(ApiUrl.Categories, id);


            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id) //WebApiClient'deki Put
        {
            var result = await apiClient.Get(ApiUrl.Categories + id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Category category) //WebApiClient'deki Put
        {

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            Category category2 = new Category
            {
                id = category.id,
                name = category.name,
                description = category.description,
            };
            var result = await apiClient.Put(ApiUrl.Categories, category2);

            if (true)
            {
                return RedirectToAction("Index", "Category");
            }
            else
            {
                ModelState.AddModelError("", "bir hata oluştu");
                return View(category);

            }

            return View(result);

        }
    }
}
