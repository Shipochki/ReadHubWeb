using ReadHubWeb.Infranstructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadHub.Core.Services.Cart;

namespace ReadHub.Web.Controllers
{
	public class CartController : Controller
	{
		private readonly ICartService cart;

		public CartController(ICartService cart)
		{
			this.cart = cart;
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> AddCart(int id)
		{
			await this.cart.AddToCart(id, this.User.Id());

			return RedirectToAction("Details", "Book", new { id });
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> MyCart()
		{
			var model = await this.cart.GetCartByUserId(this.User.Id());

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Remove(int id)
		{
			await this.cart.RemoveFromCart(id, this.User.Id());

			return RedirectToAction("Details", "Book", new { id });
		}
	}
}
