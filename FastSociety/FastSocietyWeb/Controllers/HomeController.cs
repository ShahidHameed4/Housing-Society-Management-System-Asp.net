using FastSocietyWeb.Data;
using FastSocietyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FastSocietyWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult loginBtn(Member obj)
        {
           Member temp = _db.customers.Find(obj.Member_ID);
            
            _db.obj = temp;


            return RedirectToAction("Index");
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