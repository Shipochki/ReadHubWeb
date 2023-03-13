namespace ReadHub.Web.Controllers
{
	using ReadHubWeb.Infranstructure;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using ReadHub.Core.Services.Book;
	using ReadHub.Core.Services.Review;
	using ReadHub.Core.Services.Review.Models;

	[Authorize]
	public class ReviewController : Controller
	{
		private readonly IBookService books;
		private readonly IReviewService review;

		public ReviewController(
			IBookService _books,
			IReviewService _review)
		{
			this.books = _books;
			this.review = _review;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> AddReview(int id)
		{
			var review = new ReviewFormCreateModel();
			review.Books = await this.books.GetAllBooksById(id);
			return View(review);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> AddReview(ReviewFormCreateModel model)
		{
			var bookId = await this.review.CreateReview(model, this.User.Id());

			return RedirectToAction("Details", "Book", new { bookId });
		}
	}
}
