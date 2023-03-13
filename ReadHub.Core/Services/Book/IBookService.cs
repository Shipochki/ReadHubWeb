namespace ReadHub.Core.Services.Book
{
	using ReadHub.Core.Services.Book.Models;

	public interface IBookService
	{
		Task<IEnumerable<BookServiceModel>> All();

		Task<IEnumerable<BookServiceModel>> GetAllBooksById(int id);

		Task<BookServiceModel> GetDetailsBookById(int bookId);

		Task<BookDetailServiceModel> FindBookById(int bookId);

		Task<IEnumerable<BookServiceModel>> GetAllBooksByOrderId(int orderId);

		Task<int> Create(BookCreateServiceModel model);

		Task<BookDeleteView> Delete(int bookId);

		Task Edit(int bookId, BookCreateServiceModel model);

		Task DeleteOrderById(int bookId);

	}
}
