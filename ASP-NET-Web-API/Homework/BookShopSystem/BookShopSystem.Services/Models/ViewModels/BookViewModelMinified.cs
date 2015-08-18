namespace BookShopSystem.Services.Models.ViewModels
{
    using BookShopSystem.Models;

    public class BookViewModelMinified
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public static BookViewModelMinified ConvertToBookViewModel(Book book)
        {
            BookViewModelMinified bookViewModel = new BookViewModelMinified
            {
                Id = book.Id,
                Title = book.Title
            };

            return bookViewModel;
        }
    }
}