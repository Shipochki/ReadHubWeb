using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ReadHub.Core.DataConstants.Publisher;

namespace ReadHub.Core.Services.Publisher.Models
{
	public class PublisherCreateServiceModel
	{
		[Required]
		[MaxLength(NameMaxLength)]
		[MinLength(NameMinLength)]
		public string Name { get; set; } = null!;

		public DateTime Year { get; set; }

		[Required]
		[MaxLength(DescriptionMaxLength)]
		[MinLength(DescriptionMinLength)]
		public string Description { get; set; } = null!;
	}
}
