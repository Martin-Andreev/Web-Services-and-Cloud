namespace BookShopSystem.Services.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using BookShopSystem.Models;

    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public EditionType EditionType { get; set; }

        public decimal Price { get; set; }

        public int Copies { get; set; }

        public AuthorViewModelMinified Author { get; set; }

        public DateTime ReleaseDate { get; set; }
 
        public IEnumerable<string> Categories { get; set; }

        public static Expression<Func<Book, BookViewModel>> Create
        {
            get
            {
                return book => new BookViewModel
                {
                    Id = book.Id,
                    Author = AuthorViewModelMinified.ConvertToAuthorViewModel(book.Author),
                    Categories = book.Categories.Select(c => c.Name),
                    Copies = book.Copies,
                    Description = book.Description,
                    EditionType = book.EditionType,
                    Price = book.Price,
                    Title = book.Title,
                    AgeRestriction = book.AgeRestriction,
                    ReleaseDate = book.ReleaseDate.Date
                };
            }
        }

        public static BookViewModel ConvertToBookViewModel(Book book)
        {
            BookViewModel bookViewModel = new BookViewModel
            {
                Id = book.Id,
                Author = AuthorViewModelMinified.ConvertToAuthorViewModel(book.Author),
                Categories = book.Categories.Select(c => c.Name),
                Copies = book.Copies,
                Description = book.Description,
                EditionType = book.EditionType,
                Price = book.Price,
                Title = book.Title,
                AgeRestriction = book.AgeRestriction,
                ReleaseDate = book.ReleaseDate.Date
            };

            return bookViewModel;
        }
    }
}