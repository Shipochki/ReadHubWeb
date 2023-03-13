namespace ReadHub.Core
{
	using ReadHub.Core.Data.Entities;
	using ReadHub.Core.Services.Admin;
	using ReadHub.Core.Services.Author.Models;
	using ReadHub.Core.Services.Publisher.Models;
	using ReadHub.Core.Services.User;

	public class AdminService : IAdminService
	{
		private readonly ReadHubDbContext context;
		private readonly IUserService users;

		public AdminService(
			ReadHubDbContext _context,
			IUserService _users)
		{
			this.context = _context;
			this.users = _users;
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

			if(!string.IsNullOrEmpty(author.PhoneNumber) && 
				await this.users.IsExistUserWithNumber(author.PhoneNumber))
			{
				var userId = await this.users.GetUserIdByPhoneNumber(author.PhoneNumber);
				author.UserId = userId;
			}

			await this.context.Authors.AddAsync(author);
			await this.context.SaveChangesAsync();

			return author.Id;
		}

		public async Task<int> CreatePublisher(PublisherCreateServiceModel model)
		{
			var publisher = new Publisher
			{
				Name = model.Name,
				Year = model.Year,
				Description = model.Description,
			};

			await this.context.Publisher.AddAsync(publisher);
			await this.context.SaveChangesAsync();

			return publisher.Id;
		}
	}
}
