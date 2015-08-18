namespace BookShopSystem.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    //DbContext
    public class BookShopContext : IdentityDbContext<ApplicationUser>, IBookShopContext
    {
        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext, Configuration>());
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Purchase> Purchases { get; set; }

        public static BookShopContext Create()
        {
            return new BookShopContext();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void Save()
        {
            base.SaveChanges();
        }
    }
}