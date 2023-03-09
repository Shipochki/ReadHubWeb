using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Review.Models
{
    public class ReviewModelService
    {

        public int Raiting { get; set; }

        public string? Comment { get; set; }

        public int BookId { get; set; }

        public string UserId { get; set; } = null!;
    }
}
