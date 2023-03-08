using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Data.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

        public ICollection<Book> OrderedBooks { get; set; } = new List<Book>();

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public DateTime DeletedTime { get; set; }
    }
}
