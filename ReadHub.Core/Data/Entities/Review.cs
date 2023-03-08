using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ReadHub.Core.DataConstants.Review;

namespace ReadHub.Core.Data.Entities
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Raiting { get; set; }

        [MaxLength(CommentMaxLength)]
        public string? Comment { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

        public DateTime CreatedTime { get; set; } = DateTime.Now;

        public DateTime UpdatedTime { get; set; }

        public DateTime DeletedTime { get; set; }
    }
}
