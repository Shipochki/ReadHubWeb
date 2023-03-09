using ReadHub.Core.Data.Entities;
using ReadHub.Core.Services.Admin;
using ReadHub.Core.Services.Author.Models;
using ReadHub.Core.Services.Publisher.Models;

namespace ReadHub.Core
{
	public class AdminService : IAdminService
	{
		private readonly ReadHubDbContext context;

		public AdminService(ReadHubDbContext _context)
		{
			this.context = _context;
		}

		public async Task<int> CreateAuthor(AuthorCreateServiceModel model)
		{
			var author = new Author
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				PhoneNumber = model.PhoneNumber,
				UserId = null
			};

			await this.context.Authors.AddAsync(author);
			await this.context.SaveChangesAsync();

			return author.Id;
		}

		public Task<int> CreatePublisher(PublisherServiceModel model)
		{
			throw new NotImplementedException();
		}
	}
}
