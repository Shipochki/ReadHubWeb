using Microsoft.EntityFrameworkCore;
using ReadHub.Core.Services.Publisher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Publisher
{
	public class PublisherService : IPublisherService
	{
		private readonly ReadHubDbContext context;

		public PublisherService(ReadHubDbContext _context)
		{
			this.context= _context;
		}

		public async Task<IEnumerable<PublisherServiceModel>> GetAllPublishers()
		{
			return await this.context
				.Publisher
				.Select(p => new PublisherServiceModel
				{
					Id = p.Id,
					Name = p.Name,
					Description= p.Description,
					Year= p.Year,
				})
				.ToListAsync();
		}

		public async Task<PublisherServiceModel> GetPublisherById(int publisherId)
		{
			var publisher = await this.context.Publisher.FindAsync(publisherId);

			return new PublisherServiceModel()
			{
				Name = publisher.Name,
				Year = publisher.Year,
				Description = publisher.Description,
			};
		}
	}
}
