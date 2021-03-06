﻿namespace BookShopSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BookShopSystem.Models;
    using Models.BindingModels;
    using Models.ViewModels;

    [RoutePrefix("api/Authors")]
    public class AuthorsController : BaseApiController
    {
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var author = this.data
                .Authors
                .All()
                .Where(a => a.Id == id)
                .Select(AuthorViewModel.Create)
                .FirstOrDefault();

            if (author == null)
            {
                return this.BadRequest("Author does not exit - invalid id!");
            }

            return this.Ok(author);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult Create(AuthorBindindModel authorBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var author = new Author()
            {
                FirstName = authorBindingModel.FirstName,
                LastName = authorBindingModel.LastName
            };

            this.data.Authors.Add(author);
            this.data.Save();

            AuthorViewModel authorViewModel = AuthorViewModel.ConvertToAuthorViewModel(author);
            return this.Ok(authorViewModel);
        }

        [HttpGet]
        [Route("{id}/books")]
        public IHttpActionResult GetBooksByAuthor(int id)
        {
            var author = this.data.Authors.Find(id);
            if (author == null)
            {
                return this.BadRequest("Author does not exit - invalid id!");
            }

            var books = author
                .Books
                .AsQueryable()
                .Select(BookViewModel.Create);

            return this.Ok(books);
        }
    }
}
