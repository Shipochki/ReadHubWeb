namespace ReadHub.Core.Services.Author
{
	using Microsoft.EntityFrameworkCore;
	using ReadHub.Core.Services.Author.Models;
	using ReadHub.Core.Services.Book.Models;

	public class AuthorService : IAuthorService
	{
		private readonly ReadHubDbContext context;

		public AuthorService(ReadHubDbContext _context)
		{
			this.context = _context;
		}

		public async Task<IEnumerable<AuthorServiceModel>> GetAllAuthors()
		{
			return await this.context
				.Authors
				.Select(x => new AuthorServiceModel()
				{
					Id = x.Id,
					FirstName = x.FirstName,
					LastName = x.LastName,
				})
				.ToListAsync();
		}

		public async Task<AuthorDetailsModel> GetAuthorById(int authorId)
		{
			var author = await this.context
				.Authors
				.Where(a => a.Id == authorId)
				.Select(a => new AuthorDetailsModel
				{
					FirstName = a.FirstName,
					LastName = a.LastName,
					Books = a.PublishedBooks
					.Where(b => b.isActive == true)
					.Select(b => new BookDetailPublisherModel
					{
						Id = b.Id,
						Title = b.Title,
						Description = b.Description,
						AuthorId = b.AuthorId,
						AuthorName = a.FirstName + " " + a.LastName,
						PublisherId = b.PublisherId,
						PublisherName = b.Publisher.Name,
						ImageUrlLink = b.ImageUrlLink,
						ReaderUrlLink = b.ReaderUrlLink,
						Year = b.Year,
						TypeBook = b.TypeBook,
						Genre = b.Genre,
						Language = b.Language,
						Nationality = b.Nationality,
						Price = b.Price,
					})
				})
				.FirstOrDefaultAsync();

			return author;
		}
	}
}
