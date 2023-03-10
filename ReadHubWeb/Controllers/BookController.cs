using Microsoft.AspNetCore.Mvc;
using ReadHub.Core.Services.Book;
using System.Diagnostics;
using ReadHub.Core.Services.Book.Models;
using ReadHub.Core.Services.Author;

namespace ReadHub.Web.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookService books;
		private readonly IAuthorService author;
		public BookController(IBookService _bookService, IAuthorService _author)
		{
			this.books = _bookService;
			this.author = _author;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var books = await this.books.All();
			var result = new BookQueryServiceModel
			{
				Books = books
			};

			return View(result);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var detail = await this.books.DetailsById(id);

			return View(detail);
		}

		[HttpPost]
		public IActionResult Edit(int id)
		{
			return View();
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddFavorite(int id)
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddCart(int id)
		{
			return View();
		}

		[HttpGet]
		public IActionResult MyCart(int id)
		{
			return View();
		}

		public async Task<IActionResult> Add()
		{
			return View(new BookCreateServiceModel()
			{
				Authors = await this.author.GetAllAuthors(),
			});
		}

		[HttpPost]
		public async Task<IActionResult> Add(BookCreateServiceModel model)
		{
			var bookId = await this.books.Create(model);

			return RedirectToAction(nameof(Details), new { bookId });
		}
	}
}
