namespace BookShopSystem.Services.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class AuthorBindindModel
    {
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }
    }
}