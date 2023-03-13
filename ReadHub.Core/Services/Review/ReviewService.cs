namespace ReadHub.Core
{
	using Microsoft.EntityFrameworkCore;
	using ReadHub.Core.Services.Review.Models;
	using ReadHub.Core.Data.Entities;
	using ReadHub.Core.Services.Review;

	public class ReviewService : IReviewService
	{
		private readonly ReadHubDbContext context;

		public ReviewService(ReadHubDbContext _context)
		{
			this.context = _context;
		}

		public async Task<IEnumerable<ReviewDetailsServiceModel>> AllWithIdBook(int bookId)
		{
			return await this.context
				.Reviews
				.Where(r => r.BookId == bookId)
				.Select(r => new ReviewDetailsServiceModel
				{
					RatingNums = r.Raiting,
					Comment = r.Comment,
					BookId = bookId,
					UserName = r.User.UserName,
				})
				.ToListAsync();
		}

		public async Task<int> CreateReview(ReviewFormCreateModel model, string userId)
		{
			var review = new Review()
			{
				Raiting = model.Review.Raiting,
				Comment = model.Review.Comment,
				BookId = model.Review.BookId,
				UserId = userId
			};

			await this.context.Reviews.AddAsync(review);
			await this.context.SaveChangesAsync();

			return review.BookId;
		}
	}
}
