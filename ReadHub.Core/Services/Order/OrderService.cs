using ReadHub.Core.Data.Entities;
using ReadHub.Core.Services.Order;
using ReadHub.Core.Services.Book.Models;
using ReadHub.Core.Services.Book;
using ReadHub.Core.Services.Order.Models;
using Microsoft.EntityFrameworkCore;
using ReadHub.Core.Services.VirtualBook.Models;
using ReadHub.Core.Services.Cart.Models;

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

		public async Task AddOrder(CartServiceModel cart, string userId)
		{
			var virtualBooks = new List<VirtualBook>();

			foreach (var book in cart.BooksInCart)
			{
				var virtualBook = new VirtualBook
				{
					Title = book.Title,
					ImageUrlLink = book.ImageUrlLink,
					ReaderUrlLInk = book.ReaderUrlLInk,
					BookId = book.BookId,
					Price = book.Price,
				};

				virtualBooks.Add(virtualBook);
			}

			var order = new Order
			{
				TotalPrice = virtualBooks.Sum(b => b.Price),
				OrderedBooks = virtualBooks,
				UserId = userId
			};

			await this.context.VirtualBooks.AddRangeAsync(virtualBooks);

			await this.context.Orders.AddAsync(order);
			await this.context.SaveChangesAsync();
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

