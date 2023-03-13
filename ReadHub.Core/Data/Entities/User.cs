namespace ReadHub.Core.Data
{
	using Microsoft.AspNetCore.Identity;
	using System.ComponentModel.DataAnnotations;
	using static ReadHub.Core.DataConstants.User;

	public class User : IdentityUser
	{
		[Required]
		[MaxLength(FirstNameMaxLength)]
		public string FirstName { get; set; } = null!;

		[Required]
		[MaxLength(LastNameMaxLength)]
		public string LastName { get; set; } = null!;

		public bool IsActive { get; set; } = true;
	}
}
