using Microsoft.EntityFrameworkCore;
using ReadHub.Core.Data.Entities;
using ReadHub.Core.Services.Book;
using ReadHub.Core.Services.Book.Models;

namespace ReadHub.Core
{
    public class BookService : IBookService
    {
        private readonly ReadHubDbContext context;

        public BookService(ReadHubDbContext _context)
        {
            this.context = _context;
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
                    ReaderUrlLink = b.ReaderUrlLink,
                    AuthorFullName = b.Author.FirstName + " " + b.Author.LastName,
                    Genre = b.Genre.ToString(),
                    Year = b.Year.Year.ToString(),
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

		public async Task<BookServiceModel> DetailsById(int bookId)
		{
            var book = await this.context.Books.FindAsync(bookId);

            var result = new BookServiceModel
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                PublisherName = book.Publisher.Name,
                ImageUrlLink = book.ImageUrlLink,
                ReaderUrlLink = book.ReaderUrlLink,
                AuthorFullName = book.Author.FirstName + " " + book.Author.LastName,
                Genre = book.Genre.ToString(),
                Year = book.Year.Year.ToString(),
            };

            return result;
		}
	}
}
