using ReadHub.Core.Services.Book.Models;

namespace ReadHub.Core.Services.Order.Models
{
	public class OrderServiceModel
	{
		public string UserId { get; set; } = null!;

		public ICollection<BookServiceModel> OrderedBooks { get; set; } = new List<BookServiceModel>();
	}
}
