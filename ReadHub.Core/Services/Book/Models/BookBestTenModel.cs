namespace ReadHub.Core.Services.Book.Models
{
    public class BookBestTenModel
    {
       public ICollection<BookFrontPageModel> TenBooks { get; set; } = new List<BookFrontPageModel>();
    }
}
