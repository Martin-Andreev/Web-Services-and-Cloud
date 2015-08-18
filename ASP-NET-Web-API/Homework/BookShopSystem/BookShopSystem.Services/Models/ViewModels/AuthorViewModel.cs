namespace BookShopSystem.Services.Models.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using BookShopSystem.Models;

    public class AuthorViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BookTitles { get; set; }

        public static AuthorViewModel ConvertToAuthorViewModel(Author author)
        {
            string titles = string.Join(", ", author.Books.Select(b => b.Title));

            AuthorViewModel authorViewModel = new AuthorViewModel
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName,
                    BookTitles = titles
                };

            return authorViewModel;
        }
    }
}