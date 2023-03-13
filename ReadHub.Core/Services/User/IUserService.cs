namespace ReadHub.Core.Services.User
{
	public interface IUserService
	{
		Task<string> GetFistName(string userId);
	}
}
