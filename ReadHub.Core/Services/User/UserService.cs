using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.User
{
	public class UserService : IUserService
	{
		private readonly ReadHubDbContext context;

		public UserService(ReadHubDbContext _context)
		{
			this.context = _context;
		}

		public async Task<string> GetFistName(string userId)
		{
			var user = await this.context.Users.FindAsync(userId);

			return user.FirstName;
		}
	}
}
