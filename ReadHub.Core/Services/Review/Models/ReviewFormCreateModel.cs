namespace ReadHub.Core.Services.Review.Models
{
	using ReadHub.Core.Services.Book.Models;

	public class ReviewFormCreateModel
	{
		public IEnumerable<BookServiceModel> Books { get; set; } = new List<BookServiceModel>();
		public ReviewCreateServiceModel Review { get; set; } = new ReviewCreateServiceModel(); 
	}
}
