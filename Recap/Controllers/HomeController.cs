using Microsoft.AspNetCore.Mvc;
using Recap.Models;
using System.Diagnostics;

namespace Recap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        RecapDbContext db = new RecapDbContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Arabalar()
        {
            List<Araba> arabaList = db.Arabalar.ToList();
            ViewBag.Arabalar = arabaList;
            return View();
        }

        [HttpPost]
        public IActionResult ArabaEkle(Araba araba)
        {
            if (ModelState.IsValid)
            {
                db.Arabalar.Add(araba);
                db.SaveChanges();
            }
            List<Araba> arabaList = db.Arabalar.ToList();
            ViewBag.Arabalar = arabaList;
            return RedirectToAction("Arabalar", "Home");
        }

        [HttpGet]
        public IActionResult ArabaSil(int id)
        {
            db.Arabalar.Remove(db.Arabalar.Find(id));
            db.SaveChanges();
            List<Araba> arabaList = db.Arabalar.ToList();
            ViewBag.Arabalar = arabaList;
            return RedirectToAction("Arabalar", "Home");
        }


        [HttpGet]
        public IActionResult ArabaDuzenle(int id)
        {
            Araba araba = db.Arabalar.Find(id);
            return View(araba);
        }

        [HttpPost]
        public IActionResult ArabaDuzenle(Araba araba)
        {
            db.Arabalar.Update(araba);
            db.SaveChanges();

            List<Araba> arabaList = db.Arabalar.ToList();
            ViewBag.Arabalar = arabaList;
            return RedirectToAction("Arabalar", "Home");
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