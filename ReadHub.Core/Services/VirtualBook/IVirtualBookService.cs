using ReadHub.Core.Services.VirtualBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.VirtualBook
{
	public interface IVirtualBookService
	{
		Task<VirtualBookServiceModel> GetVirtualBookByBookId(int bookId);
	}
}
