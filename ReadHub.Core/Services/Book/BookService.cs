using Microsoft.EntityFrameworkCore;
using ReadHub.Core.Data.Entities;
using ReadHub.Core.Data.Enum;
using ReadHub.Core.Services.Author;
using ReadHub.Core.Services.Book;
using ReadHub.Core.Services.Book.Models;
using ReadHub.Core.Services.Publisher;

namespace ReadHub.Core
{
	public class BookService : IBookService
	{
		private readonly ReadHubDbContext context;
		private readonly IAuthorService author;
		private readonly IPublisherService publisher;

		public BookService(ReadHubDbContext _context, IAuthorService _author, IPublisherService _publisher)
		{
			this.context = _context;
			this.author = _author;
			this.publisher = _publisher;
		}

		public async Task<IEnumerable<BookServiceModel>> All()
		{
			return await this.context
				.Books
				.Where(b => b.isActive == true)
				.Select(b => new BookServiceModel
				{
					Id = b.Id,
					Title = b.Title,
					Description = b.Description,
					PublisherName = b.Publisher.Name,
					ImageUrlLink = b.ImageUrlLink,
					AuthorFullName = b.Author.FirstName + " " + b.Author.LastName,
					Language = b.Language,
					Nationality = b.Nationality,
					Price = b.Price,
					Genre = b.Genre,
					Year = b.Year,
					TypeBook = b.TypeBook
				})
				.ToListAsync();
		}

		public async Task<int> Create(BookCreateServiceModel model)
		{
			var newBook = new Book
			{
				Title = model.Title,
				Description = model.Description,
				ImageUrlLink = model.ImageUrlLink,
				ReaderUrlLink = model.ReaderUrlLink,
				PublisherId = model.PublisherId,
				AuthorId = model.AuthorId,
				Genre = model.Genre,
				Year = model.Year,
				Language = model.Language,
				Nationality = model.Nationality,
				TypeBook = model.TypeBook,
				Price = model.Price,
			};

			await this.context.Books.AddAsync(newBook);
			await this.context.SaveChangesAsync();

			return newBook.Id;
		}

		public async Task<BookDeleteView> Delete(int bookId)
		{
			var book = await this.context.Books.FindAsync(bookId);

			book.isActive = false;

			await this.context.SaveChangesAsync();

			return new BookDeleteView()
			{
				Title = book.Title,
				ImageUrlLink = book.ImageUrlLink
			};
		}

		public async Task<BookServiceModel> DetailsById(int bookId)
		{
			var book = await this.context.Books.FindAsync(bookId);

			if (book == null)
			{
				return null;
			}

			var publisherName = await this.publisher.GetPublisherById(book.PublisherId);
			var author = await this.author.GetAuthorById(book.AuthorId);

			var result = new BookServiceModel
			{
				Id = bookId,
				Title = book.Title,
				Description = book.Description,
				PublisherName = publisherName.Name,
				ImageUrlLink = book.ImageUrlLink,
				AuthorFullName = author.FirstName + " " + author.LastName,
				Language = book.Language,
				Nationality = book.Nationality,
				Price = book.Price,
				Genre = book.Genre,
				TypeBook = book.TypeBook,
				Year = book.Year
			};

			return result;
		}

		public async Task Edit(int bookId, BookCreateServiceModel model)
		{
			var book = await this.context.Books.FindAsync(bookId);

			book.Title = model.Title;
			book.Description = model.Description;
			book.PublisherId = model.PublisherId;
			book.ImageUrlLink = model.ImageUrlLink;
			book.ReaderUrlLink = model.ReaderUrlLink;
			book.AuthorId = model.AuthorId;
			book.Language = model.Language;
			book.Nationality = model.Nationality;
			book.Price = model.Price;
			book.Genre = model.Genre;
			book.TypeBook = model.TypeBook;
			book.Year = model.Year;

			await this.context.SaveChangesAsync();
		}


		public async Task<BookDetailServiceModel> FindBookById(int bookId)
		{
			var book = await this.context.Books.FindAsync(bookId);

			var result = new BookDetailServiceModel
			{
				Title = book.Title,
				Description = book.Description,
				PublisherId = book.PublisherId,
				ImageUrlLink = book.ImageUrlLink,
				ReaderUrlLink = book.ReaderUrlLink,
				AuthorId = book.AuthorId,
				Language = book.Language,
				Nationality = book.Nationality,
				Price = book.Price,
				Genre = book.Genre,
				TypeBook = book.TypeBook,
				Year = book.Year,
			};

			return result;
		}

        public async Task<IEnumerable<BookServiceModel>> GetAllBooksByOrderId(int orderId)
        {
			var books = await this.context
				.Books
				.Where(b => b.OrderId == orderId)
				.Select(b => new BookServiceModel
				{
					Id = b.Id,
					Title = b.Title,
					Description = b.Description,
					PublisherName = b.Publisher.Name,
					PublisherId = b.PublisherId,
					ImageUrlLink = b.ImageUrlLink,
					AuthorFullName = b.Author.FirstName + " " + b.Author.LastName,
					Language = b.Language,
					Nationality = b.Nationality,
					Price = b.Price,
					Genre = b.Genre,
					TypeBook = b.TypeBook,
					Year = b.Year
				})
				.ToListAsync();

			return books;
        }
    }
}
