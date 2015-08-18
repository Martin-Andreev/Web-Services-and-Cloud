namespace BookShopSystem.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BookShopSystem.Models;
    using Data;
    using Infrastructure;
    using Models.BindingModels;
    using Models.ViewModels;

    [RoutePrefix("api/Categories")]
    public class CategoriesController : BaseApiController
    {
        private IUserIdProvider userIdProvider;

        public CategoriesController(IBookShopData data, IUserIdProvider userIdProvider)
            : base(data)
        {
            this.userIdProvider = userIdProvider;
        }

        [HttpGet]
        public IHttpActionResult GetCategories()
        {
            var categories = this.data
                .Categories
                .All()
                .Select(CategoryViewModel.ConvertToCategoryViewModel);

            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetCategory(int id)
        {
            var category = this.data.Categories.Find(id);
            if (category == null)
            {
                return BadRequest("Category does not exist - invalid id");
            }

            var categoryViewModel = CategoryViewModel.ConvertToCategoryViewModel(category);
            
            return Ok(categoryViewModel);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult DeleteCategoryById(int id)
        {
            Category category = this.data.Categories.Find(id);
            if (category == null)
            {
                return this.BadRequest("Category does not exist - invalid id!");
            }

            this.data.Categories.Delete(category);
            this.data.Save();

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult Create(CategoryBindingModel categoryBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            bool duplicatedCategory = this.data
                .Categories
                .All()
                .FirstOrDefault(c => c.Name == categoryBindingModel.Name) != null;

            if (duplicatedCategory)
            {
                return this.BadRequest("A category with the same name already exists");
            }

            Category category = new Category
            {
                Name = categoryBindingModel.Name
            };

            this.data.Categories.Add(category);
            this.data.Save();

            CategoryViewModel categoryViewModel = CategoryViewModel.ConvertToCategoryViewModel(category);

            return Ok(categoryViewModel);
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public IHttpActionResult UpdateCategory(int id, CategoryBindingModel categoryBindingModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var existingCategory = this.data.Categories.Find(id);
            if (existingCategory == null)
            {
                return this.BadRequest("Category does not exist - invalid id");
            }

            bool duplicatedCategory = this.data
                .Categories
                .All()
                .FirstOrDefault(c => c.Name == categoryBindingModel.Name) != null;

            if (duplicatedCategory)
            {
                return this.BadRequest("A category with the same name already exists");
            }

            existingCategory.Name = categoryBindingModel.Name;

            this.data.Categories.Update(existingCategory);
            this.data.Save();

            CategoryViewModel categoryViewModel = CategoryViewModel.ConvertToCategoryViewModel(existingCategory);

            return Ok(categoryViewModel);
        }
    }
}
