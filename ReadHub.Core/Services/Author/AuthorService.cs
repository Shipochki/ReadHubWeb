using Microsoft.EntityFrameworkCore;
using ReadHub.Core.Services.Author.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly ReadHubDbContext context;

        public AuthorService(ReadHubDbContext _context)
        {
            this.context = _context;
        }

		public async Task<IEnumerable<AuthorServiceModel>> GetAllAuthors()
		{
			return await this.context
                .Authors
                .Select(x => new AuthorServiceModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                })
                .ToListAsync();
		}

		public async Task<AuthorServiceModel> GetAuthorById(int authorId)
        {
            var author = await this.context.Authors.FindAsync(authorId);

            return new AuthorServiceModel
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
            };
        }
    }
}
