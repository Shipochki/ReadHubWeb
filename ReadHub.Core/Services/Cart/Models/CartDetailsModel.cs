namespace ReadHub.Core.Services.Cart.Models
{
	using ReadHub.Core.Services.VirtualBook.Models;

	public class CartDetailsModel
	{
		public int Id { get; set; }

		public decimal TotalPrice { get; set; }

		public ICollection<VirtualBookDetailsModel> BooksInCart { get; set; } = new List<VirtualBookDetailsModel>();
	}
}
