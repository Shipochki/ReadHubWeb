using ReadHub.Core.Services.Favorite.Models;

namespace ReadHub.Core.Services.Favorite
{
	public interface IFavoriteService
	{
		public Task AddToFavorite(int bookId, string userId);

		public Task RemoveFromFavorite(int bookId, string userId);

		public Task<FavoriteServiceModel> GetAllFavorite(string userId);
	}
}
