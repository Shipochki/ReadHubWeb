using ReadHub.Core.Data.Entities;
using ReadHub.Core.Services.Order;
using ReadHub.Core.Services.Book.Models;
using ReadHub.Core.Services.Book;
using ReadHub.Core.Services.Order.Models;
using Microsoft.EntityFrameworkCore;

namespace ReadHub.Core
{
	public class OrderService : IOrderService
	{
		private readonly ReadHubDbContext context;
		private readonly IBookService books;

		public OrderService(ReadHubDbContext _context, IBookService _books)
		{
			this.context = _context;
			this.books = _books;
		}

		public async Task<OrderServiceModel> GetOrderByUserId(string id)
		{
			var newOrder = await this.context.
				Orders
				.Where(o => o.UserId == id)
				.FirstOrDefaultAsync();

			if (newOrder == null)
			{
				return null;
			}

			var order = new OrderServiceModel()
			{
				UserId = newOrder.UserId,
				OrderedBooks = await this.books.GetAllBooksByOrderId(newOrder.Id)
			};

			return order;
		}

		public async Task<int> GetOrderId(string userId)
		{
			var id = await this.context
				.Orders
				.Where(o => o.UserId == userId)
				.FirstOrDefaultAsync();

			return id.Id;
		}
	}
}

