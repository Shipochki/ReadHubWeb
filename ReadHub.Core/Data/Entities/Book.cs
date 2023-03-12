namespace ReadHub.Core.Data.Entities
{
	using ReadHub.Core.Data.Enum;
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using static ReadHub.Core.DataConstants.Book;
	public class Book
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(TitleMaxLength)]
		public string Title { get; set; } = null!;

		[Required]
		[MaxLength(DescriptionMaxLength)]
		public string Description { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Publisher))]
		public int PublisherId { get; set; }
		public Publisher Publisher { get; set; } = null!;

		[Required]
		public string ImageUrlLink { get; set; } = null!;

		[Required]
		public string ReaderUrlLink { get; set; } = null!;

		[Required]
		[ForeignKey(nameof(Author))]
		public int AuthorId { get; set; }
		public Author Author { get; set; } = null!;

		[Required]
		public Genre Genre { get; set; }

		[Required]
		public DateTime Year { get; set; }

		[Required]
		[MaxLength(LanguageMaxLength)]
		public string Language { get; set; } = null!;

		[Required]
		[MaxLength(NationalityMaxLength)]
		public string Nationality { get; set; } = null!;

		[Required]
		public TypeBook TypeBook { get; set; }

		[Required]
		public decimal Price { get; set; }

		public bool isActive { get; set; } = true;

		public ICollection<Review> Reviews { get; set; } = new List<Review>();
	}
}
