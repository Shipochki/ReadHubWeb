using ReadHub.Core.Services.Publisher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Publisher
{
	public interface IPublisherService
	{
		Task<PublisherServiceModel> GetPublisherById(int publisherId);

		Task<IEnumerable<PublisherServiceModel>> GetAllPublishers();
	}
}
