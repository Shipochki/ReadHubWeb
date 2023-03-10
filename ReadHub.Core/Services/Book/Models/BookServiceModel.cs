using ReadHub.Core.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Book.Models
{
    public class BookServiceModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string PublisherName { get; set; } = null!;

        public int PublisherId { get; set; }

        public string ImageUrlLink { get; set; } = null!;

        public string AuthorFullName { get; set; } = null!;

        public int AuthorId { get; set; }

        public Genre Genre { get; set; }

        public DateTime Year { get; set; }

        public string Language { get; set; } = null!;

        public string Nationality { get; set; } = null!;

        public TypeBook TypeBook { get; set; }

        public decimal Price { get; set; }
    }
}
