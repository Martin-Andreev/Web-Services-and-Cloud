namespace BookShopSystem.Services.Models.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using BookShopSystem.Models;

    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

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