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
			_db.Machines.Remove(thisMachine);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}


	}
}
