using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Controllers
{
	public class MachinesController : Controller
	{
		private readonly FactoryContext _db;
		public MachinesController(FactoryContext db)
		{
			_db = db;
		}
		
		public ActionResult Index()
		{
			List<Machine> machineList = _db.Machines.ToList();
			return View(machineList);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Machine machine)
		{
			_db.Machines.Add(machine);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Read(int id)
		{
			Machine thisMachine = _db.Machines
			.Include(machine => machine.Engineers)
			.ThenInclude(join => join.Engineer)
			.FirstOrDefault(machine => machine.MachineId == id);
			return View(thisMachine);
		}

		public ActionResult Edit(int id)
		{
			Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
			return View(thisMachine);
		}

		public ActionResult Edit(Machine machine)
		{
			_db.Entry(machine).State = EntityState.Modified;
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Delete(int id)
		{
			Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
			return View(thisMachine);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult Delete2(int id)
		{
			Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
			_db.Machines.Remove(thisMachine);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult AddEngineer(int id)
		{
			Machine thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
			ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
			return View(thisMachine);
		}

		[HttpPost]
		public ActionResult AddEngineer(Machine machine, int EngineerId)
		{
			if(EngineerId != 0)
			{
				_db.EngineerMachine.Add(new EngineerMachine() {EngineerId = EngineerId, MachineId = machine.MachineId });
			}
			_db.SaveChanges();
			return RedirectToAction("Read", new { id = machine.MachineId});
		}

		[HttpPost]
		public ActionResult DeleteEngineer(int joinId)
		{
			EngineerMachine joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
			_db.EngineerMachine.Remove(joinEntry);
			_db.SaveChanges();
			return RedirectToAction("Read", new { id = joinEntry.MachineId });
		}
	}
}
