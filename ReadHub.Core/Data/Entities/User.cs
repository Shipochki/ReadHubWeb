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

        public ICollection<Book> MyCart { get; set; } = new List<Book>();

        public ICollection<Book> EBooks { get; set; } = new List<Book>();

        public ICollection<Review> MyReviews { get; set; } = new List<Review>();

        public ICollection<Order> MyOrders { get; set; } = new List<Order>();

        public ICollection<Book> Favorite { get; set; } = new List<Book>();

        public bool IsActive { get; set; } = true;

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public DateTime UpdatedTime { get; set; }

        public DateTime DeletedTime { get; set; }
    }
}
