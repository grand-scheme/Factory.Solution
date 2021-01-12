using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Factory.Models;

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

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
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
			.FirstOrDefault(engineer => engineer.EngineerId == id);
			return View(thisEngineer);
		}

		public ActionResult Edit(int id)
		{
			Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
			return View(thisEngineer);
		}

		[HttpPost]
		public ActionResult Edit(Engineer engineer)
		{
			_db.Entry(engineer).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult Delete(int id)
		{
			Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
			return View(thisEngineer);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult Delete2(int id)
		{
			Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
			_db.Engineers.Remove(thisEngineer);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}
		
		public ActionResult AddMachine(int id)
		{
			Engineer thisEngineer = _db.Engineers.FirstOrDefault(engineer => engineer.EngineerId == id);
			ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
			return View(thisEngineer);
		}

		[HttpPost]
		public ActionResult AddMachine(Engineer engineer, int MachineId)
		{
			if(MachineId != 0)
			{
				_db.EngineerMachine.Add(new EngineerMachine() {MachineId = MachineId, EngineerId = engineer.EngineerId });
			}
			_db.SaveChanges();
			return RedirectToAction("Read", new { id = engineer.EngineerId});
		}

		[HttpPost]
		public ActionResult DeleteMachine(int joinId)
		{
			EngineerMachine joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
			_db.EngineerMachine.Remove(joinEntry);
			_db.SaveChanges();
			return RedirectToAction("Read", new { id = joinEntry.EngineerId });
		}
	}
}
