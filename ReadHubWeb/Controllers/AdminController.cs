using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadHub.Core.Services.Admin;
using ReadHub.Core.Services.Author;
using ReadHub.Core.Services.Author.Models;
using ReadHub.Core.Services.Publisher;
using ReadHub.Core.Services.Publisher.Models;

namespace ReadHub.Web.Controllers
{
	public class AdminController : Controller
	{
		private readonly IAdminService adminService;
		private readonly IAuthorService authorService;

		public AdminController(IAdminService _adminService, IAuthorService _authorService)
		{
			this.adminService = _adminService;
			this.authorService = _authorService;
		}

		[Authorize]
		[HttpGet]
		public IActionResult AddAuthor()
		{
			return View(new AuthorCreateServiceModel());
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> AddAuthor(AuthorCreateServiceModel model)
		{
			var authorId = await this.adminService.CreateAuthor(model);

			return RedirectToAction("AuthorDetails", "Author", new { authorId });
		}

		[Authorize]
		[HttpGet]
		public IActionResult AddPublisher()
		{
			return View(new PublisherCreateServiceModel());
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> AddPublisher(PublisherCreateServiceModel model)
		{
			var publisherId = await this.adminService.CreatePublisher(model);

			return RedirectToAction("PublisherDetails", "Publisher" ,new { publisherId });
		}

	}
}
