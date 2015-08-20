namespace BookShopSystem.Services.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using BookShopSystem.Models;

    public class BookViewModelMinified
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public static Expression<Func<Book, BookViewModelMinified>> Create
        {
            get
            {
                return book => new BookViewModelMinified
                {
                    Id = book.Id,
                    Title = book.Title
                };
            }
        }
    }
}