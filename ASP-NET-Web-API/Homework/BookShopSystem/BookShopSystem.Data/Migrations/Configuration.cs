namespace BookShopSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using System.Web.Hosting;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
        private const string AuthorsSource = "authors.txt";
        private const string BooksSource = "books.txt";
        private const string CategoriesSource = "categories.txt";

        private readonly string dataSource = HostingEnvironment.MapPath("~/App_Data/");

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "BookShopSystem.Data.BookShopContex";
        }

        protected override void Seed(BookShopContext context)
        {
            if (!context.Books.Any())
            {
                this.AddAuthors(context);

                this.AddCategories(context);

                this.AddBooks(context);
            }
        }

        private void AddBooks(BookShopContext context)
        {
            const int maxCategoriesCount = 4;
            const int minCategoriesCount = 0;
            int categoriesCount = context.Categories.Count() + 1;

            var random = new Random();

            using (var reader = new StreamReader(this.dataSource + BooksSource))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                var authors = context.Authors.ToList();

                while (line != null)
                {
                    var data = line.Split(new[] {' '}, 6);
                    var authorIndex = random.Next(0, authors.Count);
                    var author = authors[authorIndex];
                    var edition = (EditionType) int.Parse(data[0]);
                    var releaseDate = DateTime.Parse(data[1]);
                    var copies = int.Parse(data[2]);
                    var price = decimal.Parse(data[3]);
                    var title = data[5];
                    int bookCategoriesCount = random.Next(minCategoriesCount, maxCategoriesCount);
                    ICollection<Category> categories = new HashSet<Category>();

                    for (int i = 0; i < bookCategoriesCount; i++)
                    {
                        int categoryId = random.Next(0, categoriesCount);
                        Category category = context.Categories.FirstOrDefault(c => c.Id == categoryId);
                        
                        categories.Add(category);
                    }

                    context.Books.Add(new Book()
                    {
                        Author = author,
                        EditionType = edition,
                        Copies = copies,
                        Price = price,
                        Title = title,
                        ReleaseDate = releaseDate,
                        Categories = categories
                    });

                    line = reader.ReadLine();

                    context.SaveChanges();
                }
            }
        }

        private void AddCategories(BookShopContext context)
        {
            using (var reader = new StreamReader(this.dataSource + CategoriesSource))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new[] {' '}, 2);
                    var categoryName = data[0];

                    context.Categories.Add(new Category()
                    {
                        Name = categoryName
                    });

                    line = reader.ReadLine();
                }

                context.SaveChanges();
            }
        }

        private void AddAuthors(BookShopContext context)
        {
            using (var reader = new StreamReader(this.dataSource + AuthorsSource))
            {
                var line = reader.ReadLine();
                line = reader.ReadLine();
                while (line != null)
                {
                    var data = line.Split(new[] {' '}, 2);
                    var firstName = data[0];
                    var lastName = data[1];

                    context.Authors.Add(new Author()
                    {
                        FirstName = firstName,
                        LastName = lastName
                    });

                    line = reader.ReadLine();
                }

                context.SaveChanges();
            }
        }
    }
}
