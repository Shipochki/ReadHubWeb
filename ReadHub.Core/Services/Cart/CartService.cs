namespace ReadHub.Core.Services.Cart
{
	using Microsoft.EntityFrameworkCore;
	using ReadHub.Core.Services.Book;
	using ReadHub.Core.Data.Entities;
	using ReadHub.Core.Services.Cart.Models;
	using ReadHub.Core.Services.VirtualBook.Models;
	using System;
	using ReadHub.Core.Services.VirtualBook;

	public class CartService : ICartService
	{
		private readonly ReadHubDbContext context;
		private readonly IBookService book;
		private readonly IVirtualBookService virtualBook;

		public CartService(ReadHubDbContext _context, IBookService _book, IVirtualBookService _virtualBook)
		{
			this.context = _context;
			this.book = _book;
			this.virtualBook = _virtualBook;
		}

		public async Task AddToCart(int bookId, string userId)
		{
			var book = await this.book.GetDetailsBookById(bookId);

			if(!await IsContainCartWithUserId(userId))
			{
				await CreateCartWithUserId(userId);
			}

			var cart = await this.context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

			var virtualBook = new VirtualBook
			{
				Title = book.Title,
				ImageUrlLink = book.ImageUrlLink,
				ReaderUrlLInk = book.ReaderUrlLink,
				BookId = bookId,
				Price = book.Price,
			};

			if(cart == null)
			{
				return;
			}

			cart.BooksInCart.Add(virtualBook);

			await this.context.VirtualBooks.AddAsync(virtualBook);
			await this.context.SaveChangesAsync();
		}

		private async Task CreateCartWithUserId(string userId)
		{
			var newCart = new Cart
			{
				UserId = userId,
			};

			await this.context.Carts.AddAsync(newCart);
			await this.context.SaveChangesAsync();
		}

		private async Task<bool> IsContainCartWithUserId(string userId)
		{
			return await this.context
				.Carts
				.AnyAsync(c => c.UserId == userId);
		}

		public async Task<CartServiceModel> GetCartByUserId(string userId)
		{
			var cart = await this.context
				.Carts
				.Where(c => c.UserId == userId)
				.Select(c => new CartServiceModel
				{
					Id = c.Id,
					TotalPrice = c.BooksInCart.Sum(b => b.Price),
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

		public async Task RemoveVirtualBookFromCart(int bookId, string userId)
		{
			var cart = await this.context
				.Carts
				.Include(c => c.BooksInCart)
				.FirstOrDefaultAsync(c => c.UserId == userId);


			var virtualBook = cart.BooksInCart.FirstOrDefault(vb => vb.BookId == bookId);

			cart.BooksInCart.Remove(virtualBook);

			this.context.VirtualBooks.Remove(virtualBook);

			await this.context.SaveChangesAsync();
		}
	}
}
