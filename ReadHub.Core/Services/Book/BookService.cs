using Microsoft.EntityFrameworkCore;
using ReadHub.Core.Services.Author;
using ReadHub.Core.Services.Book.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Book
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
