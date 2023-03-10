using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ReadHub.Core.DataConstants.Publisher;

namespace ReadHub.Core.Data.Entities
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public DateTime Year { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public ICollection<Book> PublishedBooks { get; set; } = new List<Book>();

    }
}
