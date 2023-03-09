using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ReadHub.Core.DataConstants.Author;

namespace ReadHub.Core.Services.Author.Models
{
	public class AuthorCreateServiceModel
	{
		[Required]
		[MaxLength(FirstNameMaxLength)]
		[MinLength(FirstNameMinLenght)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MaxLength(LastNameMaxLength)]
		[MinLength(LastNameMinLength)]
		public string LastName { get; set; } = null!;

		[MaxLength(PhoneNumberMaxLength)]
		[MinLength(PhoneNumberMinLength)]
		public string? PhoneNumber { get; set; }

	}
}