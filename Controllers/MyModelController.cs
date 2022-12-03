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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MyModel myModel)
        {
            if (!ModelState.IsValid)
                return View(myModel);

            _db.MyModels.Add(myModel);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == default || id == 0)
                return NotFound();

            var myModel = _db.MyModels.Find(id);

            if (myModel == default)
                return NotFound();

            return View(myModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(MyModel myModel)
        {
            if (!ModelState.IsValid)
                return View(myModel);

            _db.MyModels.Update(myModel);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            var myModel = _db.MyModels.Find(id);

            if (myModel == default)
                return NotFound();

            _db.MyModels.Remove(myModel);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
