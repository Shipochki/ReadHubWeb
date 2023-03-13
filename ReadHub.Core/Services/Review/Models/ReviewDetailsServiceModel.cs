namespace ReadHub.Core.Services.Review.Models
{
	public class ReviewDetailsServiceModel
	{
		public int Id { get; set; }

		public int RatingNums { get; set; }

		public string Rating { get; set; } = null!;

		public string? Comment { get; set; }

		public string UserName { get; set; } = null!;

		public int BookId { get; set; }
	}
}
