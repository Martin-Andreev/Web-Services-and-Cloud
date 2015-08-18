namespace BookShopSystem.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class CategoryBindingModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Name { get; set; }
    }
}