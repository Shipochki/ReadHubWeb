using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Book.Models
{
	public class BookDeleteView
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string ImageUrlLink { get; set; }
	}
}
