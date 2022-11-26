using AdventureLabNew.Data;
using AdventureLabNew.Models;
using AdventureLabNew.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdventureLabNew.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            IEnumerable<Product> products = _db.Products;

            // Получеаем ссылки на сущности категорий
            foreach (var item in products)
            {
                // Сопастовление таблицы категорий и таблицы product
                item.Category = _db.Categories.FirstOrDefault(x => x.Id == item.CategoryId);
            }

            return View(products);
        }

        public IActionResult CreateEdit(int? id)
        {
            // Получем лист категорий для отправки его во View
            /*IEnumerable<SelectListItem> CategoriesList = _db.Categories.Select(x => 
            new SelectListItem { 
                Text = x.Name,
                Value = x.Id.ToString()
            });

            // Отправляем лист категорий во View
            //ViewBag.CategoriesList = CategoriesList;
            ViewData["CategoriesList"] = CategoriesList;*/

            ProductViewModel productViewModel = new()
            {
                Product = new Product(),
                CategoriesList = _db.Categories.Select(x =>
                new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                })
            };

            if (id != default)
                productViewModel.Product = _db.Products.Find(id);

            if (productViewModel.Product == default)
                return NotFound();

            return View(productViewModel);
        }
    }
}
