namespace ReadHub.Core
{
	using Microsoft.EntityFrameworkCore;

	using ReadHub.Core.Data.Entities;
	using ReadHub.Core.Services.Order;
	using ReadHub.Core.Services.Order.Models;
	using ReadHub.Core.Services.VirtualBook.Models;
	using ReadHub.Core.Services.Cart.Models;

	public class OrderService : IOrderService
	{
		private readonly ReadHubDbContext context;

		public OrderService(ReadHubDbContext _context)
		{
			this.context = _context;
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

		public async Task<OrdersServiceModel> GetOrdersByUserId(string userId)
		{
			var orders = await this.context
				.Orders
				.Where(o => o.UserId == userId)
				.Select(o => new OrderServiceModel
				{
					Id = o.Id,
					TotalPrice = o.TotalPrice,
					OrderedBooks = o.OrderedBooks
					.Select(ob => new VirtualBookServiceModel
					{
						Title = ob.Title,
						ImageUrlLink = ob.ImageUrlLink,
						ReaderUrlLInk = ob.ReaderUrlLInk,
						BookId = ob.BookId,
						Price = ob.Price,
					})
					.ToList()
				})
				.ToListAsync();

			return new OrdersServiceModel()
			{
				Orders = orders
			};
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

