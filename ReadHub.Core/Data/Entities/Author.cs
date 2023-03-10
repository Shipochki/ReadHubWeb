namespace ReadHub.Core.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;
	using static ReadHub.Core.DataConstants.Author;

	public class Author
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(FirstNameMaxLength)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MaxLength(LastNameMaxLength)]
		public string LastName { get; set; } = null!;

		[MaxLength(PhoneNumberMaxLength)]
		public string? PhoneNumber { get; set; }

		[ForeignKey(nameof(User))]
		public string? UserId { get; set; }
		public User? User { get; set; }

		public ICollection<Book> PublishedBooks { get; set; } = new List<Book>();

	}
}
