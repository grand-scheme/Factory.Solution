using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Linq;

namespace Factory.Controllers
{
	public class HomeController : Controller
	{
    private readonly FactoryContext _db;
		public HomeController(FactoryContext db)
		{
			_db = db;
		}

		[HttpGet("/")]
		public ActionResult Index()
		{
      List<Machine> machineList = _db.Machines.ToList();
      ViewBag.Machines = machineList;
      List<Engineer> engineerList = _db.Engineers.ToList();
      ViewBag.Engineers = engineerList;
			return View();
		}
	}
}
