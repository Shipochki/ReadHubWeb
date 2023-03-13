namespace ReadHub.Core.Services.Admin
{
	using ReadHub.Core.Services.Author.Models;
	using ReadHub.Core.Services.Publisher.Models;

	public interface IAdminService
	{
		Task<int> CreateAuthor(AuthorCreateServiceModel model);

		Task<int> CreatePublisher(PublisherCreateServiceModel model);
	}
}
