using ReadHub.Core.Services.VirtualBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Cart.Models
{
	public class CartDetailsModel
	{
		public int Id { get; set; }

		public decimal TotalPrice { get; set; }

		public ICollection<VirtualBookDetailsModel> BooksInCart { get; set; } = new List<VirtualBookDetailsModel>();
	}
}
