using AdventureLabNew.Data;
using AdventureLabNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdventureLabNew.Controllers
{
    public class MyModelController : Controller
    {
        private ApplicationDbContext _db;

        public MyModelController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            IEnumerable<MyModel> categories = _db.MyModels;

            return View(categories);
        }
    }
}
