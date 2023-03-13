namespace ReadHub.Core.Services.Book.Models
{
	using ReadHub.Core.Data.Enum;
	using ReadHub.Core.Services.Author.Models;
	using ReadHub.Core.Services.Publisher.Models;
	using System.ComponentModel.DataAnnotations;
	using static ReadHub.Core.DataConstants.Book;

	public class BookCreateServiceModel
	{
		[Required]
		[MaxLength(TitleMaxLength)]
		[MinLength(TitleMinLength)]
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(DescriptionMaxLength)]
		[MinLength(DescriptionMinLength)]
		public string Description { get; set; } = null!;

		[Required]
		public int PublisherId { get; set; }

		[Required]
		public string ImageUrlLink { get; set; } = null!;

		[Required]
		public string ReaderUrlLink { get; set; } = null!;

		[Required]
		public int AuthorId { get; set; }

		[Required]
		[Range(0, 5)]
		public Genre Genre { get; set; }

		[Required]
		public DateTime Year { get; set; }

		[Required]
		[MaxLength(LanguageMaxLength)]
		[MinLength(LanguageMinLength)]
		public string Language { get; set; } = null!;

		[Required]
		[MaxLength(NationalityMaxLength)]
		[MinLength(NationalityMinLength)]
		public string Nationality { get; set; } = null!;

		[Required]
		[Range(0, 1)]
		public TypeBook TypeBook { get; set; }

		[Required]
		[Range(typeof(decimal), PriceRangeMin, PriceRangeMax)]
		public decimal Price { get; set; }

		public IEnumerable<AuthorServiceModel> Authors { get; set; } = new List<AuthorServiceModel>();

		public IEnumerable<PublisherServiceModel> Publishers { get; set; } = new List<PublisherServiceModel>();
	}
}
