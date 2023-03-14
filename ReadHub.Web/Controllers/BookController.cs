namespace ReadHub.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ReadHub.Core.Services.Book;
    using ReadHub.Core.Services.Book.Models;
    using ReadHub.Core.Services.Author;
    using ReadHub.Core.Services.Publisher;
    using Microsoft.AspNetCore.Authorization;
    using ReadHubWeb.Infranstructure;

    public class BookController : Controller
    {
        private readonly IBookService books;
        private readonly IAuthorService author;
        private readonly IPublisherService publisher;

        public BookController(IBookService _bookService,
            IAuthorService _author,
            IPublisherService _publisher)
        {
            this.books = _bookService;
            this.author = _author;
            this.publisher = _publisher;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var books = await this.books.All();
            var result = new BookQueryServiceModel
            {
                Books = books
            };

            return View("All", result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var detail = await this.books.GetDetailsBookById(id);

            if (detail == null)
            {
                return BadRequest();
            }

            return View(detail);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!this.User.IsAdmin())
            {
                return Unauthorized();
            }

            var book = await books.FindBookById(id);
            book.Authors = await this.author.GetAllAuthors();
            book.Publishers = await this.publisher.GetAllPublishers();
            return View(new BookCreateServiceModel()
            {
                Title = book.Title,
                Description = book.Description,
                PublisherId = book.PublisherId,
                ImageUrlLink = book.ImageUrlLink,
                ReaderUrlLink = book.ReaderUrlLink,
                AuthorId = book.AuthorId,
                Language = book.Language,
                Nationality = book.Nationality,
                Price = book.Price,
                Genre = book.Genre,
                TypeBook = book.TypeBook,
                Year = book.Year,
                Authors = book.Authors,
                Publishers = book.Publishers,
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, BookCreateServiceModel model)
        {
            if (!this.User.IsAdmin())
            {
                return Unauthorized();
            }

            TempData["message"] = "You have sucssessfuly Edit a book!";

            await this.books.Edit(id, model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!this.User.IsAdmin())
            {
                return Unauthorized();
            }

            var book = await this.books.FindBookById(id);

            return View(new BookDeleteView()
            {
                Id = id,
                Title = book.Title,
                ImageUrlLink = book.ImageUrlLink,
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete(BookDeleteView model)
        {
            if (!this.User.IsAdmin())
            {
                return Unauthorized();
            }

            var book = await this.books.Delete(model.Id);

            TempData["message"] = "You have sucssessfuly delete a book!";

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Add()
        {
            if (!this.User.IsAdmin())
            {
                return Unauthorized();
            }

            return View(new BookCreateServiceModel()
            {
                Authors = await this.author.GetAllAuthors(),
                Publishers = await this.publisher.GetAllPublishers(),
            });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(BookCreateServiceModel model)
        {
            if (!this.User.IsAdmin())
            {
                return Unauthorized();
            }

            TempData["message"] = "You have sucssessfuly added a book!";

            var bookId = await this.books.Create(model);

            return RedirectToAction(nameof(Details), new { bookId });
        }
    }
}
