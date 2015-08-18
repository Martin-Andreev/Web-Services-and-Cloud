namespace BookShopSystem.Data
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Repository;

    public class BookShopData : IBookShopData
    {
        private IBookShopContext context;
        private IDictionary<Type, object> repositories;

        public BookShopData()
            : this(new BookShopContext())
        {
        }

        public BookShopData(IBookShopContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Book> Books
        {
            get { return this.GetRepository<Book>(); }
        }

        public IRepository<Author> Authors
        {
            get { return this.GetRepository<Author>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public IRepository<ApplicationUser> Users
        {
            get { return this.GetRepository<ApplicationUser>(); }
        }

        public IRepository<Purchase> Purchases
        {
            get { return this.GetRepository<Purchase>(); }
        }

        public IRepository<IdentityRole> Roles
        {
            get
            {
                return this.GetRepository<IdentityRole>();
            }
        } 

        public void Save()
        {
            this.context.Save();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof (T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof (EFRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            IRepository<T> repository = (IRepository<T>) this.repositories[typeOfModel];

            return repository;
        } 
    }
}
