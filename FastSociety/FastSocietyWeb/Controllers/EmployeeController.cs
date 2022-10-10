using FastSocietyWeb.Data;
using FastSocietyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastSocietyWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Employee> objEmployeeList =_db.employees;    
            return View(objEmployeeList);
        }
        //GET
        public IActionResult Create()
        {
         
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]  
        public IActionResult Create(Employee obj)
        {
            if (obj.Emp_Name == obj.Emp_Salary)
            {
                ModelState.AddModelError("Emp_Name", "Both fields are same");
            }
            if (ModelState.IsValid)
            {
                _db.employees.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? Emp_ID)
        {
            if (Emp_ID == null || Emp_ID == 0)
            {
               return NotFound();
           }
            var EmployeeFromDb = _db.employees.Find(Emp_ID);

            if (EmployeeFromDb == null)
           {
                return NotFound();
            }

            return View(EmployeeFromDb);
          
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee obj)
        {
            if(obj.Emp_Name == obj.Emp_Salary)
            {
             ModelState.AddModelError("Emp_Name", "Both fields are same");
            }
            if (ModelState.IsValid)
            {
                _db.employees.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee edited successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Delete(int? Emp_ID)
        {
            if (Emp_ID == null || Emp_ID == 0)
            {
                return NotFound();
            }
            var EmployeeFromDb = _db.employees.Find(Emp_ID);

            if (EmployeeFromDb == null)
            {
                return NotFound();
            }

            return View(EmployeeFromDb);

        }
        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? Emp_ID)
        {

            var obj = _db.employees.Find(Emp_ID);

            if (obj == null)
            {
                return NotFound();
            }
            _db.employees.Remove(obj);
                _db.SaveChanges();
            TempData["success"] = "Employee deleted successfully";
            return RedirectToAction("Index");
            
            
        }
    }
}
