using ReadHub.Core.Services.Book.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadHub.Core.Services.Review.Models
{
	public class ReviewFormCreateModel
	{
		public IEnumerable<BookServiceModel> Books { get; set; } = new List<BookServiceModel>();
		public ReviewCreateServiceModel Review { get; set; } = new ReviewCreateServiceModel(); 
	}
}
