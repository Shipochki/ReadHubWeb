using ReadHub.Core.Services.Author.Models;
using ReadHub.Core.Services.Publisher.Models;

namespace ReadHub.Core.Services.Admin
{
	public interface IAdminService
	{
		Task<int> CreateAuthor(AuthorCreateServiceModel model);

		Task<int> CreatePublisher(PublisherServiceModel model);
	}
}
