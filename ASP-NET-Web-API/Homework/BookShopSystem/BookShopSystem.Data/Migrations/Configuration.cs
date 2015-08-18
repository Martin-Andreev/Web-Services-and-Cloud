namespace BookShopSystem.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;
    using Models;

    public sealed class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
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
                AddAuthors(context);

                AddCategories(context);

                AddBooks(context);
            }
        }

        private static void AddBooks(BookShopContext context)
        {
            const int maxCategoriesCount = 4;
            const int minCategoriesCount = 0;
            int categoriesCount = context.Categories.Count() + 1;

            var random = new Random();

            using (var reader = new StreamReader("../../Data/books.txt"))
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
                        Categories = categories
                    });

                    line = reader.ReadLine();
                }

                context.SaveChanges();
            }
        }

        private static void AddCategories(BookShopContext context)
        {
            using (var reader = new StreamReader("../../Data/categories.txt"))
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

        private static void AddAuthors(BookShopContext context)
        {
            using (var reader = new StreamReader("../../Data/authors.txt"))
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
