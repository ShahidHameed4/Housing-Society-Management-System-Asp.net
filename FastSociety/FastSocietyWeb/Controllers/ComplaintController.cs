using FastSocietyWeb.Data;
using FastSocietyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FastSocietyWeb.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ComplaintController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<Complaint> objComplaintList= _db.complaints.FromSqlRaw("Select * from complaints where User_ID = @id ", new SqlParameter("@id", "1"));
               

          //  IEnumerable <Complaint> objComplaintList = _db.complaints;
            return View(objComplaintList);
        }
        public IActionResult Index2()
        {
            IEnumerable<Complaint> objComplaintList = _db.complaints;
            return View(objComplaintList);
        }
        //GET
        public IActionResult Create()
        {


            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Complaint obj)
        {

            if (ModelState.IsValid)
            {
                obj.Status = "Pending";
                _db.complaints.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Annoucement created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
