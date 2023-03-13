namespace ReadHub.Core.Services.Favorite
{
	using Microsoft.EntityFrameworkCore;
	using ReadHub.Core.Services.Book;
	using ReadHub.Core.Data.Entities;
	using ReadHub.Core.Services.VirtualBook.Models;
	using ReadHub.Core.Services.Favorite.Models;

	public class FavoriteService : IFavoriteService
	{
		private readonly ReadHubDbContext context;
		private readonly IBookService book;

		public FavoriteService(ReadHubDbContext _context, IBookService _book)
		{
			this.context = _context;
			this.book = _book;
		}

		public async Task AddToFavorite(int bookId, string userId)
		{
			var book = await this.book.GetDetailsBookById(bookId);

			if (!await IsContainFavoriteWithUserId(userId))
			{
				await CreateFavoriteWithUserId(userId);
			}

			var favorite = await this.context.Favorites.FirstOrDefaultAsync(f => f.UserId == userId);

			var virtualBook = new VirtualBook
			{
				Title = book.Title,
				ImageUrlLink = book.ImageUrlLink,
				ReaderUrlLInk = book.ReaderUrlLink,
				BookId = bookId,
				Price = book.Price,
			};

			favorite.FavoriteBooks.Add(virtualBook);

			await this.context.VirtualBooks.AddAsync(virtualBook);
			await this.context.SaveChangesAsync();
		}

		public async Task RemoveFromFavorite(int bookId, string userId)
		{
			var favorite = await this.context
				.Favorites
				.Include(c => c.FavoriteBooks)
				.FirstOrDefaultAsync(c => c.UserId == userId);

			var virtualBook = favorite.FavoriteBooks.FirstOrDefault(vb => vb.BookId == bookId);

			favorite.FavoriteBooks.Remove(virtualBook);

			this.context.VirtualBooks.Remove(virtualBook);

			await this.context.SaveChangesAsync();
		}

		public async Task<FavoriteServiceModel> GetAllFavorite(string userId)
		{
			var favorite = await this.context
				.Favorites
				.Where(f => f.UserId == userId)
				.Select(f => new FavoriteServiceModel
				{
					UserId= userId,
					FavoriteBooks = f.FavoriteBooks
					.Select(fb => new VirtualBookServiceModel
					{
						Title= fb.Title,
						ImageUrlLink = fb.ImageUrlLink,
						ReaderUrlLInk = fb.ReaderUrlLInk,
						BookId=fb.BookId,
						Price=fb.Price,
					})
					.ToList()
				})
				.FirstOrDefaultAsync();

			return favorite;
		}

		private async Task CreateFavoriteWithUserId(string userId)
		{
			var favorite = new Favorite
			{
				UserId = userId,
			};

			await this.context.Favorites.AddAsync(favorite);
			await this.context.SaveChangesAsync();
		}

		private async Task<bool> IsContainFavoriteWithUserId(string userId)
		{
			return await this.context
				.Favorites
				.AnyAsync(f => f.UserId == userId);
		}


	}
}
