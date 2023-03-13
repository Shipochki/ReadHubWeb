namespace ReadHub.Core.Services.Review
{
    using ReadHub.Core.Services.Review.Models;
    public interface IReviewService
    {
        public Task<IEnumerable<ReviewDetailsServiceModel>> AllWithIdBook(int bookId);

        public Task<int> CreateReview(ReviewFormCreateModel model, string userId);

	}
}
