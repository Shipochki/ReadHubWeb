namespace ReadHub.Core.Services.Book.Models
{
	public class BookQueryServiceModel
	{
		public IEnumerable<BookServiceModel> Books { get; set; } = new List<BookServiceModel>();
	}
}
