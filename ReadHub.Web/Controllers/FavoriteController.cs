namespace ReadHub.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using ReadHub.Core.Services.Favorite;
	using ReadHubWeb.Infranstructure;

	public class FavoriteController : Controller
	{
		private readonly IFavoriteService favorite;

		public FavoriteController(IFavoriteService _favorite)
		{
			this.favorite = _favorite;
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> AddFavorite(int id)
		{
			await this.favorite.AddToFavorite(id, this.User.Id());

            TempData["message"] = "You have sucssessfuly added a book to favorite!";

            return RedirectToAction("Details", "Book", new { id });
		}

		[Authorize]
		[HttpPost]
		public async Task<IActionResult> Remove(int id)
		{
			await this.favorite.RemoveFromFavorite(id, this.User.Id());

			return View(nameof(AllFavorite));
		}

		[Authorize]
		[HttpGet]
		public async Task<IActionResult> AllFavorite()
		{
			var favorite = await this.favorite.GetAllFavorite(this.User.Id());

			return View(favorite);
		}
	}
}
