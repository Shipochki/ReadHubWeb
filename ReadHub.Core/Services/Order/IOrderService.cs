using ReadHub.Core.Services.Book.Models;
using ReadHub.Core.Services.Order.Models;

namespace ReadHub.Core.Services.Order
{
	public interface IOrderService
	{
		Task<int> AddOrder(OrderServiceModel model);

		Task<OrderServiceModel> GetOrderByUserId(string id);

		Task<int> AddToCart(BookServiceModel book, string userId);

		Task DeleteBookFromOrder(int order, int bookId);

		int GetOrderId(string userId);
	}
}
