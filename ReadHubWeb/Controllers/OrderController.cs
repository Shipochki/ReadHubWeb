using HouseRentingSystem.Infranstructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadHub.Core.Services.Book;
using ReadHub.Core.Services.Order;
using ReadHub.Core.Services.VirtualBook.Models;

namespace ReadHub.Web.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderService orders;

		public OrderController(IOrderService _order, IBookService _book)
		{
			this.orders = _order;
		}

		public async IActionResult AddOrder(IEnumerable<VirtualBookServiceModel> virtualBooks)
		{
			await this.orders.AddOrder(virtualBooks);

			return RedirectToAction("MyCart", "Cart", this.User.Id());
		}
	}
}
