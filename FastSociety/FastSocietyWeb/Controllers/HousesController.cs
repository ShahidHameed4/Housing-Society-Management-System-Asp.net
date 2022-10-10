using FastSocietyWeb.Data;
using Microsoft.AspNetCore.Mvc;

using FastSocietyWeb.Models;

namespace FastSocietyWeb.Controllers
{
    public class HousesController : Controller
    {
        


		private readonly ApplicationDbContext _db;
		public HousesController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<House> objCustomerList = _db.houses;
			return View(objCustomerList);
		}

		//GET
		public IActionResult Create()
		{

			return View();
		}
		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(House obj)
		{
			if (obj.houseNo == obj.Description)
			{
				ModelState.AddModelError("House_Number", "Both fields are same");
			}
			if (ModelState.IsValid)
			{
				_db.houses.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "House added successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		//GET
		public IActionResult Edit(int? House_Number)
		{
			if (House_Number == null || House_Number == 0)
			{
				return NotFound();
			}
			var AllocateHouseFromDb = _db.allocateHouses.Find(House_Number);

			if (AllocateHouseFromDb == null)
			{
				return NotFound();
			}

			return View(AllocateHouseFromDb);

		}
		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(House obj)
		{
			if (obj.houseNo == obj.Description)
			{
				ModelState.AddModelError("House_Number", "Both fields are same");
			}
			if (ModelState.IsValid)
			{
				_db.houses.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Record edited successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}


		//GET
		public IActionResult Delete(String? houseNo)
		{
			if (houseNo == null || houseNo.Equals( 0))
			{
				return NotFound();
			}
			var AllocateHouseFromDb = _db.houses.Find(houseNo);

			if (AllocateHouseFromDb == null)
			{
				return NotFound();
			}

			return View(AllocateHouseFromDb);

		}
		//POST
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(String? House_Number)
		{

			var obj = _db.houses.Find(House_Number);

			if (obj == null)
			{
				return NotFound();
			}
			_db.houses.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Record deleted successfully";
			return RedirectToAction("Index");


		}
	}
}
