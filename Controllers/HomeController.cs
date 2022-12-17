using AdventureLabNew.Data;
using AdventureLabNew.Models;
using AdventureLabNew.Models.ViewModels;
using AdventureLabNew.Utility;
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
            var cardList = new List<Card>();

            if (HttpContext.Session.Get<IEnumerable<Card>>(PathManager.SessionCart) != default
                && HttpContext.Session.Get<IEnumerable<Card>>(PathManager.SessionCart).Count() > 0)
            {
                cardList = HttpContext.Session.Get<List<Card>>(PathManager.SessionCart);
            }

            var detailsViewModel = new DetailsViewModel()
            {
                Product = _db.Products.Include(x => x.Category).Include(x => x.MyModel).FirstOrDefault(x => x.Id == id),
                IsInCart = false
            };

            // проверка на наличие товара в корзине
            // если товар есть в корзине, то IsInCart = true
            foreach (var card in cardList)
            {
                if (card.ProductId == id)
                {
                    detailsViewModel.IsInCart = true;
                }
            }

            return View(detailsViewModel);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int? id)
        {
            if (id == default)
                return NotFound();

            List<Card> cardList = new List<Card>();

            if (HttpContext.Session.Get<IEnumerable<Card>>(PathManager.SessionCart) != default
                && HttpContext.Session.Get<IEnumerable<Card>>(PathManager.SessionCart).Any())
            {
                cardList = HttpContext.Session.Get<List<Card>>(PathManager.SessionCart);
            }

            for (int i = 0; i < cardList.Count; i++)
            {
                if (cardList[i].ProductId == id)
                {
                    cardList.RemoveAt(i);
                    break;
                }
            }

            HttpContext.Session.Set(PathManager.SessionCart, cardList);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddCard(int? id)
        {
            if (id == default)
                return NotFound();

            List<Card> cardList = new List<Card>();

            if (HttpContext.Session.Get<IEnumerable<Card>>(PathManager.SessionCart) != default
                && HttpContext.Session.Get<IEnumerable<Card>>(PathManager.SessionCart).Any())
            {
                cardList = HttpContext.Session.Get<List<Card>>(PathManager.SessionCart);
            }

            cardList.Add(new Card() { ProductId = id ?? 0 });

            HttpContext.Session.Set(PathManager.SessionCart, cardList);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}