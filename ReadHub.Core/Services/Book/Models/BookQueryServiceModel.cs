using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Book.Models
{
	public class BookQueryServiceModel
	{
		public IEnumerable<BookServiceModel> Books { get; set; } = new List<BookServiceModel>();
	}
}
