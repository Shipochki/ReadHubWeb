using Microsoft.AspNetCore.Identity;
using ReadHub.Core.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ReadHub.Core.DataConstants.User;

namespace ReadHub.Core.Data
{
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
