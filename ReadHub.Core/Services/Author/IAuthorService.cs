namespace ReadHub.Core.Services.Author
{
	using ReadHub.Core.Services.Author.Models;

	public interface IAuthorService
	{
		Task<AuthorServiceModel> GetAuthorById(int authorId);

		Task<IEnumerable<AuthorServiceModel>> GetAllAuthors();
	}
}
