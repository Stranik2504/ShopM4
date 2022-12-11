using AdventureLabNew.Data;
using AdventureLabNew.Models;
using AdventureLabNew.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AdventureLabNew.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel()
            {
                Products = _db.Products,
                Categories = _db.Categories
            };

            return View(homeViewModel);
        }

        public IActionResult Details(int id)
        {
            var detailsViewModel = new DetailsViewModel()
            {
                Product = _db.Products.Include(x => x.Category).Include(x => x.MyModel).FirstOrDefault(x => x.Id == id),
                IsInCart = false
            };

            return View(detailsViewModel);
        }

        [HttpPost]
        public IActionResult AddCard(int? id)
        {
            

            return View();
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}