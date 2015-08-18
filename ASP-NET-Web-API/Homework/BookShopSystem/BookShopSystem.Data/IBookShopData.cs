namespace BookShopSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Repository;

    public interface IBookShopData
    {
        IRepository<Book> Books { get; }

        IRepository<Author> Authors { get; }

        IRepository<Category> Categories { get; }

        IRepository<ApplicationUser> Users { get; }
        
        IRepository<Purchase> Purchases { get; }

        IRepository<IdentityRole> Roles { get; }

        void Save();
    }
}
