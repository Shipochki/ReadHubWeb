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

		//public async Task<int> AddOrder(OrderServiceModel model)
		//{
			
		//}

		//public async Task<int> AddToCart(BookServiceModel book, string userId)
		//{
			
		//}

		//private async Task<int> AddToOrder(BookServiceModel book, string userId)
		//{
			
		//}

		private bool IsContainOrder(string userId)
		{
			var order = this.context.Orders
				.Where(o => o.UserId == userId)
				.FirstOrDefault();

			if(order == null)
			{
				return false;
			}

			return true;
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

		//public async Task DeleteBookFromOrder(int order,int bookId)
		//{
		//	var currentOrder = await this.context.Orders.FindAsync(order);

		//	if(currentOrder== null)
		//	{
		//		return;
		//	}

		//	var book = await this.context.Books.FindAsync(bookId);

		//	if(book==null)
		//	{
		//		return;
		//	}

		//	currentOrder.OrderedBooks.Remove(book);

		//	await this.context.SaveChangesAsync();
		//}

		public int GetOrderId(string userId)
		{
			return this.context
				.Orders
				.Where(o => o.UserId == userId)
				.FirstOrDefault()
				.Id;
		}
	}
}
