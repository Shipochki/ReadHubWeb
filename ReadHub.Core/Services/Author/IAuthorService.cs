namespace ReadHub.Core.Services.Author
{
	using ReadHub.Core.Services.Author.Models;

	public interface IAuthorService
	{
		Task<AuthorDetailsModel> GetAuthorById(int authorId);

		Task<IEnumerable<AuthorServiceModel>> GetAllAuthors();
	}
}
