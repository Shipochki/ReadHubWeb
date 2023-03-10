namespace ReadHub.Web.Controllers
{
	using ReadHubWeb.Infranstructure;
	using Microsoft.AspNetCore.Mvc;
	using ReadHub.Core.Services.Cart;
	using ReadHub.Core.Services.Order;
	using Microsoft.AspNetCore.Authorization;

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

			if(cart == null)
			{
				return BadRequest();
			}

			await this.orders.AddOrder(cart, this.User.Id());

			await this.cart.RemoveAll(cart, this.User.Id());

            TempData["message"] = "You have sucssessfuly added a order!";

            return RedirectToAction("MyCart", "Cart", this.User.Id());
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> MyOrders()
		{
			var orders = await this.orders.GetOrdersByUserId(this.User.Id());

			return View(orders);
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> MyLibrary()
		{
			var orders = await this.orders.GetOrdersByUserId(this.User.Id());

			return View(orders);
		}
	}
}
