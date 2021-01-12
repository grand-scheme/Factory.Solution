using Microsoft.AspNetCore.Mvc;

namespace Factory.Controllers
{
	public class SharedController : Controller
	{

		[HttpGet("/")]
		public ActionResult Index()
		{
			return View();
		}

	}
}
