using FastSocietyWeb.Data;
using FastSocietyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastSocietyWeb.Controllers
{
	public class AllocateHouseController : Controller
	{

		private readonly ApplicationDbContext _db;
		public AllocateHouseController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<AllocateHouse> objCustomerList = _db.allocateHouses;
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
		public IActionResult Create(AllocateHouse obj)
		{
			if (obj.House_Number == obj.Name)
			{
				ModelState.AddModelError("House_Number", "Both fields are same");
			}
			if (ModelState.IsValid)
			{
				_db.allocateHouses.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "House allocated successfully";
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
		public IActionResult Edit(AllocateHouse obj)
		{
			if (obj.House_Number == obj.Name)
			{
				ModelState.AddModelError("House_Number", "Both fields are same");
			}
			if (ModelState.IsValid)
			{
				_db.allocateHouses.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Record edited successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}


		//GET
		public IActionResult Delete(String? House_ID)
		{
			if (House_ID == null || House_ID.Equals( 0))
			{
				return NotFound();
			}
			var AllocateHouseFromDb = _db.allocateHouses.Find(House_ID);

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

			var obj = _db.allocateHouses.Find(House_Number);

			if (obj == null)
			{
				return NotFound();
			}
			_db.allocateHouses.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Record deleted successfully";
			return RedirectToAction("Index");


		}
	}
}
