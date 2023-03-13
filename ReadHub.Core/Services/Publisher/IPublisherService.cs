namespace ReadHub.Core.Services.Publisher
{
	using ReadHub.Core.Services.Publisher.Models;

	public interface IPublisherService
	{
		Task<PublisherDetailsModel> GetPublisherById(int publisherId);

		Task<IEnumerable<PublisherServiceModel>> GetAllPublishers();
	}
}
