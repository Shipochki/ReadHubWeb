namespace ReadHub.Core.Services.Cart
{
	using ReadHub.Core.Services.Cart.Models;

	public interface ICartService
	{
		Task<CartServiceModel> GetCartByUserId(string userId);

		Task AddToCart(int bookId, string userId);

		Task RemoveVirtualBookFromCart(int bookId, string userId);

		Task RemoveAll(CartServiceModel cart, string userId);

		Task<CartServiceModel> GetCartById(int id);
	}
}
