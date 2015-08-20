namespace BookShopSystem.Services.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using BookShopSystem.Models;

    public class AuthorViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
         
        public IEnumerable<string> BookTitles { get; set; }

        public static Expression<Func<Author, AuthorViewModel>> Create
        {
            get
            {
                return author => new AuthorViewModel
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    BookTitles = author.Books.Select(b => b.Title)
                };
            }
        }

        public static AuthorViewModel ConvertToAuthorViewModel(Author author)
        {
            AuthorViewModel authorViewModel = new AuthorViewModel
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    BookTitles = author.Books.Select(b => b.Title)
                };

            return authorViewModel;
        }
    }
}