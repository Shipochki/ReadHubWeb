namespace ReadHub.Core.Services.Book
{
	using ReadHub.Core.Services.Book.Models;

	public interface IBookService
	{
		Task<IEnumerable<BookServiceModel>> All();

		Task<IEnumerable<BookServiceModel>> GetBooksById(int id);

		Task<BookServiceModel> GetDetailsBookById(int bookId);

		Task<BookDetailServiceModel> FindBookById(int bookId);

		Task<int> Create(BookCreateServiceModel model);

		Task<BookDeleteView> Delete(int bookId);

		Task Edit(int bookId, BookCreateServiceModel model);

	}
}
