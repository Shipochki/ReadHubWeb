using ReadHubWeb.Infranstructure;
using Microsoft.AspNetCore.Mvc;
using ReadHub.Core.Services.Cart;
using ReadHub.Core.Services.Cart.Models;
using ReadHub.Core.Services.Order;
using Microsoft.AspNetCore.Authorization;

namespace ReadHub.Web.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrderService orders;
		private readonly ICartService cart;

		public OrderController(IOrderService _order, ICartService _cart)
		{
			this.orders = _order;
			this.cart = _cart;
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> AddOrder(int id)
		{
			var cart = await this.cart.GetCartById(id);

			await this.orders.AddOrder(cart, this.User.Id());

			await this.cart.RemoveAll(cart, this.User.Id());

			return RedirectToAction("MyCart", "Cart", this.User.Id());
		}

		public async Task<IActionResult> MyOrders(string userId)
		{
			return View();
		}
	}
}
