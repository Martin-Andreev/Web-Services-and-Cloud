namespace BookShopSystem.Services.Models.ViewModels
{
    using BookShopSystem.Models;

    public class AuthorViewModelMinified
    {
        public int Id { get; set; }

        public string AuthorName { get; set; }

        public static AuthorViewModelMinified ConvertToAuthorViewModel(Author author)
        {
            string authorName = string.Format("{0} {1}", author.FirstName, author.LastName);

            AuthorViewModelMinified authorViewModel = new AuthorViewModelMinified
            {
                Id = author.Id,
                AuthorName = authorName
            };

            return authorViewModel;
        } 
    }
}