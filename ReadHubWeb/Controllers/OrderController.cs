using Microsoft.AspNetCore.Mvc;
using ReadHub.Core.Services.Order;

namespace ReadHub.Web.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderService order;

		public OrderController(IOrderService _order)
		{
			this.order = _order;
		}

		public IActionResult DeleteFromCart(int orderId, int bookId) 
		{
			var currentOrder = this.order

			return RedirectToAction("MyCart", "Book", orderId);
		}
	}
}
