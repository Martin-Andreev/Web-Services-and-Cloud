namespace BookShopSystem.Services.Models.ViewModels
{
    using System;
    using BookShopSystem.Models;

    public class PurchaseViewModel
    {
        
        public string Username { get; set; }

        public string BookTitle { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public bool IsRecalled { get; set; }

        public static PurchaseViewModel ConvertToPurchaseViewModel(Purchase purchase)
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel
            {
                Username = purchase.User.UserName,
                BookTitle = purchase.Book.Title,
                Price = purchase.Price,
                DateOfPurchase = purchase.DateOfPurchase,
                IsRecalled = purchase.IsRecalled
            };

            return purchaseViewModel;
        } 
    }
}