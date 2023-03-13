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
		public async Task<IActionResult> MyCart(string id)
		{
			var model = await this.cart.GetCartByUserId(id);

			if (this.User.Id() != id)
			{
				return Unauthorized();
			}

			return View(model);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> Remove(int id)
		{
			await this.cart.RemoveVirtualBookFromCart(id, this.User.Id());

			return RedirectToAction("Details", "Book", new { id });
		}
	}
}
