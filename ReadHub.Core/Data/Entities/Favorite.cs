namespace ReadHub.Core.Data.Entities
{
	using System.ComponentModel.DataAnnotations;
	using System.ComponentModel.DataAnnotations.Schema;

	public class Favorite
	{
		[Key]
		public int Id { get; set; }

		[ForeignKey(nameof(User))]
		public string UserId { get; set; } = null!;
		public User User { get; set; } = null!;

		public ICollection<VirtualBook> FavoriteBooks { get; set; } = new List<VirtualBook>();
	}
}
