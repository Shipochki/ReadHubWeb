using ReadHub.Core.Data.Entities;
using ReadHub.Core.Services.Order;
using ReadHub.Core.Services.Book.Models;
using ReadHub.Core.Services.Book;
using ReadHub.Core.Services.Order.Models;

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
				var correctBook = await this.books.DetailsById(book.Id);

				var newBook = new Book
				{
					Id = correctBook.Id,
					Title = correctBook.Title,
					Description = correctBook.Description,
					PublisherId = correctBook.PublisherId,
					ImageUrlLink = correctBook.ImageUrlLink,
					AuthorId = correctBook.AuthorId,
					Language = correctBook.Language,
					Nationality = correctBook.Nationality,
					Price = correctBook.Price,
					Genre = correctBook.Genre,
					Year = correctBook.Year,
					TypeBook = correctBook.TypeBook
				};

				curentBooks.Add(newBook);
			}

			var order = new Order()
			{
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

		public async Task<OrderServiceModel> GetOrderById(int id)
		{
			var newOrder = await this.context.Orders.FindAsync(id);

			if(newOrder == null)
			{
				return null;
			}

			var curentBooks = new List<BookServiceModel>();

			foreach (var book in newOrder.OrderedBooks)
			{
				var correctBook = await this.books.DetailsById(book.Id);

				var newBook = new BookServiceModel
				{
					Id = correctBook.Id,
					Title = correctBook.Title,
					Description = correctBook.Description,
					PublisherId = correctBook.PublisherId,
					ImageUrlLink = correctBook.ImageUrlLink,
					AuthorId = correctBook.AuthorId,
					Language = correctBook.Language,
					Nationality = correctBook.Nationality,
					Price = correctBook.Price,
					Genre = correctBook.Genre,
					Year = correctBook.Year,
					TypeBook = correctBook.TypeBook
				};

				curentBooks.Add(newBook);
			}

			return new OrderServiceModel()
			{
				UserId = newOrder.UserId,
				OrderedBooks = curentBooks
			};
		}
	}
}
