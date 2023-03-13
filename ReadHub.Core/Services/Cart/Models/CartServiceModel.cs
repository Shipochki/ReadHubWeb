namespace ReadHub.Core.Services.Cart.Models
{
	using ReadHub.Core.Services.VirtualBook.Models;

	public class CartServiceModel
	{
		public int Id { get; set; }

		public decimal TotalPrice { get; set; }

		public ICollection<VirtualBookServiceModel> BooksInCart { get; set; } = new List<VirtualBookServiceModel>();
	}
}
