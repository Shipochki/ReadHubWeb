namespace ReadHub.Core.Services.Cart
{
	using ReadHub.Core.Services.Cart.Models;

	public interface ICartService
	{
		Task<CartServiceModel> GetCartByUserId(string userId);
	}
}
