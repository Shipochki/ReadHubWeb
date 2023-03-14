using Microsoft.EntityFrameworkCore;

namespace ReadHub.Core.Services.User
{
	public class UserService : IUserService
	{
		private readonly ReadHubDbContext context;

		public UserService(ReadHubDbContext _context)
		{
			this.context = _context;
		}

		public bool CorrectUserName(string userName, string reviewUserName)
		{
			if(userName == reviewUserName)
			{
				return true;
			}

			return false;
		}

		public async Task<string> GetFistName(string userId)
		{
			var user = await this.context.Users.FindAsync(userId);

			return user.FirstName;
		}

		public async Task<string> GetUserIdByPhoneNumber(string phoneNumber)
		{
			var user = await this.context
				.Users
				.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

			return user.Id;
		}

		public async Task<bool> IsExistUserWithNumber(string phoneNuber)
		{
			return await this.context
				.Users
				.AnyAsync(u => u.PhoneNumber == phoneNuber);
		}
	}
}
