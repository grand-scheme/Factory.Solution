using Microsoft.AspNetCore.Mvc;using Factory.Models;using System.Collections.Generic;namespace Factory.Controllers{	public class MachinesController : Controller	{		[HttpGet("/Machines")]		public ActionResult Index()		{			return View();		}	}}
