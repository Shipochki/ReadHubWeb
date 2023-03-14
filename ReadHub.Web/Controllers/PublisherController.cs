namespace ReadHub.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using ReadHub.Core.Services.Publisher;

	public class PublisherController : Controller
	{
		private readonly IPublisherService publisher;

		public PublisherController(IPublisherService publisher)
		{
			this.publisher = publisher;
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var publisher = await this.publisher.GetPublisherById(id);
			
			return View(publisher);
		}
	}
}
