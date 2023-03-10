using ReadHub.Core.Services.Author.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Author
{
    public interface IAuthorService
    {
        Task<AuthorServiceModel> GetAuthorById(int authorId);

        Task<IEnumerable<AuthorServiceModel>> GetAllAuthors();
    }
}
