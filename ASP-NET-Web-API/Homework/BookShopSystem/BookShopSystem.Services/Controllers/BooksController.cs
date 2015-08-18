namespace BookShopSystem.Services.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using BookShopSystem.Models;
    using Data;
    using Infrastructure;
    using Models.BindingModels;
    using Models.ViewModels;

    [RoutePrefix("api/Books")]
    public class BooksController : BaseApiController
    {
        private IUserIdProvider userIdProvider;

        public BooksController(IBookShopData data, IUserIdProvider userIdProvider)
            : base(data)
        {
            this.userIdProvider = userIdProvider;
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetBook(int id)
        {
            var book = this.data.Books.Find(id);
            if (book == null)
            {
                return this.BadRequest("Book does not exist - invalid id");
            }

            var bookViewModel = BookViewModel.ConvertToBookViewModel(book); 

            return Ok(bookViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult Create(BookBindingModel bookBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var author = this.data.Authors.Find(bookBindingModel.AuthorId);
            if (author == null)
            {
                return this.BadRequest("Author does not exist - invalid id!");
            }

            Book book = new Book()
            {
                Title = bookBindingModel.Title,
                Description = bookBindingModel.Description,
                Price = bookBindingModel.Price,
                Copies = bookBindingModel.Copies,
                EditionType = bookBindingModel.EditionType,
                AgeRestriction = bookBindingModel.AgeRestriction,
                ReleaseDate = bookBindingModel.ReleaseDate,
                Author = author
            };

            string[] categories = bookBindingModel.Categories.Split(new [] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var categoryName in categories)
            {
                Category category = this.data
                    .Categories
                    .All()
                    .FirstOrDefault(c => c.Name == categoryName);

                if (category == null)
                {
                    category = new Category
                    {
                        Name = categoryName
                    };

                    this.data.Categories.Add(category);
                }

                book.Categories.Add(category);
            }

            this.data.Books.Add(book);
            this.data.Save();

            BookViewModel bookViewModel = BookViewModel.ConvertToBookViewModel(book);
            return Ok(bookViewModel);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteBookById(int id)
        {
            Book book = this.data.Books.Find(id);
            if (book == null)
            {
                return this.BadRequest("Book does not exist - invalid id!");
            }

            this.data.Books.Delete(book);
            this.data.Save();

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult UpdateBook(int id, BookBindingModel bookBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingBook = this.data.Books.Find(id);
            if (existingBook == null)
            {
                return this.BadRequest("Book does not exist - invalid id!");
            }

            Author author = this.data.Authors.Find(bookBindingModel.AuthorId);
            if (author == null)
            {
                return this.BadRequest("Author does not exist - invalid id!");
            }

            existingBook.AgeRestriction = bookBindingModel.AgeRestriction;
            existingBook.Author = author;
            existingBook.Copies = bookBindingModel.Copies;
            existingBook.Description = bookBindingModel.Description;
            existingBook.EditionType = bookBindingModel.EditionType;
            existingBook.Price = bookBindingModel.Price;
            existingBook.ReleaseDate = bookBindingModel.ReleaseDate;
            existingBook.Title = bookBindingModel.Title;

            this.data.Books.Update(existingBook);
            this.data.Save();

            BookViewModel bookViewModel = BookViewModel.ConvertToBookViewModel(existingBook);

            return Ok(bookViewModel);
        }

        [HttpGet]
        [Route("search={word}")]
        public IHttpActionResult GetTopTenBooksBySubstring(string word)
        {
            var books = this.data
                .Books
                .All()
                .Where(b => b.Title.Contains(word))
                .Select(BookViewModelMinified.ConvertToBookViewModel)
                .OrderBy(b => b.Title)
                .Take(10);

            return Ok(books);
        }

        [HttpPut]
        [Route("buy/{id}")]
        public IHttpActionResult BuyBook(int id)
        {
            string loggedUserId = this.userIdProvider.GetUserId();
            var loggedUser = this.data.Users.Find(loggedUserId);
            if (loggedUser == null)
            {
                return this.BadRequest("Invalid session token.");
            }

            var existingBook = this.data.Books.Find(id);
            if (existingBook == null)
            {
                return this.BadRequest("Book does not exist - invalid id!");
            }

            if (existingBook.Copies == 0)
            {
                return this.BadRequest("Unable to make purchase - insufficient book copies quantity.");
            }

            Purchase purchase = new Purchase()
            {
                Book = existingBook,
                BookId = existingBook.Id,
                DateOfPurchase = DateTime.Now,
                Price = existingBook.Price,
                User = loggedUser,
                UserId = loggedUserId,
                IsRecalled = false
            };

            existingBook.Copies--;

            this.data.Purchases.Add(purchase);
            this.data.Save();

            PurchaseViewModel purchaseViewModel = PurchaseViewModel.ConvertToPurchaseViewModel(purchase);
            
            return Ok(purchaseViewModel);
        }

        [HttpPut]
        [Route("recall/{id}")]
        public IHttpActionResult RecallBook(int id)
        {
            var loggedUserId = this.userIdProvider.GetUserId();
            var loggedUser = this.data.Users.Find(loggedUserId);
            if (loggedUser == null)
            {
                return this.BadRequest("Invalid session token.");
            }

            var existingBook = this.data.Books.Find(id);
            if (existingBook == null)
            {
                return this.BadRequest("Book does not exist - invalid id!");
            }

            var purchase = this.data
                .Purchases
                .All()
                .FirstOrDefault(p => p.BookId == existingBook.Id && p.UserId == loggedUserId && p.IsRecalled == false);

            if (purchase == null)
            {
                return this.BadRequest("You have no purchase of that book!");
            }

            if ((DateTime.Now - purchase.DateOfPurchase).TotalDays > 30)
            {
                return this.BadRequest("Unable to return the book - more than 30 days have passed since the purchase!");
            }

            purchase.IsRecalled = true;
            purchase.Book.Copies++;

            this.data.Save();

            return Ok();
        }
    }
}
