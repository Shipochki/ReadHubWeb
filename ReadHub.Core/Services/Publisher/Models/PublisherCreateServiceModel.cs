namespace ReadHub.Core.Services.Publisher.Models
{
	using System.ComponentModel.DataAnnotations;
	using static ReadHub.Core.DataConstants.Publisher;

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
