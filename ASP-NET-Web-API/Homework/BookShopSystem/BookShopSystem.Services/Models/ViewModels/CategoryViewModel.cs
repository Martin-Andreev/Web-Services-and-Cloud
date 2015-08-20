namespace BookShopSystem.Services.Models.ViewModels
{
    using System;
    using System.Linq.Expressions;
    using BookShopSystem.Models;

    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public static Expression<Func<Category, CategoryViewModel>> Create
        {
            get
            {
                return category => new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name
                };
            }
        }

        public static CategoryViewModel ConvertToCategoryViewModel(Category category)
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name
            };

            return categoryViewModel;
        } 
    }
}