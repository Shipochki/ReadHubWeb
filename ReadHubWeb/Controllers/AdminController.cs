namespace ReadHub.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using ReadHub.Core.Services.Admin;
	using ReadHub.Core.Services.Author.Models;
	using ReadHub.Core.Services.Publisher.Models;
	using ReadHubWeb.Infranstructure;

	public class AdminController : Controller
	{
		private readonly IAdminService adminService;

		public AdminController(IAdminService _adminService)
		{
			this.adminService = _adminService;
		}

		[Authorize]
		[HttpGet]
		public IActionResult AddAuthor()
		{
			if (!this.User.IsAdmin())
			{
				return Unauthorized();
			}

			return View(new AuthorCreateServiceModel());
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> AddAuthor(AuthorCreateServiceModel model)
		{
			if (!this.User.IsAdmin())
			{
				return Unauthorized();
			}

			var authorId = await this.adminService.CreateAuthor(model);

			return RedirectToAction("AuthorDetails", "Author", new { authorId });
		}

		[Authorize]
		[HttpGet]
		public IActionResult AddPublisher()
		{
			if (!this.User.IsAdmin())
			{
				return Unauthorized();
			}

			return View(new PublisherCreateServiceModel());
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> AddPublisher(PublisherCreateServiceModel model)
		{
			if (!this.User.IsAdmin())
			{
				return Unauthorized();
			}

			var publisherId = await this.adminService.CreatePublisher(model);

			return RedirectToAction("PublisherDetails", "Publisher", new { publisherId });
		}

	}
}
