using ReadHub.Core.Services.VirtualBook.Models;

namespace ReadHub.Core.Services.VirtualBook
{
	public interface IVirtualBookService
	{
		Task<VirtualBookServiceModel> GetVirtualBookByBookId(int bookId);
	}
}
