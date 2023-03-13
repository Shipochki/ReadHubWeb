namespace ReadHub.Core.Services.Order
{
	using ReadHub.Core.Services.Cart.Models;
	using ReadHub.Core.Services.Order.Models;

	public interface IOrderService
	{
		Task<OrdersServiceModel> GetOrdersByUserId(string id);

		Task<int> GetOrderId(string userId);

		Task AddOrder(CartServiceModel orders, string userId);
	}
}
