﻿using ReadHub.Core.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ReadHub.Core.DataConstants.Book;

namespace ReadHub.Core.Data.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; } = null!;

        [Required]
        public string ImageUrlLink { get; set; } = null!;

        [Required]
        public string ReaderUrlLink { get; set; } = null!;

        [Required]
        public int AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public DateTime Year { get; set; }

        [Required]
        [MaxLength(LanguageMaxLength)]
        public string Language { get; set; } = null!;

        [Required]
        [MaxLength(NationalityMaxLength)]
        public string Nationality { get; set; } = null!;

        [Required]
        public TypeBook TypeBook { get; set; }

        [Required]
        public decimal Price { get; set; }

        public bool isActive { get; set; } = true;

        public ICollection<Review> Reviews { get; set; } = new List<Review>();

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public DateTime UpdatedTime { get; set;}

        public DateTime DeletedTime { get; set; }
    }
}
