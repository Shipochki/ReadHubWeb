namespace ReadHub.Core.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Cart
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey(nameof(User))]
		public string UserId { get; set; } = null!;
		public User User { get; set; } = null!;

		[Required]
		public decimal TotalPrice { get; set; }

		public ICollection<VirtualBook> BooksInCart { get; set; } = new List<VirtualBook>();
	}
}
