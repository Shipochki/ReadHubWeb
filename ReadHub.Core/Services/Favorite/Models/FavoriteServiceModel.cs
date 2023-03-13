using ReadHub.Core.Services.VirtualBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Favorite.Models
{
	public class FavoriteServiceModel
	{
		public string UserId { get; set; } = null!;

		public ICollection<VirtualBookServiceModel> FavoriteBooks { get; set; } = new List<VirtualBookServiceModel>();
	}
}
