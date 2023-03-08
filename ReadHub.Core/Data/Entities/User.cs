using Microsoft.AspNetCore.Identity;
using ReadHub.Core.Data.Entities;
using System.ComponentModel.DataAnnotations;
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

        public ICollection<Book> EBooks { get; set; } = new List<Book>();

        public Cart Cart { get; set; } = null!;
    }
}
