namespace ReadHub.Core.Services.User
{
	public interface IUserService
	{
		Task<string> GetFistName(string userId);

		Task<bool> IsExistUserWithNumber(string phoneNumber);

		Task<string> GetUserIdByPhoneNumber(string phoneNumber);
	}
}
