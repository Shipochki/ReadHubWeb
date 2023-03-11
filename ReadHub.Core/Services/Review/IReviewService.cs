using ReadHub.Core.Services.Review.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Review
{
    public interface IReviewService
    {
        public Task<IEnumerable<ReviewDetailsServiceModel>> AllWithIdBook(int bookId);

        public Task<int> CreateReview(ReviewFormCreateModel model, string userId);

	}
}
