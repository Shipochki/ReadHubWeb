using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadHub.Core.Services.Book;
using ReadHub.Core.Services.Order;

namespace ReadHub.Web.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderService orders;
		private readonly IBookService books;

		public OrderController(IOrderService _order, IBookService _book)
		{
			this.orders = _order;
			this.books = _book;
		}
	}
}
