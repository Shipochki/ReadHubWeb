using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Publisher.Models
{
	public class PublisherServiceModel
	{
		public int Id { get; set; }

		public string Name { get; set; } = null!;

		public DateTime Year { get; set; }

		public string Description { get; set; } = null!;
	}
}
