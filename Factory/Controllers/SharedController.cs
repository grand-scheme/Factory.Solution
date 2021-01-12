using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;

namespace Factory.Controllers
{
	public class SharedController : Controller
	{
    private readonly FactoryContext _db;
		public SharedController(FactoryContext db)
		{
			_db = db;
		}

		[HttpGet("/")]
		public ActionResult Index()
		{
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "Name");
			return View();
		}
	}
}
