using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Factory.Models;
using System.Linq;

// namespace Factory.Controllers
// {
// 	public class HomeController : Controller
// 	{

// 		[HttpGet("/")]
// 		public ActionResult Index()
// 		{
// 			return View();
// 		}

// 	}
// }


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
      // ViewBag.Machines = new SelectList(_db.Machines, "MachineId", "Name");
			return View();
		}
	}
}
