namespace ReadHub.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using ReadHub.Core.Services.Admin;
    using ReadHub.Core.Services.Author.Models;
    using ReadHub.Core.Services.Publisher.Models;
    using ReadHubWeb.Infranstructure;
    using static ReadHub.Web.Areas.Admin.AdminConstants;

    [Area(AreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class AdminController : Controller
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService _adminService)
        {
            adminService = _adminService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddAuthor()
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            return View(new AuthorCreateServiceModel());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorCreateServiceModel model)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var authorId = await adminService.CreateAuthor(model);

            if (authorId == -1)
            {
                return BadRequest();
            }

            TempData["message"] = "You have sucssessfuly added a Author!";

            return RedirectToAction("Details", "Author", new { authorId });
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddPublisher()
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            return View(new PublisherCreateServiceModel());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPublisher(PublisherCreateServiceModel model)
        {
            if (!User.IsAdmin())
            {
                return Unauthorized();
            }

            var publisherId = await adminService.CreatePublisher(model);

            if(publisherId == -1)
            {
                return BadRequest();
            }

            TempData["message"] = "You have sucssessfuly added a house!";

            return RedirectToAction("Details", "Publisher", new { publisherId });
        }

    }
}
