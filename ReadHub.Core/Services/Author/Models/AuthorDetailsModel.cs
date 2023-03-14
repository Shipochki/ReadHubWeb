namespace ReadHub.Core.Services.Author.Models
{
	using ReadHub.Core.Services.Book.Models;

	public class AuthorDetailsModel
	{
		public string FirstName { get; set; } = null!;

		public string LastName { get; set; } = null!;

		public IEnumerable<BookDetailPublisherModel> Books { get; set; } = new List<BookDetailPublisherModel>();
	}
}
