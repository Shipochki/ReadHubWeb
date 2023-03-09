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
        public Task<IEnumerable<ReviewModelService>> AllWithIdBook(int bookId);
    }
}
