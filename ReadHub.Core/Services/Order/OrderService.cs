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

		public async Task<int> AddOrder(OrderServiceModel model)
		{
			var curentBooks = new List<Book>();

			foreach (var book in model.OrderedBooks)
			{
				var correctBook = await this.context.Books.FindAsync(book.Id);

				curentBooks.Add(correctBook);
			}

			var order = new Order()
			{
				UserId = model.UserId,
				OrderedBooks = curentBooks
			};

			await this.context.Orders.AddAsync(order);
			await this.context.SaveChangesAsync();

			return order.Id;
		}

		public async Task<int> AddToCart(BookServiceModel book, string userId)
		{
			var list = new List<BookServiceModel>()
			{
				book
			};

			var id = await AddOrder(new OrderServiceModel()
			{
				UserId= userId,
				OrderedBooks = list
			});

			return id;
		}

		public async Task<OrderServiceModel> GetOrderByUserId(string id)
		{
			var newOrder = await this.context.
				Orders
				.Where(o => o.UserId == id)
				.FirstOrDefaultAsync();

			if(newOrder == null)
			{
				return null;
			}

			var curentBooks = await this.books.GetAllBooksByOrderId(newOrder.Id);

			return new OrderServiceModel()
			{
				UserId = newOrder.UserId,
				OrderedBooks = curentBooks
			};
		}
	}
}
