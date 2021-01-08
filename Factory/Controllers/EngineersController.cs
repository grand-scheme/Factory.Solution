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

		public ActionResult Create(Engineer engineer)
		{
			_db.Engineers.Add(engineer);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Read(int id)
		{
			Engineer thisEngineer = _db.Engineers
			.Include(engineer => engineer.Machines)
			.ThenInclude(join => join.Machine)
			.FirstOrDefault(engineer => engineer.EngineerId ==id);
			return View(thisEngineer);
		}

		public ActionResult Edit(int id)
		{
			Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
			return View(thisEngineer);
		}

		public ActionResult Edit(Engineer engineer)
		{
			_db.Entry(engineer).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
			_db.Engineers.Remove(thisEngineer);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
	}
}
