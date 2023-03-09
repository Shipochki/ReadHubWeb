using ReadHub.Core.Services.Book.Models;

namespace ReadHub.Core.Services.Book
{
    public interface IBookService
    {
        Task<IEnumerable<BookServiceModel>> All();

        Task<BookServiceModel> DetailsById(int bookId);
    }
}
