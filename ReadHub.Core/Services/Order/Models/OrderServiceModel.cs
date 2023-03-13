using ReadHub.Core.Services.Book.Models;
using ReadHub.Core.Services.VirtualBook.Models;

namespace ReadHub.Core.Services.Order.Models
{
	public class OrderServiceModel
	{
		public int Id { get; set; }

		public decimal TotalPrice { get; set; }

		public IEnumerable<VirtualBookServiceModel> OrderedBooks { get; set; } = new List<VirtualBookServiceModel>();
	}
}
