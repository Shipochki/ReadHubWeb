using System.ComponentModel.DataAnnotations;
using static ReadHub.Core.DataConstants.Review;

namespace ReadHub.Core.Services.Review.Models
{
    public class ReviewModelService
    {
        [Required]
        [Range(RatingRangeMin, RatingRangeMax)]
        public int Raiting { get; set; }

        public string? Comment { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public string UserId { get; set; } = null!;
    }
}
