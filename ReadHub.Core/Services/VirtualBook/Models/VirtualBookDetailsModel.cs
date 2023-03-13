namespace ReadHub.Core.Services.VirtualBook.Models
{
	public class VirtualBookDetailsModel
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;

		public string ImageUrlLink { get; set; } = null!;

		public string ReaderUrlLInk { get; set; } = null!;

		public int BookId { get; set; }

		public decimal Price { get; set; }
	}
}
