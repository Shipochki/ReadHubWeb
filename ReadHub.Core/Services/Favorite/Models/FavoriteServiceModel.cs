namespace ReadHub.Core.Services.Favorite.Models
{
	using ReadHub.Core.Services.VirtualBook.Models;

	public class FavoriteServiceModel
	{
		public string UserId { get; set; } = null!;

		public ICollection<VirtualBookServiceModel> FavoriteBooks { get; set; } = new List<VirtualBookServiceModel>();
	}
}
