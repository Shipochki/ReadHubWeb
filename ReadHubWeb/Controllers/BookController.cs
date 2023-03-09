using Microsoft.AspNetCore.Mvc;
using ReadHub.Core.Services.Book;
using System.Diagnostics;
using ReadHub.Core.Services.Book.Models;

namespace ReadHub.Web.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookService books;

		public BookController(IBookService _bookService)
		{
			this.books = _bookService;
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

		public IActionResult Add()
		{
			return View(new BookCreateServiceModel());
		}

		[HttpPost]
		public async Task<IActionResult> Add(BookCreateServiceModel model)
		{
			var bookId = await this.books.Create(model);

			return RedirectToAction(nameof(Details), new { bookId });
		}
	}
}
