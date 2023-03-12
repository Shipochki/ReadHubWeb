using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.VirtualBook.Models
{
	public class VirtualBookServiceModel
	{
		public string Title { get; set; } = null!;

		public string ImageUrlLink { get; set; } = null!;

		public string ReaderUrlLInk { get; set; } = null!;

		public int BookId { get; set; }

		public decimal Price { get; set; }
	}
}
