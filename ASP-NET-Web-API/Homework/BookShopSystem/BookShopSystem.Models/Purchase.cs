namespace BookShopSystem.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Purchase
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        //[Required]
        public virtual ApplicationUser User { get; set; }

        public int BookId { get; set; }

        [Required]
        public virtual Book Book { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }

        [Required]
        public bool IsRecalled { get; set; }
    }
}
