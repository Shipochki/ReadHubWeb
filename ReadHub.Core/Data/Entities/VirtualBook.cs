using System.ComponentModel.DataAnnotations;

namespace ReadHub.Core.Data.Entities
{
	public class VirtualBook
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; } = null!;

		[Required]
		public string ImageUrlLink { get; set; } = null!;

		[Required]
		public string ReaderUrlLInk { get; set; } = null!;

		[Required]
		public int BookId { get; set; }

		public Book Book { get; set; } = null!;

		public decimal Price { get; set; }
	}
}
