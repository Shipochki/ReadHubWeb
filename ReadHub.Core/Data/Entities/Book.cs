using ReadHub.Core.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Data.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public Publisher Publishers { get; set; } = null!;

        public string UrlLink { get; set; } = null!;

        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public Genre Genre { get; set; }

        public DateTime Year { get; set; }

        public string Language { get; set; } = null!;

        public string Nationality { get; set; } = null!;

        public TypeBook TypeBook { get; set; }

        public decimal Price { get; set; }

        public bool isActive { get; set; } = true;
    }
}
