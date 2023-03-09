using Microsoft.AspNetCore.Mvc;

namespace ReadHub.Web.Controllers
{
	public class AdminController : Controller
	{
		[HttpPost]
		public IActionResult AddAuthor()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddPublisher()
		{
			return View();
		}
	}
}
