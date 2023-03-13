namespace ReadHub.Core.Services.Publisher.Models
{
	using ReadHub.Core.Data.Entities;
	using ReadHub.Core.Services.Book.Models;

	public class PublisherDetailsModel
	{
		public string Name { get; set; } = null!;

		public DateTime Year { get; set; }

		public string Description { get; set; } = null!;

		public IEnumerable<BookDetailPublisherModel> Books { get; set; } = new List<BookDetailPublisherModel>();
	}
}
