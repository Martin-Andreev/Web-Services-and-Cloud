namespace BookShopSystem.Services.Models.ViewModels
{
    using System.Collections.Generic;
    using BookShopSystem.Models;

    public class UserViewModel
    {
        public string Username { get; set; }

        public IEnumerable<PurchaseViewModel> Purchases { get; set; } 

        public static UserViewModel ConvertToUserViewModel(ApplicationUser user)
        {
            UserViewModel userViewModel = new UserViewModel
            {
                Username = user.UserName
            };

            return userViewModel;
        } 
    }
}