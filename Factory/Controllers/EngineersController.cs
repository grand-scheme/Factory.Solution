using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
	public class EngineersController : Controller
	{
		private readonly FactoryContext _db;
		public EngineersController(FactoryContext db)
		{
			_db = db;
		}
		public ActionResult Index()
		{
			List<Engineer> engineerList = _db.Engineers.ToList();
			return View(engineerList);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Engineer engineer)
		{
			return RedirectToAction("Index");
		}

		public ActionResult Read(int id)
		{
			return View();
		}

		public ActionResult Edit(int id)
		{
			return View();
		}

		public ActionResult Delete(int id)
		{
			return View();
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		[HttpGet("/Engineers")]
		public ActionResult Index()
		{
			return View();
		}
	}
}
