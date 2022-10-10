using FastSocietyWeb.Data;
using FastSocietyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastSocietyWeb.Controllers
{
    public class AnnoucementController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AnnoucementController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Annoucement> objAnnoucementList = _db.annoucements;
            return View(objAnnoucementList);
        }
        public IActionResult Index2()
        {
            IEnumerable<Annoucement> objAnnoucementList = _db.annoucements;
            return View(objAnnoucementList);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Annoucement obj)
        {
            
            if (ModelState.IsValid)
            {
                obj.date = DateTime.Now;
                _db.annoucements.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Annoucement created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    }
}
