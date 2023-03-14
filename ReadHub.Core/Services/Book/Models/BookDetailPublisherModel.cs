namespace ReadHub.Core.Services.Book.Models
{
	using ReadHub.Core.Data.Enum;

	public class BookDetailPublisherModel
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string Description { get; set; } = null!;

		public int AuthorId { get; set; }

		public string AuthorName { get; set; } = null!;

		public string PublisherName { get; set; } = null!;

		public int PublisherId { get; set; }

		public string ImageUrlLink { get; set; } = null!;

		public string ReaderUrlLink { get; set; } = null!;

		public Genre Genre { get; set; }

		public DateTime Year { get; set; }

		public string Language { get; set; } = null!;

		public string Nationality { get; set; } = null!;

		public TypeBook TypeBook { get; set; }

		public decimal Price { get; set; }

	}
}
