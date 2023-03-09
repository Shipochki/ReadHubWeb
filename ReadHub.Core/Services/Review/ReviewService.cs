using Microsoft.EntityFrameworkCore;
using ReadHub.Core.Services.Review.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Review
{
    public class ReviewService : IReviewService
    {
        private readonly ReadHubDbContext context;

        public ReviewService(ReadHubDbContext _context)
        {
            this.context = _context;
        }

        public async Task<IEnumerable<ReviewModelService>> AllWithIdBook(int bookId)
        {
            return await this.context
                .Reviews
                .Where(r => r.BookId == bookId)
                .Select(r => new ReviewModelService
                {
                    Raiting = r.Raiting,
                    Comment = r.Comment,
                    BookId = r.BookId,
                    UserId = r.UserId,
                })
                .ToListAsync();
        }
    }
}
