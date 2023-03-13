namespace ReadHub.Core.Services.Publisher
{
	using Microsoft.EntityFrameworkCore;
	using ReadHub.Core.Services.Book;
	using ReadHub.Core.Services.Book.Models;
	using ReadHub.Core.Services.Publisher.Models;

	public class PublisherService : IPublisherService
	{
		private readonly ReadHubDbContext context;

		public PublisherService(
			ReadHubDbContext _context)
		{
			this.context = _context;
		}

		public async Task<IEnumerable<PublisherServiceModel>> GetAllPublishers()
		{
			return await this.context
				.Publisher
				.Select(p => new PublisherServiceModel
				{
					Id = p.Id,
					Name = p.Name,
					Description = p.Description,
					Year = p.Year,
				})
				.ToListAsync();
		}

		public async Task<PublisherDetailsModel> GetPublisherById(int publisherId)
		{
			var publisher = await this.context
				.Publisher
				.Where(p => p.Id == publisherId)
				.Select(p => new PublisherDetailsModel
				{
					Name = p.Name,
					Description = p.Description,
					Year = p.Year,
					Books = p.PublishedBooks
					.Where(b => b.isActive == true)
					.Select(b => new BookDetailPublisherModel
					{
						Id = b.Id,
						Title = b.Title,
						Description = b.Description,
						AuthorId = b.AuthorId,
						AuthorName = b.Author.FirstName + " " + b.Author.LastName,
						PublisherId = b.PublisherId,
						PublisherName = p.Name,
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

			return publisher;
		}
	}
}
