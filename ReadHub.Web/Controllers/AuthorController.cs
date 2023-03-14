namespace ReadHub.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using ReadHub.Core.Services.Author;

	public class AuthorController : Controller
	{
		private readonly IAuthorService author;

		public AuthorController(IAuthorService _author)
		{
			this.author = _author;
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var author = await this.author.GetAuthorById(id);

			return View(author);
		}
	}
}
