namespace ReadHubWeb.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using ReadHub.Core.Services.Book;
	using ReadHubWeb.Models;
	using System.Diagnostics;

	public class HomeController : Controller
	{
		private readonly IBookService books;

		public HomeController(IBookService _books)
		{
			this.books = _books;
		}

		public async Task<IActionResult> Index()
		{
			var result = await this.books.GetBestTen();

			return View(result);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}