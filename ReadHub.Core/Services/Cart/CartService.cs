namespace ReadHub.Core.Services.Cart
{
	using Microsoft.EntityFrameworkCore;
	using ReadHub.Core.Services.Cart.Models;
	using ReadHub.Core.Services.VirtualBook;
	using ReadHub.Core.Services.VirtualBook.Models;

	public class CartService : ICartService
	{
		private readonly ReadHubDbContext context;

		public CartService(ReadHubDbContext _context)
		{
			this.context = _context;
		}

		public async Task<CartServiceModel> GetCartByUserId(string userId)
		{
			var cart = await this.context
				.Carts
				.Where(c => c.UserId == userId)
				.Select(c => new CartServiceModel
				{
					Id = c.Id,
					TotalPrice = c.TotalPrice,
					BooksInCart = c.BooksInCart
					.Select(bc => new VirtualBookServiceModel
					{
						Title = bc.Title,
						ImageUrlLink = bc.ImageUrlLink,
						ReaderUrlLInk = bc.ReaderUrlLInk,
						BookId = bc.BookId,
						Price = bc.Price,
					})
					.ToList()
				})
				.FirstOrDefaultAsync();

			return cart;
		}
	}
}
