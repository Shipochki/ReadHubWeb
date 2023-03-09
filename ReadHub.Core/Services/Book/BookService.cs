using ReadHub.Core.Services.Book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Book
{
    public class BookService : IBookService
    {
        private readonly ReadHubDbContext context;

        public BookService(ReadHubDbContext _context)
        {
            this.context = _context;
        }

        public Task<IEnumerable<BookServiceModel>> All()
        {
            throw new NotImplementedException();
        }
    }
}
