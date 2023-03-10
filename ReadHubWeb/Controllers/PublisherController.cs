using Microsoft.AspNetCore.Mvc;

namespace ReadHub.Web.Controllers
{
	public class PublisherController : Controller
	{
		public IActionResult PublisherDetails()
		{
			return View();
		}
	}
}
