using ReadHub.Core.Data.Entities;
using ReadHub.Core.Services.Book.Models;

namespace ReadHub.Core.Services.Book
{
    public interface IBookService
    {
        Task<IEnumerable<BookServiceModel>> All();

        Task<BookServiceModel> DetailsById(int bookId);

        Task<BookDetailServiceModel> FindBookById(int bookId);

        Task<IEnumerable<BookServiceModel>> GetAllBooksByOrderId(int orderId);

        Task<int> Create(BookCreateServiceModel model);

        Task<BookDeleteView> Delete(int bookId);

        Task Edit(int bookId, BookCreateServiceModel model);
    }
}
