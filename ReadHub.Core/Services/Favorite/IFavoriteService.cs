namespace ReadHub.Core.Services.Favorite
{
	using ReadHub.Core.Services.Favorite.Models;
	public interface IFavoriteService
	{
		public Task AddToFavorite(int bookId, string userId);

		public Task RemoveFromFavorite(int bookId, string userId);

		public Task<FavoriteServiceModel> GetAllFavorite(string userId);
	}
}
