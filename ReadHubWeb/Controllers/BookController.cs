using Microsoft.AspNetCore.Mvc;
using ReadHub.Core.Services.Book;
using System.Diagnostics;
using ReadHub.Core.Services.Book.Models;
using ReadHub.Core.Services.Author;
using ReadHub.Core.Services.Publisher;
using ReadHub.Core.Services.Order;
using ReadHub.Core;
using HouseRentingSystem.Infranstructure;
using Microsoft.AspNetCore.Authorization;
using ReadHub.Core.Services.Review.Models;
using ReadHub.Core.Services.Review;

namespace ReadHub.Web.Controllers
{
	public class BookController : Controller
	{
		private readonly IBookService books;
		private readonly IAuthorService author;
		private readonly IPublisherService publisher;
		private readonly IOrderService order;
		private readonly IReviewService review;

		public BookController(IBookService _bookService, 
			IAuthorService _author, 
			IPublisherService _publisher,
			IOrderService _order,
			IReviewService _review)
		{
			this.books = _bookService;
			this.author = _author;
			this.publisher = _publisher;
			this.order = _order;
			this.review = _review;
		}

		[HttpGet]
		public async Task<IActionResult> All()
		{
			var books = await this.books.All();
			var result = new BookQueryServiceModel
			{
				Books = books
			};

			return View("All", result);		
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
		[Authorize]
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
		[Authorize]
		public async Task<IActionResult> Edit(int id, BookCreateServiceModel model)
		{
			await this.books.Edit(id, model);

			return RedirectToAction(nameof(All));
		}

		[HttpGet]
		[Authorize]
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
		[Authorize]
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
		[Authorize]
		public async Task<IActionResult> AddCart(int id)
		{
			var book = await this.books.DetailsById(id);

			if(book == null)
			{
				return BadRequest();
			}

			var result = await order.AddToCart(book, this.User.Id());

			return RedirectToAction(nameof(Details), new { id });
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> MyCart(string id)
		{
			var model = await order.GetOrderByUserId(id);

			if(this.User.Id() != id)
			{
				return Unauthorized();
			}

			return View("MyCart", model);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Add()
		{
			return View(new BookCreateServiceModel()
			{
				Authors = await this.author.GetAllAuthors(),
				Publishers = await this.publisher.GetAllPublishers(),
			});
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Add(BookCreateServiceModel model)
		{
			var bookId = await this.books.Create(model);

			return RedirectToAction(nameof(Details), new { bookId });
		}


		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Remove(int id)
		{
			await this.books.DeleteOrderById(id);

			return RedirectToAction(nameof(Details), new { id });
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> AddReview(int id)
		{
			var review = new ReviewFormCreateModel();
			review.Books = await this.books.All();
			return View(review);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> AddReview(ReviewFormCreateModel model)
		{

			var bookId = await this.review.CreateReview(model, this.User.Id());

			return RedirectToAction(nameof(Details), new { bookId });
		}
	}
}
