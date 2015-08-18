namespace BookShopSystem.Client
{
    using System;
    using System.Linq;
    using Data;

    public class BookShopMain
    {
        public static void Main()
        {
            BookShopContext context = new BookShopContext();
            Console.WriteLine(context.Authors.Count());
        }
    }
}
