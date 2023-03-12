using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadHub.Core.Services.VirtualBook.Models;

namespace ReadHub.Core.Services.Cart.Models
{
	public class CartServiceModel
	{
		public int Id { get; set; }

		public decimal TotalPrice { get; set; }

		public ICollection<VirtualBookServiceModel> BooksInCart { get; set; } = new List<VirtualBookServiceModel>();
	}
}
