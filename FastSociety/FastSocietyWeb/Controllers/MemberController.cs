using FastSocietyWeb.Data;
using FastSocietyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;



namespace FastSocietyWeb.Controllers
{
	public class MemberController : Controller
	{

		private readonly ApplicationDbContext _db;

		public MemberController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			IEnumerable<Member> objCustomerList = _db.customers;
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
		public IActionResult Create(Member obj)
		{
			if (obj.Member_Name == obj.Member_Address)
			{
				ModelState.AddModelError("Member_Name", "Both fields are same");
			}
			if (ModelState.IsValid)
			{
				_db.Database.ExecuteSqlRaw("insert into customers( Member_Name, Member_Address, CreatedDateTime) Values(@Member_Name, @Member_Address,@CreatedDateTime)"
					, new SqlParameter("@Member_Name", obj.Member_Name),new SqlParameter("@Member_Address", obj.Member_Address), new SqlParameter("@CreatedDateTime", obj.CreatedDateTime));


				//_db.customers.Add(obj);
				//_db.SaveChanges();
				TempData["success"] = "Member created successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}

		//GET
		public IActionResult Edit(int? Member_ID)
		{
			if (Member_ID == null || Member_ID == 0)
			{
				return NotFound();
			}
			var CustomerFromDb = _db.customers.Find(Member_ID);

			if (CustomerFromDb == null)
			{
				return NotFound();
			}

			return View(CustomerFromDb);

		}
		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Member obj)
		{
			if (obj.Member_Name == obj.Member_Address)
			{
				ModelState.AddModelError("Member_Name", "Both fields are same");
			}
			if (ModelState.IsValid)
			{
				_db.customers.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Member edited successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}


		//GET
		public IActionResult Delete(int? Member_ID)
		{
			if (Member_ID == null || Member_ID == 0)
			{
				return NotFound();
			}
			var CustomerFromDb = _db.customers.Find(Member_ID);

			if (CustomerFromDb == null)
			{
				return NotFound();
			}

			return View(CustomerFromDb);

		}
		//POST
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeletePOST(int? Member_ID)
		{

			var obj = _db.customers.Find(Member_ID);

			if (obj == null)
			{
				return NotFound();
			}
			_db.customers.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Member deleted successfully";
			return RedirectToAction("Index");


		}
	}
}
