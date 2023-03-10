using Microsoft.AspNetCore.Mvc;
using ReadHub.Core.Services.Book;
using System.Diagnostics;
using ReadHub.Core.Services.Book.Models;
using ReadHub.Core.Services.Author;
using ReadHub.Core.Services.Publisher;

namespace ReadHub.Web.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookService books;
		private readonly IAuthorService author;
		private readonly IPublisherService publisher;
		public BookController(IBookService _bookService, IAuthorService _author, IPublisherService _publisher)
		{
			this.books = _bookService;
			this.author = _author;
			this.publisher = _publisher;
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

			if(detail == null)
			{
				return BadRequest();
			}

			return View(detail);
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var book = await books.FindBookById(id);
			book.Authors = await this.author.GetAllAuthors();
			book.Publishers = await this.publisher.GetAllPublishers();
			return View(new BookCreateServiceModel()
			{
				Title = book.Title,
				Description = book.Description,
				PublisherId = book.PublisherId,
				ImageUrlLink = book.ImageUrlLink,
				ReaderUrlLink = book.ReaderUrlLink,
				AuthorId = book.AuthorId,
				Language = book.Language,
				Nationality = book.Nationality,
				Price = book.Price,
				Genre = book.Genre,
				TypeBook = book.TypeBook,
				Year = book.Year,
				Authors = book.Authors,
				Publishers = book.Publishers,
			});
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, BookCreateServiceModel model)
		{
			await this.books.Edit(id, model);

			return RedirectToAction(nameof(All));
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var book = await this.books.FindBookById(id);
			
			return View(new BookDeleteView()
			{
				Id = id,
				Title = book.Title,
				ImageUrlLink = book.ImageUrlLink,
			});
		}

		[HttpPost]
		public async Task<IActionResult> Delete(BookDeleteView model)
		{
			var book = await this.books.Delete(model.Id);

			return RedirectToAction(nameof(All));
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
				Publishers = await this.publisher.GetAllPublishers(),
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
