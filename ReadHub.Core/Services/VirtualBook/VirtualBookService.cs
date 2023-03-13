using Microsoft.EntityFrameworkCore;
using ReadHub.Core.Services.VirtualBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.VirtualBook
{
	public class VirtualBookService : IVirtualBookService
	{
		private readonly ReadHubDbContext context;

		public VirtualBookService(ReadHubDbContext _context)
		{
			this.context = _context;
		}

		public async Task<VirtualBookServiceModel> GetVirtualBookByBookId(int bookId)
		{
			var virtualBook = await this.context
				.VirtualBooks
				.FirstOrDefaultAsync(vb => vb.BookId == bookId);

			return new VirtualBookServiceModel()
			{
				Title = virtualBook.Title,
				ImageUrlLink = virtualBook.ImageUrlLink,
				ReaderUrlLInk = virtualBook.ReaderUrlLInk,
				Price = virtualBook.Price,
				BookId = bookId
			};
		}
	}
}
